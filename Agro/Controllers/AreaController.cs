using Agro.DataAccess.Entities;
using Agro.Models;
using Agro.Pagination;
using Agro.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AreaController : Controller
    {
        private readonly IAreaService _areaService;
        private readonly IMapper _mapper;

        public AreaController(IAreaService areaService, IMapper mapper)
        {
            _areaService = areaService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index(int? pageNumber, string sortOrder, string filter)
        {
            var areas = await _areaService.GetAllAreas();
            
            if (filter != null)
                areas = areas.Where(x => x.Name.ToLower().Contains(filter.ToLower())).ToList();

            ViewBag.CodeSortParam = String.IsNullOrEmpty(sortOrder) ? "code_desc" : "";
            ViewBag.NameSortParam = sortOrder == "name_asc" ? "name_desc" : "name_asc";

            switch (sortOrder)
            {
                case "name_desc":
                    areas = areas.OrderByDescending(s => s.Name).ToList();
                    break;
                case "name_asc":
                    areas = areas.OrderBy(s => s.Name).ToList();
                    break;
                case "code_desc":
                    areas = areas.OrderByDescending(s => s.Code).ToList();
                    break;
                default:
                    areas = areas.OrderBy(s => s.Code).ToList();
                    break;
            }
            
            var model = _mapper.Map<IEnumerable<Area>, IList<AreaViewModel>>(areas);
            var pagedList = PaginatedList<AreaViewModel>.Create(model, pageNumber ?? 1, 10);
            return View(pagedList);
        }

        [HttpGet]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Create(AreaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var areas = await _areaService.GetAllAreas();
                
                if (areas.Any(x => x.Code == model.Code))
                {
                    ModelState.AddModelError("Code", "Код повторяется.");
                }
                else
                {
                    var area = _mapper.Map<Area>(model);
                    await _areaService.CreateArea(area);
                    return RedirectToAction("Index", "Area");
                }
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(int id)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString(); 
            var area = await _areaService.GetArea(id);
            var model = _mapper.Map<AreaViewModel>(area);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(AreaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var area = _mapper.Map<Area>(model);
                await _areaService.UpdateArea(area);
                return Redirect(TempData["returnUrl"].ToString());
            }
            
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Delete(int id)
        {
            var area = await _areaService.GetArea(id);
            await _areaService.DeleteArea(area);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}