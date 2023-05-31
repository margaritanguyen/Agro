using Agro.DataAccess.Entities;

namespace Agro.Services.Interfaces
{
    public interface ITaskMessageService
    {
        Task<TaskMessage> CreateTaskMessage(TaskMessage taskMessage);
        Task<TaskMessage> GetTaskMessage(int id);
        Task<IList<TaskMessage>> GetAllTaskMessages();
        Task UpdateTaskMessage(TaskMessage taskMessage);
        Task DeleteTaskMessage(TaskMessage taskMessage);
    }
}
