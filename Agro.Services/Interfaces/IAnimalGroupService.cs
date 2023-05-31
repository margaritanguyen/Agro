using Agro.DataAccess.Entities;

namespace Agro.Services.Interfaces
{
    public interface IAnimalGroupService
    {
        Task<AnimalGroup> CreateAnimalGroup(AnimalGroup animalGroup);
        Task<AnimalGroup> GetAnimalGroup(int id);
        Task<IList<AnimalGroup>> GetAllAnimalGroups();
        Task UpdateAnimalGroup(AnimalGroup animalGroup);
        Task DeleteAnimalGroup(AnimalGroup animalGroup);
    }
}
