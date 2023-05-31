using Agro.DataAccess.Entities;
using Agro.Models;
using Agro.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Controllers
{

    public class ProductRecipeController : Controller
    {
        private readonly IProductRecipeService _productRecipeService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductRecipeController(IProductRecipeService productRecipeService, IAnimalGroupService animalGroupService, 
            IProductService productService, IMapper mapper)
        {
            _productRecipeService = productRecipeService;
            _productService = productService;
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

            var products = await _productService.GetAllProducts();
            ViewBag.Products = products;

            var productRecipe = await _productRecipeService.GetProductRecipe(id);
            var model = _mapper.Map<ProductRecipeViewModel>(productRecipe);
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
    }
}