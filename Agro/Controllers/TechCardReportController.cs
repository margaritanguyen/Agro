using Agro.DataAccess.Entities;
using Agro.Models;
using Agro.Services.Interfaces;
using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        [Authorize]
        public FileResult Export(IList<TechCardReportViewModel> model)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                var workSheet = wb.Worksheets.Add();
                workSheet.Cell(0, 0).Value = "Технологическая карта";
                workSheet.Cell(1, 0).Value = $"Номер заказа: {model.Max(x => x.ManufNr)}";
                workSheet.Cell(2, 0).Value = $"Продукт: {model.Max(x => x.ProductName)}";

                workSheet.Cell(4, 0).Value = "№";
                workSheet.Cell(4, 1).Value = "Сырье";
                workSheet.Cell(4, 2).Value = "Заданный вес, кг";
                workSheet.Cell(4, 3).Value = "Отдозированный вес, кг";
                workSheet.Cell(4, 4).Value = "Отклонение, кг";
                workSheet.Cell(4, 5).Value = "Начало дозирования";
                workSheet.Cell(4, 6).Value = "Конец дозирования";

                for (int i = 0; i < model.Count; i++)
                {
                    workSheet.Cell(i + 5, 0).Value = $"{model[i].Num}";
                    workSheet.Cell(i + 5, 1).Value = $"{model[i].ResourceName}";
                    workSheet.Cell(i + 5, 2).Value = $"{model[i].ReqWeight.ToString("F2")}";
                    workSheet.Cell(i + 5, 3).Value = $"{model[i].RealWeight.ToString("F2")}";
                    workSheet.Cell(i + 5, 4).Value = $"{(model[i].RealWeight - model[i].ReqWeight).ToString("F2")}";
                    workSheet.Cell(i + 5, 5).Value = $"{model[i].StartTime}";
                    workSheet.Cell(i + 5, 6).Value = $"{model[i].EndTime}";
                }

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TechCard.xlsx");
                }
            }
        }
    }
}