using Agro.DataAccess.DbPatterns.Interfaces;
using Agro.DataAccess.Entities;
using Agro.Services.Interfaces;

namespace Agro.Services.Services
{
    public class SiloService : ServiceConstructor, ISiloService
    {
        public SiloService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<Silo> CreateSilo(Silo silo)
        {
            return await UnitOfWork.Silos.Create(silo);
        }

        public async Task<Silo> GetSilo(int id)
        {
            return await UnitOfWork.Silos.Get(id);
        }

        public async Task<IList<Silo>> GetAllSilos()
        {
            IList<Silo> silos = await UnitOfWork.Silos.GetAll();
            return silos;
        }

        public async Task UpdateSilo(Silo silo)
        {
            await UnitOfWork.Silos.Update(silo);
        }

        public async Task DeleteSilo(Silo silo)
        {
            await UnitOfWork.Silos.Delete(silo);
        }
    }
}
