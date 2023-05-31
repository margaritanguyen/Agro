using Agro.DataAccess.Entities;
using Agro.Models;
using Agro.Pagination;
using Agro.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Controllers
{

    public class DosingTypeController : Controller
    {
        private readonly IDosingTypeService _dosingTypeService;
        private readonly IMapper _mapper;

        public DosingTypeController(IDosingTypeService dosingTypeService, IMapper mapper)
        {
            _dosingTypeService = dosingTypeService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index(int? pageNumber, string sortOrder, string filter)
        {
            var dosingTypes = await _dosingTypeService.GetAllDosingTypes();

            if (filter != null)
                dosingTypes = dosingTypes.Where(x => x.Name.ToLower().Contains(filter.ToLower())).ToList();

            ViewBag.CodeSortParam = String.IsNullOrEmpty(sortOrder) ? "code_desc" : "";
            ViewBag.NameSortParam = sortOrder == "name_asc" ? "name_desc" : "name_asc";

            switch (sortOrder)
            {
                case "name_desc":
                    dosingTypes = dosingTypes.OrderByDescending(s => s.Name).ToList();
                    break;
                case "name_asc":
                    dosingTypes = dosingTypes.OrderBy(s => s.Name).ToList();
                    break;
                case "code_desc":
                    dosingTypes = dosingTypes.OrderByDescending(s => s.Code).ToList();
                    break;
                default:
                    dosingTypes = dosingTypes.OrderBy(s => s.Code).ToList();
                    break;
            }

            var model = _mapper.Map<IEnumerable<DosingType>, IList<DosingTypeViewModel>>(dosingTypes);
            var pagedList = PaginatedList<DosingTypeViewModel>.Create(model, pageNumber ?? 1, 10);
            return View(pagedList);
        }

        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Create(DosingTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dosingTypes = await _dosingTypeService.GetAllDosingTypes();
                
                if (dosingTypes.Any(x => x.Code == model.Code))
                {
                    ModelState.AddModelError("Code", "Код повторяется.");
                }
                else
                {
                    var dosingType = _mapper.Map<DosingType>(model);
                    await _dosingTypeService.CreateDosingType(dosingType);
                    return RedirectToAction("Index", "DosingType");
                }
            }
            
            return View(model);
        }

        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(int id)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString(); 
            var dosingType = await _dosingTypeService.GetDosingType(id);
            var model = _mapper.Map<DosingTypeViewModel>(dosingType);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(DosingTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dosingType = _mapper.Map<DosingType>(model);
                await _dosingTypeService.UpdateDosingType(dosingType);
                return Redirect(TempData["returnUrl"].ToString());
            }
            
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Delete(int id)
        {
            var dosingType = await _dosingTypeService.GetDosingType(id);
            await _dosingTypeService.DeleteDosingType(dosingType);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}