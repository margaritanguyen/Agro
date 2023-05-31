using Agro.DataAccess.DbPatterns.Interfaces;
using Agro.DataAccess.Entities;
using Agro.Services.Interfaces;

namespace Agro.Services.Services
{
    public class SiloTypeService : ServiceConstructor, ISiloTypeService
    {
        public SiloTypeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<SiloType> CreateSiloType(SiloType siloType)
        {
            return await UnitOfWork.SiloTypes.Create(siloType);
        }

        public async Task<SiloType> GetSiloType(int id)
        {
            return await UnitOfWork.SiloTypes.Get(id);
        }

        public async Task<IList<SiloType>> GetAllSiloTypes()
        {
            IList<SiloType> siloTypes = await UnitOfWork.SiloTypes.GetAll();
            return siloTypes;
        }

        public async Task UpdateSiloType(SiloType siloType)
        {
            await UnitOfWork.SiloTypes.Update(siloType);
        }

        public async Task DeleteSiloType(SiloType siloType)
        {
            await UnitOfWork.SiloTypes.Delete(siloType);
        }
    }
}
