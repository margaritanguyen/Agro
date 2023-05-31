using Agro.DataAccess.Entities;
using Agro.Models;
using Agro.Pagination;
using Agro.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Controllers
{

    public class AnimalGroupController : Controller
    {
        private readonly IAnimalGroupService _animalGroupService;
        private readonly IMapper _mapper;

        public AnimalGroupController(IAnimalGroupService animalGroupService, IMapper mapper)
        {
            _animalGroupService = animalGroupService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index(int? pageNumber, string sortOrder, string filter)
        {
            var animalGroups = await _animalGroupService.GetAllAnimalGroups();

            if (filter != null)
                animalGroups = animalGroups.Where(x => x.Name.ToLower().Contains(filter.ToLower())).ToList();

            ViewBag.CodeSortParam = String.IsNullOrEmpty(sortOrder) ? "code_desc" : "";
            ViewBag.NameSortParam = sortOrder == "name_asc" ? "name_desc" : "name_asc";

            switch (sortOrder)
            {
                case "name_desc":
                    animalGroups = animalGroups.OrderByDescending(s => s.Name).ToList();
                    break;
                case "name_asc":
                    animalGroups = animalGroups.OrderBy(s => s.Name).ToList();
                    break;
                case "code_desc":
                    animalGroups = animalGroups.OrderByDescending(s => s.Code).ToList();
                    break;
                default:
                    animalGroups = animalGroups.OrderBy(s => s.Code).ToList();
                    break;
            }

            var model = _mapper.Map<IEnumerable<AnimalGroup>, IList<AnimalGroupViewModel>>(animalGroups);
            var pagedList = PaginatedList<AnimalGroupViewModel>.Create(model, pageNumber ?? 1, 10);
            return View(pagedList);
        }

        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Create(AnimalGroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var animalGroups = await _animalGroupService.GetAllAnimalGroups();
                
                if (animalGroups.Any(x => x.Code == model.Code))
                {
                    ModelState.AddModelError("Code", "Код повторяется.");
                }
                else
                {
                    var animalGroup = _mapper.Map<AnimalGroup>(model);
                    await _animalGroupService.CreateAnimalGroup(animalGroup);
                    return RedirectToAction("Index", "AnimalGroup");
                }
            }
            
            return View(model);
        }

        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(int id)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString(); 
            var animalGroup = await _animalGroupService.GetAnimalGroup(id);
            var model = _mapper.Map<AnimalGroupViewModel>(animalGroup);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(AnimalGroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var animalGroup = _mapper.Map<AnimalGroup>(model);
                await _animalGroupService.UpdateAnimalGroup(animalGroup);
                return Redirect(TempData["returnUrl"].ToString());
            }
            
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Delete(int id)
        {
            var animalGroup = await _animalGroupService.GetAnimalGroup(id);
            await _animalGroupService.DeleteAnimalGroup(animalGroup);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}