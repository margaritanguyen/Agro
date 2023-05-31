using Agro.DataAccess.DbPatterns.Interfaces;
using Agro.DataAccess.Entities;
using Agro.Services.Interfaces;

namespace Agro.Services.Services
{
    public class ArchiveMessageService : ServiceConstructor, IArchiveMessageService
    {
        public ArchiveMessageService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<ArchiveMessage> CreateArchiveMessage(ArchiveMessage archiveMessage)
        {
            return await UnitOfWork.ArchiveMessages.Create(archiveMessage);
        }

        public async Task<ArchiveMessage> GetArchiveMessage(int id)
        {
            return await UnitOfWork.ArchiveMessages.Get(id);
        }

        public async Task<IList<ArchiveMessage>> GetAllArchiveMessages()
        {
            IList<ArchiveMessage> archiveMessages = await UnitOfWork.ArchiveMessages.GetAll();
            return archiveMessages;
        }

        public async Task UpdateArchiveMessage(ArchiveMessage archiveMessage)
        {
            await UnitOfWork.ArchiveMessages.Update(archiveMessage);
        }

        public async Task DeleteArchiveMessage(ArchiveMessage archiveMessage)
        {
            await UnitOfWork.ArchiveMessages.Delete(archiveMessage);
        }
    }
}
