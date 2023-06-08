using Agro.DataAccess.DbPatterns.Interfaces;
using Agro.DataAccess.Entities;
using Agro.Services.Interfaces;

namespace Agro.Services.Services
{
    public class TaskMessageService : ServiceConstructor, ITaskMessageService
    {
        public TaskMessageService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<TaskMessage> CreateTaskMessage(TaskMessage taskMessage)
        {
            return await UnitOfWork.TaskMessages.Create(taskMessage);
        }

        public async Task<TaskMessage> GetTaskMessage(int id)
        {
            return await UnitOfWork.TaskMessages.Get(id);
        }

        public async Task<TaskMessage> GetTaskMessageByCode(int code)
        {
            IList<TaskMessage> taskMessages = await UnitOfWork.TaskMessages.GetAll();
            var taskMessage = taskMessages.Where(x => x.Code == code).FirstOrDefault();
            return taskMessage;
        }

        public async Task<IList<TaskMessage>> GetAllTaskMessages()
        {
            IList<TaskMessage> taskMessages = await UnitOfWork.TaskMessages.GetAll();
            return taskMessages;
        }

        public async Task UpdateTaskMessage(TaskMessage taskMessage)
        {
            await UnitOfWork.TaskMessages.Update(taskMessage);
        }

        public async Task DeleteTaskMessage(TaskMessage taskMessage)
        {
            await UnitOfWork.TaskMessages.Delete(taskMessage);
        }
    }
}
