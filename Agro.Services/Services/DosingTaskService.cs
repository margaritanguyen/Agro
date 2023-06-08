using Agro.DataAccess.DbPatterns.Interfaces;
using Agro.DataAccess.Entities;
using Agro.Services.Interfaces;

namespace Agro.Services.Services
{
    public class DosingTaskService : ServiceConstructor, IDosingTaskService
    {
        public DosingTaskService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<DosingTask> CreateDosingTask(DosingTask dosingTask)
        {
            return await UnitOfWork.DosingTasks.Create(dosingTask);
        }

        public async Task<DosingTask> GetDosingTask(int id)
        {
            return await UnitOfWork.DosingTasks.Get(id);
        }

        public async Task<IList<DosingTask>> GetAllDosingTasks()
        {
            IList<DosingTask> dosingTasks = await UnitOfWork.DosingTasks.GetAll();
            return dosingTasks;
        }

        public async Task UpdateDosingTask(DosingTask dosingTask)
        {
            await UnitOfWork.DosingTasks.Update(dosingTask);
        }

        public async Task DeleteDosingTask(DosingTask dosingTask)
        {
            await UnitOfWork.DosingTasks.Delete(dosingTask);
        }
    }
}
