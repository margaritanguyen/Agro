using Agro.DataAccess.DbPatterns.Interfaces;
using Agro.DataAccess.Entities;
using Agro.Services.Interfaces;

namespace Agro.Services.Services
{
    public class TechCardReportService : ServiceConstructor, ITechCardReportService
    {
        public TechCardReportService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IList<TechCardReport>> GetAllTechCardReports(int dosingTaskId, int batchNum)
        {
            IList<TechCardReport> batchReports = await UnitOfWork.TechCardReports.GetAll();
            return batchReports.Where(x => x.DosingTaskId == dosingTaskId && x.BatchNum == batchNum).ToList();
        }
    }
}
