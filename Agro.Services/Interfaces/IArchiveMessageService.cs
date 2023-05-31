using Agro.DataAccess.Entities;

namespace Agro.Services.Interfaces
{
    public interface IArchiveMessageService
    {
        Task<ArchiveMessage> CreateArchiveMessage(ArchiveMessage archiveMessage);
        Task<ArchiveMessage> GetArchiveMessage(int id);
        Task<IList<ArchiveMessage>> GetAllArchiveMessages();
        Task UpdateArchiveMessage(ArchiveMessage archiveMessage);
        Task DeleteArchiveMessage(ArchiveMessage archiveMessage);
    }
}
