using Agro.DataAccess.DbPatterns.Interfaces;

namespace Agro.Services.Services
{
    public class ServiceConstructor
    {
        protected IUnitOfWork UnitOfWork;

        protected ServiceConstructor(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
