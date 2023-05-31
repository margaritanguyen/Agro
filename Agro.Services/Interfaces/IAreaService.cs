using Agro.DataAccess.Entities;

namespace Agro.Services.Interfaces
{
    public interface IAreaService
    {
        Task<Area> CreateArea(Area area);
        Task<Area> GetArea(int code);
        Task<IList<Area>> GetAllAreas();
        Task UpdateArea(Area area);
        Task DeleteArea(Area area);
    }
}
