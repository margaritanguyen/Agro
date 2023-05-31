using Agro.DataAccess.Entities;

namespace Agro.Services.Interfaces
{
    public interface IResourceTypeService
    {
        Task<ResourceType> CreateResourceType(ResourceType resourceType);
        Task<ResourceType> GetResourceType(int id);
        Task<IList<ResourceType>> GetAllResourceTypes();
        Task UpdateResourceType(ResourceType resourceType);
        Task DeleteResourceType(ResourceType resourceType);
    }
}
