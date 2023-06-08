using Agro.DataAccess.Entities;
using Agro.Models;
using Agro.Pagination;
using Agro.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Web;

namespace Agro.Controllers
{

    public class TechCardReportController : Controller
    {
        private readonly ITechCardReportService _techCardReportService;
        private readonly IMapper _mapper;

        public TechCardReportController(ITechCardReportService techCardReportService, IMapper mapper)
        {
            _techCardReportService = techCardReportService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index(int dosingTaskId, int batchNum)
        {
            var techCardReports = await _techCardReportService.GetAllTechCardReports(dosingTaskId, batchNum);
            var model = _mapper.Map<IEnumerable<TechCardReport>, IList<TechCardReportViewModel>>(techCardReports);
            return View(model);
        }
    }
}