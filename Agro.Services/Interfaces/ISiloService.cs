using Agro.DataAccess.Entities;

namespace Agro.Services.Interfaces
{
    public interface ISiloService
    {
        Task<Silo> CreateSilo(Silo silo);
        Task<Silo> GetSilo(int id);
        Task<IList<Silo>> GetAllSilos();
        Task UpdateSilo(Silo silo);
        Task DeleteSilo(Silo silo);
    }
}
