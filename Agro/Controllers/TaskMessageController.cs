using Agro.DataAccess.Entities;
using Agro.Models;
using Agro.Pagination;
using Agro.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Controllers
{

    public class TaskMessageController : Controller
    {
        private readonly ITaskMessageService _taskMessageService;
        private readonly IMapper _mapper;

        public TaskMessageController(ITaskMessageService taskMessageService, IMapper mapper)
        {
            _taskMessageService = taskMessageService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index(int? pageNumber, string sortOrder, string filter)
        {
            var taskMessages = await _taskMessageService.GetAllTaskMessages();

            if (filter != null)
                taskMessages = taskMessages.Where(x => x.Message.ToLower().Contains(filter.ToLower())).ToList();

            ViewBag.CodeSortParam = String.IsNullOrEmpty(sortOrder) ? "code_desc" : "";
            ViewBag.MessageSortParam = sortOrder == "message_asc" ? "message_desc" : "message_asc";

            switch (sortOrder)
            {
                case "message_desc":
                    taskMessages = taskMessages.OrderByDescending(s => s.Message).ToList();
                    break;
                case "message_asc":
                    taskMessages = taskMessages.OrderBy(s => s.Message).ToList();
                    break;
                case "code_desc":
                    taskMessages = taskMessages.OrderByDescending(s => s.Code).ToList();
                    break;
                default:
                    taskMessages = taskMessages.OrderBy(s => s.Code).ToList();
                    break;
            }

            var model = _mapper.Map<IEnumerable<TaskMessage>, IList<TaskMessageViewModel>>(taskMessages);
            var pagedList = PaginatedList<TaskMessageViewModel>.Create(model, pageNumber ?? 1, 10);
            return View(pagedList);
        }

        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Create(TaskMessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var taskMessages = await _taskMessageService.GetAllTaskMessages();

                if (taskMessages.Any(x => x.Code == model.Code))
                {
                    ModelState.AddModelError("Code", "Код повторяется.");
                }
                else
                {
                    var taskMessage = _mapper.Map<TaskMessage>(model);
                    await _taskMessageService.CreateTaskMessage(taskMessage);
                    return RedirectToAction("Index", "TaskMessage");
                }
            }

            return View(model);
        }

        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(int id)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString();
            var taskMessage = await _taskMessageService.GetTaskMessage(id);
            var model = _mapper.Map<TaskMessageViewModel>(taskMessage);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(TaskMessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var taskMessage = _mapper.Map<TaskMessage>(model);
                await _taskMessageService.UpdateTaskMessage(taskMessage);
                return Redirect(TempData["returnUrl"].ToString());
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Delete(int id)
        {
            var taskMessage = await _taskMessageService.GetTaskMessage(id);
            await _taskMessageService.DeleteTaskMessage(taskMessage);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}