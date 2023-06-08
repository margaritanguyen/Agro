﻿using Agro.DataAccess.Entities;
using Agro.Models;
using Agro.Pagination;
using Agro.Services.Interfaces;
using Agro.Services.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Controllers
{

    public class DosingTaskController : Controller
    {
        private readonly IDosingTaskService _dosingTaskService;
        private readonly IProductService _productService;
        private readonly IProductRecipeService _productRecipeService;
        private readonly ITaskMessageService _taskMessageService;
        private readonly IMapper _mapper;

        public DosingTaskController(IDosingTaskService dosingTaskService, IProductService productService, 
            IProductRecipeService productRecipeService, ITaskMessageService taskMessageService, IMapper mapper)
        {
            _dosingTaskService = dosingTaskService;
            _productService = productService;
            _productRecipeService = productRecipeService;
            _taskMessageService = taskMessageService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index(int? pageNumber, string sortOrder, string filter)
        {
            var taskMessages = await _taskMessageService.GetAllTaskMessages();
            var dosingTasks = await _dosingTaskService.GetAllDosingTasks();

            if (filter != null)
                dosingTasks = dosingTasks.Where(x => x.ManufNr.ToString().Contains(filter.ToLower())).ToList();

            //ViewBag.CodeSortParam = String.IsNullOrEmpty(sortOrder) ? "code_desc" : "";
            //ViewBag.NameSortParam = sortOrder == "name_asc" ? "name_desc" : "name_asc";

            //switch (sortOrder)
            //{
            //    case "name_desc":
            //        dosingTasks = dosingTasks.OrderByDescending(s => s.Name).ToList();
            //        break;
            //    case "name_asc":
            //        dosingTasks = dosingTasks.OrderBy(s => s.Name).ToList();
            //        break;
            //    case "code_desc":
            //        dosingTasks = dosingTasks.OrderByDescending(s => s.Code).ToList();
            //        break;
            //    default:
            //        dosingTasks = dosingTasks.OrderBy(s => s.Code).ToList();
            //        break;
            //}

            var model = _mapper.Map<IEnumerable<DosingTask>, IList<DosingTaskViewModel>>(dosingTasks);
            var pagedList = PaginatedList<DosingTaskViewModel>.Create(model, pageNumber ?? 1, 10);
            return View(pagedList);
        }

        [Authorize]
        public async Task<IActionResult> Create(int? productId)
        {
            var products = await _productService.GetAllProducts();
            ViewBag.Products = products;

            if (productId != null)
            {
                var productRecipes = await _productRecipeService.GetAllProductRecipes((int)productId);
                ViewBag.ProductRecipes = productRecipes;
            }
            else
            {
                ViewBag.ProductRecipes = new List<ProductRecipe>();
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(DosingTaskCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.GetProduct((int)model.ProductId);
                if (model.BatchSize < product.MinBatchSize || model.BatchSize > product.MaxBatchSize)
                {
                    ModelState.AddModelError("BatchSize", "Размер порции не входит в допустимый для продукта диапазон.");
                }
                else
                {
                    var dosingTask = _mapper.Map<DosingTask>(model);
                    dosingTask.ManufNr = await GenerateManufNr();
                    dosingTask.Priority = 0;
                    dosingTask.InProcessBatchCount = 0;
                    dosingTask.ReadyBatchCount = 0;
                    dosingTask.StartTime = DateTime.Now;
                    
                    var taskMessageId = await _taskMessageService.GetTaskMessageByCode(1);
                    dosingTask.TaskMessageId = taskMessageId.Id;

                    await _dosingTaskService.CreateDosingTask(dosingTask);
                    return RedirectToAction("Index", "DosingTask");
                }
            }

            var products = await _productService.GetAllProducts();
            ViewBag.Products = products;

            if (model.ProductId != null)
            {
                var productRecipes = await _productRecipeService.GetAllProductRecipes((int)model.ProductId);
                ViewBag.ProductRecipes = productRecipes;
            }
            else
            {
                ViewBag.ProductRecipes = new List<ProductRecipe>();
            }

            return View(model);
        }

        private async Task<int> GenerateManufNr()
        {
            var dosingTasks = await _dosingTaskService.GetAllDosingTasks();
            var lastTask = dosingTasks.Where(x => x.StartTime.Year.Equals(DateTime.Now.Year)).OrderByDescending(x => x.ManufNr).FirstOrDefault();
            var manufNr = lastTask != null ? lastTask.ManufNr + 1 : 1;
            return manufNr;
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString();
            var dosingTask = await _dosingTaskService.GetDosingTask(id);
            var model = _mapper.Map<DosingTaskViewModel>(dosingTask);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(DosingTaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dosingTask = _mapper.Map<DosingTask>(model);
                await _dosingTaskService.UpdateDosingTask(dosingTask);
                return Redirect(TempData["returnUrl"].ToString());
            }

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var taskMessages = await _taskMessageService.GetAllTaskMessages();
            var dosingTask = await _dosingTaskService.GetDosingTask(id);

            if (dosingTask.TaskMessage?.Code == 1)
            {
                await _dosingTaskService.DeleteDosingTask(dosingTask);
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}