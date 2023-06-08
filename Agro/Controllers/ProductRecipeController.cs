using Agro.DataAccess.Entities;
using Agro.Models;
using Agro.Services.Interfaces;
using Agro.Services.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Controllers
{

    public class ProductRecipeController : Controller
    {
        private readonly IProductRecipeService _productRecipeService;
        private readonly IProductService _productService;
        private readonly IRecipeIngredientService _recipeIngredientService;
        private readonly IResourceService _resourceService;
        private readonly IMapper _mapper;

        public ProductRecipeController(IProductRecipeService productRecipeService, IRecipeIngredientService recipeIngredientService, 
            IProductService productService, IResourceService resourceService, IMapper mapper)
        {
            _productRecipeService = productRecipeService;
            _productService = productService;
            _recipeIngredientService = recipeIngredientService;
            _resourceService = resourceService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Create(int productId)
        {
            var products = await _productService.GetAllProducts();
            ViewBag.Products = products;

            var model = new ProductRecipeViewModel() { ProductId = productId };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Create(ProductRecipeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var productRecipe = _mapper.Map<ProductRecipe>(model);
                productRecipe.LastChange = DateTime.Now;
                await _productRecipeService.CreateProductRecipe(productRecipe);
                return RedirectToAction("Edit", "Product", new { id = model.ProductId });
            }

            return View(model);
        }


        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(int id)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString();

            var resources = await _resourceService.GetAllResources();
            var productRecipe = await _productRecipeService.GetProductRecipe(id);
            var model = _mapper.Map<ProductRecipeViewModel>(productRecipe);
            var product = await _productService.GetProduct(productRecipe.ProductId);
            var recipeIngredients = await _recipeIngredientService.GetAllRecipeIngredients(id);
            model.RecipeIngredients = recipeIngredients;
            model.Product = product;
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(ProductRecipeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var productRecipe = _mapper.Map<ProductRecipe>(model);
                productRecipe.LastChange = DateTime.Now;
                await _productRecipeService.UpdateProductRecipe(productRecipe);
                return Redirect(TempData["returnUrl"].ToString());
            }

            var products = await _productService.GetAllProducts();
            ViewBag.Products = products;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Delete(int id)
        {
            var productRecipe = await _productRecipeService.GetProductRecipe(id);
            await _productRecipeService.DeleteProductRecipe(productRecipe);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Copy(int id)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString();

            var productRecipe = await _productRecipeService.GetProductRecipe(id);
            productRecipe.Id = 0;
            productRecipe.Version = await GenerateVersion(productRecipe.ProductId);
            var addedProductRecipe = await _productRecipeService.CreateProductRecipe(productRecipe);
            var recipeIngredients = await _recipeIngredientService.GetAllRecipeIngredients(id);
            
            foreach (var recipeIngredient in recipeIngredients)
            {
                recipeIngredient.Id = 0;
                recipeIngredient.ProductRecipeId = addedProductRecipe.Id;
            }

            await _recipeIngredientService.CreateRangeRecipeIngredient(recipeIngredients);

            return Redirect(Request.Headers["Referer"].ToString());
        }

        private async Task<int> GenerateVersion(int productId)
        {
            var productRecipes = await _productRecipeService.GetAllProductRecipes(productId);
            var lastRecipe = productRecipes.Where(x => x.ProductId == productId).OrderByDescending(x => x.Version).FirstOrDefault();
            var version = lastRecipe != null ? lastRecipe.Version + 1 : 1;
            return version;
        }

    }
}