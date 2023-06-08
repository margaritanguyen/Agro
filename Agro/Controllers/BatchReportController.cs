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
            
            //if (filter != null)
            //    batchReports = batchReports.Where(x => x.Name.ToLower().Contains(filter.ToLower())).ToList();

            //ViewBag.CodeSortParam = String.IsNullOrEmpty(sortOrder) ? "code_desc" : "";
            //ViewBag.NameSortParam = sortOrder == "name_asc" ? "name_desc" : "name_asc";

            //switch (sortOrder)
            //{
            //    case "name_desc":
            //        batchReports = batchReports.OrderByDescending(s => s.Name).ToList();
            //        break;
            //    case "name_asc":
            //        batchReports = batchReports.OrderBy(s => s.Name).ToList();
            //        break;
            //    case "code_desc":
            //        batchReports = batchReports.OrderByDescending(s => s.Code).ToList();
            //        break;
            //    default:
            //        batchReports = batchReports.OrderBy(s => s.Code).ToList();
            //        break;
            //}
            
            var model = _mapper.Map<IEnumerable<BatchReport>, IList<BatchReportViewModel>>(batchReports);
            var pagedList = PaginatedList<BatchReportViewModel>.Create(model, pageNumber ?? 1, 10);
            return View(pagedList);
        }
    }
}