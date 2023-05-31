using Agro.DataAccess.Entities;
using Agro.Models;
using Agro.Pagination;
using Agro.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Controllers
{

    public class BalanceController : Controller
    {
        private readonly IBalanceService _balanceService;
        private readonly IAreaService _areaService;
        private readonly IMapper _mapper;

        public BalanceController(IBalanceService balanceService, IAreaService areaService, IMapper mapper)
        {
            _balanceService = balanceService;
            _areaService = areaService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index(int? pageNumber, string sortOrder, string filter, int? areaId)
        {
            var areas = await _areaService.GetAllAreas();
            ViewBag.Areas = areas;

            var balances = await _balanceService.GetAllBalances();

            if (filter != null)
                balances = balances.Where(x => x.Name.ToLower().Contains(filter.ToLower())).ToList();

            if (areaId != null)
                balances = balances.Where(x => x.AreaId.Equals(areaId)).ToList();

            ViewBag.CodeSortParam = String.IsNullOrEmpty(sortOrder) ? "code_desc" : "";
            ViewBag.NumberSortParam = sortOrder == "name_asc" ? "name_desc" : "name_asc";

            switch (sortOrder)
            {
                case "name_desc":
                    balances = balances.OrderByDescending(s => s.Name).ToList();
                    break;
                case "name_asc":
                    balances = balances.OrderBy(s => s.Name).ToList();
                    break;
                case "code_desc":
                    balances = balances.OrderByDescending(s => s.Code).ToList();
                    break;
                default:
                    balances = balances.OrderBy(s => s.Code).ToList();
                    break;
            }

            var model = _mapper.Map<IEnumerable<Balance>, IList<BalanceViewModel>>(balances);
            var pagedList = PaginatedList<BalanceViewModel>.Create(model, pageNumber ?? 1, 10);
            return View(pagedList);
        }

        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Create()
        {
            var areas = await _areaService.GetAllAreas();
            ViewBag.Areas = areas;

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Create(BalanceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var balances = await _balanceService.GetAllBalances();
                if (balances.Any(x => x.Code == model.Code))
                {
                    ModelState.AddModelError("Code", "Код повторяется.");
                }
                else
                {
                    var balance = _mapper.Map<Balance>(model);
                    balance.LastChange = DateTime.Now;
                    await _balanceService.CreateBalance(balance);
                    return RedirectToAction("Index", "Balance");
                }
            }

            var areas = await _areaService.GetAllAreas();
            ViewBag.Areas = areas;

            return View(model);
        }


        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(int id)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString();

            var areas = await _areaService.GetAllAreas();
            ViewBag.Areas = areas;

            var balance = await _balanceService.GetBalance(id);
            var model = _mapper.Map<BalanceViewModel>(balance);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Edit(BalanceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var balance = _mapper.Map<Balance>(model);
                balance.LastChange = DateTime.Now;
                await _balanceService.UpdateBalance(balance);
                return Redirect(TempData["returnUrl"].ToString());
            }

            var areas = await _areaService.GetAllAreas();
            ViewBag.Areas = areas;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор,Технолог,Инженер")]
        public async Task<IActionResult> Delete(int id)
        {
            var balance = await _balanceService.GetBalance(id);
            await _balanceService.DeleteBalance(balance);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}