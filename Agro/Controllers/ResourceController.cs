using Agro.DataAccess.Entities;
using Agro.Models;
using Agro.Pagination;
using Agro.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Controllers
{

    public class ResourceController : Controller
    {
        private readonly IResourceService _resourceService;
        private readonly IResourceTypeService _resourceTypeService;
        private readonly IDosingTypeService _dosingTypeService;
        private readonly IMapper _mapper;

        public ResourceController(IResourceService resourceService, IResourceTypeService resourceTypeService, IDosingTypeService dosingTypeService, IMapper mapper)
        {
            _resourceService = resourceService;
            _resourceTypeService = resourceTypeService;
            _dosingTypeService = dosingTypeService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index(int? pageNumber, string sortOrder, string filter, int? resourceTypeId, int? dosingTypeId)
        {
            var dosingTypes = await _dosingTypeService.GetAllDosingTypes();
            ViewBag.DosingTypes = dosingTypes;

            var resourceTypes = await _resourceTypeService.GetAllResourceTypes();
            ViewBag.ResourceTypes = resourceTypes;

            var resources = await _resourceService.GetAllResources();

            if (filter != null)
                resources = resources.Where(x => x.Name.ToLower().Contains(filter.ToLower())
                || x.ShortName.ToLower().Contains(filter.ToLower())).ToList();

            if (resourceTypeId != null)
                resources = resources.Where(x => x.ResourceTypeId.Equals(resourceTypeId)).ToList();

            if (dosingTypeId != null)
                resources = resources.Where(x => x.DosingTypeId.Equals(dosingTypeId)).ToList();

            ViewBag.CodeSortParam = String.IsNullOrEmpty(sortOrder) ? "code_desc" : "";
            ViewBag.ShortNameSortParam = sortOrder == "shortName_asc" ? "shortName_desc" : "shortName_asc";

            switch (sortOrder)
            {
                case "shortName_desc":
                    resources = resources.OrderByDescending(s => s.ShortName).ToList();
                    break;
                case "shortName_asc":
                    resources = resources.OrderBy(s => s.ShortName).ToList();
                    break;
                case "code_desc":
                    resources = resources.OrderByDescending(s => s.Code).ToList();
                    break;
                default:
                    resources = resources.OrderBy(s => s.Code).ToList();
                    break;
            }

            var model = _mapper.Map<IEnumerable<Resource>, IList<ResourceViewModel>>(resources);
            var pagedList = PaginatedList<ResourceViewModel>.Create(model, pageNumber ?? 1, 10);
            return View(pagedList);
        }

        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Create()
        {
            var dosingTypes = await _dosingTypeService.GetAllDosingTypes();
            ViewBag.DosingTypes = dosingTypes;

            var resourceTypes = await _resourceTypeService.GetAllResourceTypes();
            ViewBag.ResourceTypes = resourceTypes;
            
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Create(ResourceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var resources = await _resourceService.GetAllResources();
                if (resources.Any(x => x.Code == model.Code))
                {
                    ModelState.AddModelError("Code", "Код повторяется.");
                }
                else
                {
                    var resource = _mapper.Map<Resource>(model);
                    resource.LastChange = DateTime.Now;
                    await _resourceService.CreateResource(resource);
                    return RedirectToAction("Index", "Resource");
                }
            }

            var dosingTypes = await _dosingTypeService.GetAllDosingTypes();
            ViewBag.DosingTypes = dosingTypes;
            
            var resourceTypes = await _resourceTypeService.GetAllResourceTypes();
            ViewBag.ResourceTypes = resourceTypes;
            
            return View(model);
        }


        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(int id)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString();

            var dosingTypes = await _dosingTypeService.GetAllDosingTypes();
            ViewBag.DosingTypes = dosingTypes;

            var resourceTypes = await _resourceTypeService.GetAllResourceTypes();
            ViewBag.ResourceTypes = resourceTypes;

            var resource = await _resourceService.GetResource(id);
            var model = _mapper.Map<ResourceViewModel>(resource);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(ResourceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var resource = _mapper.Map<Resource>(model);
                resource.LastChange = DateTime.Now;
                await _resourceService.UpdateResource(resource);
                return Redirect(TempData["returnUrl"].ToString());
            }

            var dosingTypes = await _dosingTypeService.GetAllDosingTypes();
            ViewBag.DosingTypes = dosingTypes;

            var resourceTypes = await _resourceTypeService.GetAllResourceTypes();
            ViewBag.ResourceTypes = resourceTypes;
            
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Watch(int id)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString();

            var dosingTypes = await _dosingTypeService.GetAllDosingTypes();
            ViewBag.DosingTypes = dosingTypes;

            var resourceTypes = await _resourceTypeService.GetAllResourceTypes();
            ViewBag.ResourceTypes = resourceTypes;

            var resource = await _resourceService.GetResource(id);
            var model = _mapper.Map<ResourceViewModel>(resource);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Delete(int id)
        {
            var resource = await _resourceService.GetResource(id);
            await _resourceService.DeleteResource(resource);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}