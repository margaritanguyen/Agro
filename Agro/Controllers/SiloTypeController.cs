using Agro.DataAccess.Entities;
using Agro.Models;
using Agro.Pagination;
using Agro.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Controllers
{

    public class SiloTypeController : Controller
    {
        private readonly ISiloTypeService _siloTypeService;
        private readonly IMapper _mapper;

        public SiloTypeController(ISiloTypeService siloTypeService, IMapper mapper)
        {
            _siloTypeService = siloTypeService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index(int? pageNumber, string sortOrder, string filter)
        {
            var siloTypes = await _siloTypeService.GetAllSiloTypes();

            if (filter != null)
                siloTypes = siloTypes.Where(x => x.Name.ToLower().Contains(filter.ToLower())).ToList();

            ViewBag.CodeSortParam = String.IsNullOrEmpty(sortOrder) ? "code_desc" : "";
            ViewBag.NameSortParam = sortOrder == "name_asc" ? "name_desc" : "name_asc";

            switch (sortOrder)
            {
                case "name_desc":
                    siloTypes = siloTypes.OrderByDescending(s => s.Name).ToList();
                    break;
                case "name_asc":
                    siloTypes = siloTypes.OrderBy(s => s.Name).ToList();
                    break;
                case "code_desc":
                    siloTypes = siloTypes.OrderByDescending(s => s.Code).ToList();
                    break;
                default:
                    siloTypes = siloTypes.OrderBy(s => s.Code).ToList();
                    break;
            }

            var model = _mapper.Map<IEnumerable<SiloType>, IList<SiloTypeViewModel>>(siloTypes);
            var pagedList = PaginatedList<SiloTypeViewModel>.Create(model, pageNumber ?? 1, 10);
            return View(pagedList);
        }

        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Create(SiloTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var siloTypes = await _siloTypeService.GetAllSiloTypes();
                
                if (siloTypes.Any(x => x.Code == model.Code))
                {
                    ModelState.AddModelError("Code", "Код повторяется.");
                }
                else
                {
                    var siloType = _mapper.Map<SiloType>(model);
                    await _siloTypeService.CreateSiloType(siloType);
                    return RedirectToAction("Index", "SiloType");
                }
            }
            
            return View(model);
        }

        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(int id)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString(); 
            var siloType = await _siloTypeService.GetSiloType(id);
            var model = _mapper.Map<SiloTypeViewModel>(siloType);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(SiloTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var siloType = _mapper.Map<SiloType>(model);
                await _siloTypeService.UpdateSiloType(siloType);
                return Redirect(TempData["returnUrl"].ToString());
            }
            
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Delete(int id)
        {
            var siloType = await _siloTypeService.GetSiloType(id);
            await _siloTypeService.DeleteSiloType(siloType);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}