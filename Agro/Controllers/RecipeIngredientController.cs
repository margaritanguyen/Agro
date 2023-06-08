using Agro.DataAccess.Entities;
using Agro.Models;
using Agro.Pagination;
using Agro.Services.Interfaces;
using Agro.Services.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Controllers
{

    public class RecipeIngredientController : Controller
    {
        private readonly IRecipeIngredientService _recipeIngredientService;
        private readonly IResourceService _resourceService;
        private readonly IMapper _mapper;

        public RecipeIngredientController(IRecipeIngredientService recipeIngredientService, IResourceService resourceService, IMapper mapper)
        {
            _recipeIngredientService = recipeIngredientService;
            _resourceService = resourceService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Create(int productRecipeId)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString();
            
            var resources = await _resourceService.GetAllResources();
            ViewBag.Resources = resources;
            
            var model = new RecipeIngredientViewModel() { ProductRecipeId = productRecipeId };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Create(RecipeIngredientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var recipeIngredient = _mapper.Map<RecipeIngredient>(model);
                await _recipeIngredientService.CreateRecipeIngredient(recipeIngredient);
                return RedirectToAction("Edit", "ProductRecipe", new { id = model.ProductRecipeId });
            }

            return View(model);
        }

        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(int id)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString();

            var resources = await _resourceService.GetAllResources();
            ViewBag.Resources = resources;
            
            var recipeIngredient = await _recipeIngredientService.GetRecipeIngredient(id);
            var model = _mapper.Map<RecipeIngredientViewModel>(recipeIngredient);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(RecipeIngredientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var recipeIngredient = _mapper.Map<RecipeIngredient>(model);
                await _recipeIngredientService.UpdateRecipeIngredient(recipeIngredient);
                return RedirectToAction("Edit", "ProductRecipe", new { id = model.ProductRecipeId });
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Delete(int id)
        {
            var recipeIngredient = await _recipeIngredientService.GetRecipeIngredient(id);
            await _recipeIngredientService.DeleteRecipeIngredient(recipeIngredient);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}