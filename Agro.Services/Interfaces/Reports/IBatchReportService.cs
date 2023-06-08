using Agro.DataAccess.Entities;

namespace Agro.Services.Interfaces
{
    public interface IBatchReportService
    {
        Task<IList<BatchReport>> GetAllBatchReports();
    }
}
