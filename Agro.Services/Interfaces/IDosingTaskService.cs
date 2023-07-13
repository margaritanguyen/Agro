using Agro.DataAccess.Entities;

namespace Agro.Services.Interfaces
{
    public interface IDosingTaskService
    {
        Task<DosingTask> CreateDosingTask(DosingTask dosingTask);
        Task<DosingTask> GetDosingTask(int id);
        Task<IList<DosingTask>> GetAllDosingTasks();
        Task<IList<DosingTask>> GetCurrentDosingTasks();
        Task UpdateDosingTask(DosingTask dosingTask);
        Task DeleteDosingTask(DosingTask dosingTask);
    }
}
