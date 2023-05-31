using Agro.DataAccess.DbPatterns.Interfaces;
using Agro.DataAccess.Entities;
using Agro.Services.Interfaces;

namespace Agro.Services.Services
{
    public class ResourceService : ServiceConstructor, IResourceService
    {
        public ResourceService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<Resource> CreateResource(Resource resource)
        {
            return await UnitOfWork.Resources.Create(resource);
        }

        public async Task<Resource> GetResource(int id)
        {
            return await UnitOfWork.Resources.Get(id);
        }

        public async Task<IList<Resource>> GetAllResources()
        {
            IList<Resource> resources = await UnitOfWork.Resources.GetAll();
            return resources;
        }

        public async Task UpdateResource(Resource resource)
        {
            await UnitOfWork.Resources.Update(resource);
        }

        public async Task DeleteResource(Resource resource)
        {
            await UnitOfWork.Resources.Delete(resource);
        }
    }
}
