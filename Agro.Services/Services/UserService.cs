using Agro.DataAccess.DbPatterns.Interfaces;
using Agro.DataAccess.Entities;
using Agro.Services.Interfaces;

namespace Agro.Services.Services
{
    public class UserService : ServiceConstructor, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<User> CreateUser(User user)
        {
            return await UnitOfWork.Users.Create(user);
        }

        public async Task<User> GetUser(int id)
        {
            return await UnitOfWork.Users.Get(id);
        }

        public async Task<IList<User>> GetAllUsers()
        {
            IList<User> users = await UnitOfWork.Users.GetAll();
            return users;
        }

        public async Task UpdateUser(User user)
        {
            await UnitOfWork.Users.Update(user);
        }

        public async Task DeleteUser(User user)
        {
            await UnitOfWork.Users.Delete(user);
        }
    }
}
