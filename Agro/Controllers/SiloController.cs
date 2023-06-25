using Agro.DataAccess.Entities;
using Agro.Models;
using Agro.Pagination;
using Agro.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Controllers
{

    public class SiloController : Controller
    {
        private readonly ISiloService _siloService;
        private readonly IAreaService _areaService;
        private readonly IBalanceService _balanceService;
        private readonly ISiloTypeService _siloTypeService;
        private readonly IResourceService _resourceService;
        private readonly IMapper _mapper;

        public SiloController(ISiloService siloService, IAreaService areaService, IBalanceService balanceService,
            ISiloTypeService siloTypeService, IResourceService resourceService, IMapper mapper)
        {
            _siloService = siloService;
            _areaService = areaService;
            _balanceService = balanceService;
            _siloTypeService = siloTypeService;
            _resourceService = resourceService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index(int? pageNumber, string sortOrder, string filter, string resource, int? siloTypeId, int? areaId)
        {
            var areas = await _areaService.GetAllAreas();
            ViewBag.Areas = areas;

            var siloTypes = await _siloTypeService.GetAllSiloTypes();
            ViewBag.SiloTypes = siloTypes;

            var resources = await _resourceService.GetAllResources();

            var silos = await _siloService.GetAllSilos();

            if (filter != null)
                silos = silos.Where(x => x.Number.ToLower().Contains(filter.ToLower())).ToList();

            if (resource != null)
                silos = silos.Where(x => x.Resource != null ? x.Resource.ShortName.ToLower().Contains(resource.ToLower())
                || x.Resource.Name.ToLower().Contains(resource.ToLower()) : false).ToList();

            if (siloTypeId != null)
                silos = silos.Where(x => x.SiloTypeId.Equals(siloTypeId)).ToList();

            if (areaId != null)
                silos = silos.Where(x => x.AreaId.Equals(areaId)).ToList();

            ViewBag.CodeSortParam = String.IsNullOrEmpty(sortOrder) ? "code_desc" : "";
            ViewBag.NumberSortParam = sortOrder == "number_asc" ? "number_desc" : "number_asc";

            switch (sortOrder)
            {
                case "number_desc":
                    silos = silos.OrderByDescending(s => s.Number).ToList();
                    break;
                case "number_asc":
                    silos = silos.OrderBy(s => s.Number).ToList();
                    break;
                case "code_desc":
                    silos = silos.OrderByDescending(s => s.Code).ToList();
                    break;
                default:
                    silos = silos.OrderBy(s => s.Code).ToList();
                    break;
            }

            var model = _mapper.Map<IEnumerable<Silo>, IList<SiloViewModel>>(silos);
            var pagedList = PaginatedList<SiloViewModel>.Create(model, pageNumber ?? 1, 10);
            return View(pagedList);
        }

        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Create()
        {
            var areas = await _areaService.GetAllAreas();
            ViewBag.Areas = areas;

            var balances = await _balanceService.GetAllBalances();
            ViewBag.Balances = balances;

            var siloTypes = await _siloTypeService.GetAllSiloTypes();
            ViewBag.SiloTypes = siloTypes;

            var resources = await _resourceService.GetAllResources();
            ViewBag.Resources = resources;

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Create(SiloViewModel model)
        {
            if (ModelState.IsValid)
            {
                var silos = await _siloService.GetAllSilos();
                if (silos.Any(x => x.Code == model.Code))
                {
                    ModelState.AddModelError("Code", "Код повторяется.");
                }
                else
                {
                    var silo = _mapper.Map<Silo>(model);
                    silo.LastChange = DateTime.Now;
                    await _siloService.CreateSilo(silo);
                    return RedirectToAction("Index", "Silo");
                }
            }

            var areas = await _areaService.GetAllAreas();
            ViewBag.Areas = areas;

            var balances = await _balanceService.GetAllBalances();
            ViewBag.Balances = balances;

            var siloTypes = await _siloTypeService.GetAllSiloTypes();
            ViewBag.SiloTypes = siloTypes;

            var resources = await _resourceService.GetAllResources();
            ViewBag.Resources = resources;

            return View(model);
        }


        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(int id)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString();

            var areas = await _areaService.GetAllAreas();
            ViewBag.Areas = areas;

            var balances = await _balanceService.GetAllBalances();
            ViewBag.Balances = balances;

            var siloTypes = await _siloTypeService.GetAllSiloTypes();
            ViewBag.SiloTypes = siloTypes;

            var resources = await _resourceService.GetAllResources();
            ViewBag.Resources = resources;

            var silo = await _siloService.GetSilo(id);
            var model = _mapper.Map<SiloViewModel>(silo);
            TempData["previousResourceId"] = model.ResourceId;
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(SiloViewModel model)
        {
            if (ModelState.IsValid)
            {
                var silo = _mapper.Map<Silo>(model);
                silo.LastChange = DateTime.Now;
                var previousResourceId = TempData["previousResourceId"];
                
                if (!previousResourceId.Equals(silo.ResourceId))
                    silo.PreviousResourceId = previousResourceId != null ? (int)previousResourceId : null;
                
                await _siloService.UpdateSilo(silo);
                return Redirect(TempData["returnUrl"].ToString());
            }

            var areas = await _areaService.GetAllAreas();
            ViewBag.Areas = areas;

            var balances = await _balanceService.GetAllBalances();
            ViewBag.Balances = balances;

            var siloTypes = await _siloTypeService.GetAllSiloTypes();
            ViewBag.SiloTypes = siloTypes;

            var resources = await _resourceService.GetAllResources();
            ViewBag.Resources = resources;

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Watch(int id)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString();

            var areas = await _areaService.GetAllAreas();
            ViewBag.Areas = areas;

            var balances = await _balanceService.GetAllBalances();
            ViewBag.Balances = balances;

            var siloTypes = await _siloTypeService.GetAllSiloTypes();
            ViewBag.SiloTypes = siloTypes;

            var resources = await _resourceService.GetAllResources();
            ViewBag.Resources = resources;

            var silo = await _siloService.GetSilo(id);
            var model = _mapper.Map<SiloViewModel>(silo);
            TempData["previousResourceId"] = model.ResourceId;
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Delete(int id)
        {
            var silo = await _siloService.GetSilo(id);
            await _siloService.DeleteSilo(silo);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}