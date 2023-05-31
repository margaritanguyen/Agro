using Agro.DataAccess.DbPatterns.Interfaces;
using Agro.DataAccess.Entities;
using Agro.Services.Interfaces;

namespace Agro.Services.Services
{
    public class BalanceService : ServiceConstructor, IBalanceService
    {
        public BalanceService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<Balance> CreateBalance(Balance balance)
        {
            return await UnitOfWork.Balances.Create(balance);
        }

        public async Task<Balance> GetBalance(int id)
        {
            return await UnitOfWork.Balances.Get(id);
        }

        public async Task<IList<Balance>> GetAllBalances()
        {
            IList<Balance> balances = await UnitOfWork.Balances.GetAll();
            return balances;
        }

        public async Task UpdateBalance(Balance balance)
        {
            await UnitOfWork.Balances.Update(balance);
        }

        public async Task DeleteBalance(Balance balance)
        {
            await UnitOfWork.Balances.Delete(balance);
        }
    }
}
