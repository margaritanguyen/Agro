using Agro.DataAccess.Entities;

namespace Agro.Services.Interfaces
{
    public interface IBalanceService
    {
        Task<Balance> CreateBalance(Balance balance);
        Task<Balance> GetBalance(int code);
        Task<IList<Balance>> GetAllBalances();
        Task UpdateBalance(Balance balance);
        Task DeleteBalance(Balance balance);
    }
}
