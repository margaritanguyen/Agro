using Agro.DataAccess.Entities;
using Agro.Models;
using Agro.Pagination;
using Agro.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Controllers
{

    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IAnimalGroupService _animalGroupService;
        private readonly IProductRecipeService _productRecipeService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IAnimalGroupService animalGroupService, 
            IProductRecipeService productRecipeService, IMapper mapper)
        {
            _productService = productService;
            _animalGroupService = animalGroupService;
            _productRecipeService = productRecipeService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index(int? pageNumber, string sortOrder, string filter, int? animalGroupId)
        {
            var animalGroups = await _animalGroupService.GetAllAnimalGroups();
            ViewBag.AnimalGroups = animalGroups;

            var products = await _productService.GetAllProducts();

            if (filter != null)
                products = products.Where(x => x.Number.ToLower().Contains(filter.ToLower())
                || x.ShortName.ToLower().Contains(filter.ToLower())).ToList();

            if (animalGroupId != null)
                products = products.Where(x => x.AnimalGroupId.Equals(animalGroupId)).ToList();

            ViewBag.NumberSortParam = String.IsNullOrEmpty(sortOrder) ? "number_desc" : "";
            ViewBag.ShortNameSortParam = sortOrder == "shortName_asc" ? "shortName_desc" : "shortName_asc";

            switch (sortOrder)
            {
                case "shortName_desc":
                    products = products.OrderByDescending(s => s.ShortName).ToList();
                    break;
                case "shortName_asc":
                    products = products.OrderBy(s => s.ShortName).ToList();
                    break;
                case "number_desc":
                    products = products.OrderByDescending(s => s.Number).ToList();
                    break;
                default:
                    products = products.OrderBy(s => s.Number).ToList();
                    break;
            }

            var model = _mapper.Map<IEnumerable<Product>, IList<ProductViewModel>>(products);
            var pagedList = PaginatedList<ProductViewModel>.Create(model, pageNumber ?? 1, 10);
            return View(pagedList);
        }

        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Create()
        {
            var animalGroups = await _animalGroupService.GetAllAnimalGroups();
            ViewBag.AnimalGroups = animalGroups;

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(model);
                product.LastChange = DateTime.Now;
                await _productService.CreateProduct(product);
                return RedirectToAction("Index", "Product");
            }

            var animalGroups = await _animalGroupService.GetAllAnimalGroups();
            ViewBag.AnimalGroups = animalGroups;

            return View(model);
        }


        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(int id)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString();

            var animalGroups = await _animalGroupService.GetAllAnimalGroups();
            ViewBag.AnimalGroups = animalGroups;

            var product = await _productService.GetProduct(id);
            var model = _mapper.Map<ProductEditViewModel>(product);
            var productRecipes = await _productRecipeService.GetAllProductRecipesByProductId(id);
            model.ProductRecipes = productRecipes;
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(model);
                product.LastChange = DateTime.Now;
                await _productService.UpdateProduct(product);
                return Redirect(TempData["returnUrl"].ToString());
            }

            var animalGroups = await _animalGroupService.GetAllAnimalGroups();
            ViewBag.AnimalGroups = animalGroups;

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Watch(int id)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString();

            var animalGroups = await _animalGroupService.GetAllAnimalGroups();
            ViewBag.AnimalGroups = animalGroups;

            var product = await _productService.GetProduct(id);
            var model = _mapper.Map<ProductEditViewModel>(product);
            var productRecipes = await _productRecipeService.GetAllProductRecipesByProductId(id);
            model.ProductRecipes = productRecipes;
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProduct(id);
            await _productService.DeleteProduct(product);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}