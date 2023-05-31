using Agro.DataAccess.DbPatterns.Interfaces;
using Agro.DataAccess.Entities;
using Agro.Services.Interfaces;

namespace Agro.Services.Services
{
    public class AreaService : ServiceConstructor, IAreaService
    {
        public AreaService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<Area> CreateArea(Area area)
        {
            return await UnitOfWork.Areas.Create(area);
        }

        public async Task<Area> GetArea(int id)
        {
            return await UnitOfWork.Areas.Get(id);
        }

        public async Task<IList<Area>> GetAllAreas()
        {
            IList<Area> areas = await UnitOfWork.Areas.GetAll();
            return areas;
        }

        public async Task UpdateArea(Area area)
        {
            await UnitOfWork.Areas.Update(area);
        }

        public async Task DeleteArea(Area area)
        {
            await UnitOfWork.Areas.Delete(area);
        }
    }
}
