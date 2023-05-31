using Agro.DataAccess.DbPatterns.Interfaces;
using Agro.DataAccess.Entities;
using Agro.Services.Interfaces;

namespace Agro.Services.Services
{
    public class DosingTypeService : ServiceConstructor, IDosingTypeService
    {
        public DosingTypeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<DosingType> CreateDosingType(DosingType dosingType)
        {
            return await UnitOfWork.DosingTypes.Create(dosingType);
        }

        public async Task<DosingType> GetDosingType(int id)
        {
            return await UnitOfWork.DosingTypes.Get(id);
        }

        public async Task<IList<DosingType>> GetAllDosingTypes()
        {
            IList<DosingType> dosingTypes = await UnitOfWork.DosingTypes.GetAll();
            return dosingTypes;
        }

        public async Task UpdateDosingType(DosingType dosingType)
        {
            await UnitOfWork.DosingTypes.Update(dosingType);
        }

        public async Task DeleteDosingType(DosingType dosingType)
        {
            await UnitOfWork.DosingTypes.Delete(dosingType);
        }
    }
}
