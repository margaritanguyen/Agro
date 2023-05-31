using Agro.DataAccess.Entities;
using Agro.Models;
using Agro.Pagination;
using Agro.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Controllers
{

    public class ResourceTypeController : Controller
    {
        private readonly IResourceTypeService _resourceTypeService;
        private readonly IMapper _mapper;

        public ResourceTypeController(IResourceTypeService resourceTypeService, IMapper mapper)
        {
            _resourceTypeService = resourceTypeService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index(int? pageNumber, string sortOrder, string filter)
        {
            var resourceTypes = await _resourceTypeService.GetAllResourceTypes();

            if (filter != null)
                resourceTypes = resourceTypes.Where(x => x.Name.ToLower().Contains(filter.ToLower())).ToList();

            ViewBag.CodeSortParam = String.IsNullOrEmpty(sortOrder) ? "code_desc" : "";
            ViewBag.NameSortParam = sortOrder == "name_asc" ? "name_desc" : "name_asc";

            switch (sortOrder)
            {
                case "name_desc":
                    resourceTypes = resourceTypes.OrderByDescending(s => s.Name).ToList();
                    break;
                case "name_asc":
                    resourceTypes = resourceTypes.OrderBy(s => s.Name).ToList();
                    break;
                case "code_desc":
                    resourceTypes = resourceTypes.OrderByDescending(s => s.Code).ToList();
                    break;
                default:
                    resourceTypes = resourceTypes.OrderBy(s => s.Code).ToList();
                    break;
            }

            var model = _mapper.Map<IEnumerable<ResourceType>, IList<ResourceTypeViewModel>>(resourceTypes);
            var pagedList = PaginatedList<ResourceTypeViewModel>.Create(model, pageNumber ?? 1, 10);
            return View(pagedList);
        }

        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Create(ResourceTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var resourceTypes = await _resourceTypeService.GetAllResourceTypes();
                
                if (resourceTypes.Any(x => x.Code == model.Code))
                {
                    ModelState.AddModelError("Code", "Код повторяется.");
                }
                else
                {
                    var resourceType = _mapper.Map<ResourceType>(model);
                    await _resourceTypeService.CreateResourceType(resourceType);
                    return RedirectToAction("Index", "ResourceType");
                }
            }
            
            return View(model);
        }

        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(int id)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString(); 
            var resourceType = await _resourceTypeService.GetResourceType(id);
            var model = _mapper.Map<ResourceTypeViewModel>(resourceType);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(ResourceTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var resourceType = _mapper.Map<ResourceType>(model);
                await _resourceTypeService.UpdateResourceType(resourceType);
                return Redirect(TempData["returnUrl"].ToString());
            }
            
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Delete(int id)
        {
            var resourceType = await _resourceTypeService.GetResourceType(id);
            await _resourceTypeService.DeleteResourceType(resourceType);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}