using Agro.DataAccess.Entities;

namespace Agro.Services.Interfaces
{
    public interface ISiloTypeService
    {
        Task<SiloType> CreateSiloType(SiloType siloType);
        Task<SiloType> GetSiloType(int id);
        Task<IList<SiloType>> GetAllSiloTypes();
        Task UpdateSiloType(SiloType siloType);
        Task DeleteSiloType(SiloType siloType);
    }
}
