using Agro.DataAccess.Entities;
using Agro.Models;
using Agro.Pagination;
using Agro.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Controllers
{

    public class BatchReportController : Controller
    {
        private readonly IBatchReportService _batchReportService;
        private readonly IMapper _mapper;

        public BatchReportController(IBatchReportService batchReportService, IMapper mapper)
        {
            _batchReportService = batchReportService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index(int? pageNumber, string sortOrder, string filter)
        {
            var batchReports = await _batchReportService.GetAllBatchReports();

            if (filter != null)
                batchReports = batchReports.Where(x => x.ManufNr.ToString().ToLower().Contains(filter.ToLower())
                || x.ProductName.ToLower().Contains(filter.ToLower())).ToList();

            ViewBag.ManufNrSortParam = String.IsNullOrEmpty(sortOrder) ? "manufnr_desc" : "";
            ViewBag.StartTimeSortParam = sortOrder == "starttime_asc" ? "starttime_desc" : "starttime_asc";
            ViewBag.EndTimeSortParam = sortOrder == "endtime_asc" ? "endtime_desc" : "endtime_asc";

            switch (sortOrder)
            {
                case "starttime_desc":
                    batchReports = batchReports.OrderByDescending(s => s.StartTime).ToList();
                    break;
                case "starttime_asc":
                    batchReports = batchReports.OrderBy(s => s.StartTime).ToList();
                    break;
                case "endtime_desc":
                    batchReports = batchReports.OrderByDescending(s => s.EndTime).ToList();
                    break;
                case "endtime_asc":
                    batchReports = batchReports.OrderBy(s => s.EndTime).ToList();
                    break;
                case "manufnr_desc":
                    batchReports = batchReports.OrderByDescending(s => s.ManufNr).ToList();
                    break;
                default:
                    batchReports = batchReports.OrderBy(s => s.ManufNr).ToList();
                    break;
            }

            var model = _mapper.Map<IEnumerable<BatchReport>, IList<BatchReportViewModel>>(batchReports);
            var pagedList = PaginatedList<BatchReportViewModel>.Create(model, pageNumber ?? 1, 10);
            return View(pagedList);
        }
    }
}