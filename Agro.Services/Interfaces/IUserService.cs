using Agro.DataAccess.Entities;

namespace Agro.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task<User> GetUser(int id);
        Task<IList<User>> GetAllUsers();
        Task UpdateUser(User user);
        Task DeleteUser(User user);

    }
}
