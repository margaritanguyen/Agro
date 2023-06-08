using Agro.DataAccess.Entities;
using Agro.Models;
using Agro.Pagination;
using Agro.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Controllers
{

    public class ArchiveMessageController : Controller
    {
        private readonly IArchiveMessageService _archiveMessageService;
        private readonly IMapper _mapper;

        public ArchiveMessageController(IArchiveMessageService archiveMessageService, IMapper mapper)
        {
            _archiveMessageService = archiveMessageService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index(int? pageNumber, string sortOrder, string filter)
        {
            var archiveMessages = await _archiveMessageService.GetAllArchiveMessages();

            if (filter != null)
                archiveMessages = archiveMessages.Where(x => x.Message.ToLower().Contains(filter.ToLower())).ToList();

            ViewBag.CodeSortParam = String.IsNullOrEmpty(sortOrder) ? "code_desc" : "";
            ViewBag.MessageSortParam = sortOrder == "message_asc" ? "message_desc" : "message_asc";

            switch (sortOrder)
            {
                case "message_desc":
                    archiveMessages = archiveMessages.OrderByDescending(s => s.Message).ToList();
                    break;
                case "message_asc":
                    archiveMessages = archiveMessages.OrderBy(s => s.Message).ToList();
                    break;
                case "code_desc":
                    archiveMessages = archiveMessages.OrderByDescending(s => s.Code).ToList();
                    break;
                default:
                    archiveMessages = archiveMessages.OrderBy(s => s.Code).ToList();
                    break;
            }

            var model = _mapper.Map<IEnumerable<ArchiveMessage>, IList<ArchiveMessageViewModel>>(archiveMessages);
            var pagedList = PaginatedList<ArchiveMessageViewModel>.Create(model, pageNumber ?? 1, 10);
            return View(pagedList);
        }

        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Create(ArchiveMessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var archiveMessages = await _archiveMessageService.GetAllArchiveMessages();

                if (archiveMessages.Any(x => x.Code == model.Code))
                {
                    ModelState.AddModelError("Code", "Код повторяется.");
                }
                else
                {
                    var archiveMessage = _mapper.Map<ArchiveMessage>(model);
                    await _archiveMessageService.CreateArchiveMessage(archiveMessage);
                    return RedirectToAction("Index", "ArchiveMessage");
                }
            }

            return View(model);
        }

        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(int id)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString();
            var archiveMessage = await _archiveMessageService.GetArchiveMessage(id);
            var model = _mapper.Map<ArchiveMessageViewModel>(archiveMessage);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(ArchiveMessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var archiveMessage = _mapper.Map<ArchiveMessage>(model);
                await _archiveMessageService.UpdateArchiveMessage(archiveMessage);
                return Redirect(TempData["returnUrl"].ToString());
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Delete(int id)
        {
            var archiveMessage = await _archiveMessageService.GetArchiveMessage(id);
            await _archiveMessageService.DeleteArchiveMessage(archiveMessage);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}