using Agro.DataAccess.Entities;
using Agro.Models;
using Agro.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Agro.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDosingTaskService _dosingTaskService;
        private readonly IProductService _productService;
        private readonly IProductRecipeService _productRecipeService;
        private readonly ITaskMessageService _taskMessageService;
        private readonly IMapper _mapper;

        public HomeController(IDosingTaskService dosingTaskService, IProductService productService,
            IProductRecipeService productRecipeService, ITaskMessageService taskMessageService, IMapper mapper)
        {
            _dosingTaskService = dosingTaskService;
            _productService = productService;
            _productRecipeService = productRecipeService;
            _taskMessageService = taskMessageService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetData()
        {
            var taskMessages = await _taskMessageService.GetAllTaskMessages();
            var productRecipes = await _productRecipeService.GetAllProductRecipes();
            var products = await _productService.GetAllProducts();
            var currentDosingTasks = await _dosingTaskService.GetCurrentDosingTasks();
            var model = _mapper.Map<IEnumerable<DosingTask>, IList<CurrentStateViewModel>>(currentDosingTasks);
            return PartialView("_CurrentState", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}