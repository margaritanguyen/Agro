using Agro.DataAccess.Entities;

namespace Agro.Services.Interfaces
{
    public interface IResourceService
    {
        Task<Resource> CreateResource(Resource resource);
        Task<Resource> GetResource(int id);
        Task<IList<Resource>> GetAllResources();
        Task UpdateResource(Resource resource);
        Task DeleteResource(Resource resource);
    }
}
