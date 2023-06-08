using Agro.DataAccess.DbPatterns.Interfaces;
using Agro.DataAccess.Entities;
using Agro.Services.Interfaces;

namespace Agro.Services.Services
{
    public class BatchReportService : ServiceConstructor, IBatchReportService
    {
        public BatchReportService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IList<BatchReport>> GetAllBatchReports()
        {
            IList<BatchReport> batchReports = await UnitOfWork.BatchReports.GetAll();
            return batchReports;
        }
    }
}
