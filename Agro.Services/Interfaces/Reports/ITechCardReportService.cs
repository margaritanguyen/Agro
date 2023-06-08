using Agro.DataAccess.Entities;

namespace Agro.Services.Interfaces
{
    public interface ITechCardReportService
    {
        Task<IList<TechCardReport>> GetAllTechCardReports(int dosingTaskId, int batchNum);
    }
}
