using Agro.DataAccess.Entities;

namespace Agro.Services.Interfaces
{
    public interface IUserRoleService
    {
        Task<UserRole> GetUserRole(int id);
        Task<IList<UserRole>> GetAllUserRoles();
    }
}
