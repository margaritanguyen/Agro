using Agro.DataAccess.DbPatterns.Interfaces;
using Agro.DataAccess.Entities;
using Agro.Services.Interfaces;

namespace Agro.Services.Services
{
    public class UserRoleService : ServiceConstructor, IUserRoleService
    {
        public UserRoleService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<UserRole> GetUserRole(int id)
        {
            return await UnitOfWork.UserRoles.Get(id);
        }

        public async Task<IList<UserRole>> GetAllUserRoles()
        {
            IList<UserRole> userRoles = await UnitOfWork.UserRoles.GetAll();
            return userRoles;
        }
    }
}
