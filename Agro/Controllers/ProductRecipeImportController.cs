using Agro.DataAccess.Entities;
using Agro.Models;
using Agro.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Agro.Controllers
{
    public class ProductRecipeImportController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductRecipeService _productRecipeService;
        private readonly IResourceService _resourceService;
        private readonly IRecipeIngredientService _recipeIngredientService;
        private readonly IMapper _mapper;

        public ProductRecipeImportController(IProductService productService, IProductRecipeService productRecipeService,
            IResourceService resourceService, IRecipeIngredientService recipeIngredientService, IMapper mapper)
        {
            _productService = productService;
            _productRecipeService = productRecipeService;
            _resourceService = resourceService;
            _recipeIngredientService = recipeIngredientService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Import(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                TempData["fileValidationError"] = "Ошибка загрузки файла";
                return RedirectToAction("Index", "ProductRecipeImport");
            }

            var fileExtension = Path.GetExtension(file.FileName);
            if (fileExtension != ".csv")
            {
                TempData["fileValidationError"] = "Недопустимый формат файла";
                return RedirectToAction("Index", "ProductRecipeImport");
            }

            var model = await ImportProductRecipe(file);
            return View("Index", model);
        }

        private async Task<ProductRecipeImportViewModel> ImportProductRecipe(IFormFile file)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); 
            
            var productFileImportViewModel = new ProductRecipeImportViewModel();

            using (var fileStream = file.OpenReadStream())
            using (var reader = new StreamReader(fileStream, Encoding.GetEncoding("windows-1251")))
            {
                var lines = reader.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                //product
                var recipeDescription = lines[4].ToString();
                var productShortName = recipeDescription.Substring(0, recipeDescription.IndexOf(" "));
                recipeDescription = recipeDescription.Substring(recipeDescription.IndexOf(" ") + 2);
                var productNumber = recipeDescription.Substring(0, recipeDescription.IndexOf(" "));
                var productName = recipeDescription.Substring(recipeDescription.IndexOf(" ") + 1);
                var product = await FindProduct(productNumber, productShortName, productName);
                productFileImportViewModel.Products.Add(product);

                //productRecipe
                var productRecipe = await FindProductRecipe(product.Id);
                productFileImportViewModel.ProductRecipes.Add(productRecipe);

                //ingredients
                List<RecipeIngredient> recipeIngredients = new List<RecipeIngredient>();

                for (int i = 7; i < lines.Count(); i++)
                {
                    var line = lines[i].Split(';');

                    if (line[0].ToLower().StartsWith("итого")) break;
                    if (line[0].ToLower().StartsWith("всего")) break;

                    var resourceContent = Convert.ToSingle(line[7].Replace(',', '.'));
                    var resourceName = line[0];
                    var resourceActivity = Convert.ToDouble(line[3].Replace(',', '.'));
                    var resource = await FindResource(resourceName, resourceActivity);
                    recipeIngredients.Add(
                        new RecipeIngredient
                        {
                            ProductRecipeId = productRecipe.Id,
                            ResourceId = resource.Id,
                            ResourceContent = resourceContent
                        });
                    productFileImportViewModel.Resources.Add(resource);
                }

                var addedIngredients = await _recipeIngredientService.CreateRangeRecipeIngredient(recipeIngredients);
                productFileImportViewModel.RecipeIngredients = addedIngredients.ToList();
            }

            return productFileImportViewModel;
        }

        private async Task<Resource> FindResource(string name, double activity)
        {
            var resources = await _resourceService.GetAllResources();
            var resource = resources.Where(x => x.Name.ToLower().Equals(name.ToLower()) && x.Activity == activity).FirstOrDefault();

            if (resource == null)
            {
                resource = await _resourceService.CreateResource(
                    new Resource
                    {
                        Code = resources.Max(x => x.Code) + 1,
                        Name = name,
                        ShortName = name,
                        Activity = (float)activity,
                        AlertTolerance = 5,
                        RejectTolerance = 5,
                        TechTolerance = 5,
                        Density = 1,
                        DosingTypeId = 1,
                        ResourceTypeId = 1,
                        LastChange = DateTime.Now
                    });
            }

            return resource;
        }

        private async Task<Product> FindProduct(string number, string shortName, string name)
        {
            var products = await _productService.GetAllProducts();
            var product = products.Where(x => x.Number.ToLower().Equals(number.ToLower())).FirstOrDefault();

            if (product == null)
            {
                product = await _productService.CreateProduct(
                    new Product
                    {
                        Number = number,
                        Name = name,
                        ShortName = shortName,
                        LastChange = DateTime.Now
                    });
            }

            return product;
        }

        private async Task<ProductRecipe> FindProductRecipe(int productId)
        {
            var productRecipes = await _productRecipeService.GetAllProductRecipes(productId);
            var productRecipe = new ProductRecipe();

            if (productRecipes == null || productRecipes.Count() == 0)
            {
                productRecipe = await _productRecipeService.CreateProductRecipe(
                    new ProductRecipe
                    {
                        IsEnabled = true,
                        ProductId = productId,
                        Version = 1
                    });
            }
            else
            {
                productRecipe = await _productRecipeService.CreateProductRecipe(
                    new ProductRecipe
                    {
                        IsEnabled = true,
                        ProductId = productId,
                        Version = productRecipes.Max(x => x.Version) + 1
                    });
            }

            return productRecipe;
        }
    }
}
