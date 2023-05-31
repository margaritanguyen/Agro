using Agro.DataAccess.DbPatterns.Interfaces;
using Agro.DataAccess.Entities;
using Agro.Services.Interfaces;

namespace Agro.Services.Services
{
    public class ResourceTypeService : ServiceConstructor, IResourceTypeService
    {
        public ResourceTypeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<ResourceType> CreateResourceType(ResourceType resourceType)
        {
            return await UnitOfWork.ResourceTypes.Create(resourceType);
        }

        public async Task<ResourceType> GetResourceType(int id)
        {
            return await UnitOfWork.ResourceTypes.Get(id);
        }

        public async Task<IList<ResourceType>> GetAllResourceTypes()
        {
            IList<ResourceType> resourceTypes = await UnitOfWork.ResourceTypes.GetAll();
            return resourceTypes;
        }

        public async Task UpdateResourceType(ResourceType resourceType)
        {
            await UnitOfWork.ResourceTypes.Update(resourceType);
        }

        public async Task DeleteResourceType(ResourceType resourceType)
        {
            await UnitOfWork.ResourceTypes.Delete(resourceType);
        }
    }
}
