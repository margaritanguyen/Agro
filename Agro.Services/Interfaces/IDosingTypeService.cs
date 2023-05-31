using Agro.DataAccess.Entities;

namespace Agro.Services.Interfaces
{
    public interface IDosingTypeService
    {
        Task<DosingType> CreateDosingType(DosingType dosingType);
        Task<DosingType> GetDosingType(int id);
        Task<IList<DosingType>> GetAllDosingTypes();
        Task UpdateDosingType(DosingType dosingType);
        Task DeleteDosingType(DosingType dosingType);
    }
}
