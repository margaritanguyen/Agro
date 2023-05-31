using Agro.DataAccess.DbPatterns.Interfaces;
using Agro.DataAccess.Entities;
using Agro.Services.Interfaces;

namespace Agro.Services.Services
{
    public class AnimalGroupService : ServiceConstructor, IAnimalGroupService
    {
        public AnimalGroupService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<AnimalGroup> CreateAnimalGroup(AnimalGroup animalGroup)
        {
            return await UnitOfWork.AnimalGroups.Create(animalGroup);
        }

        public async Task<AnimalGroup> GetAnimalGroup(int id)
        {
            return await UnitOfWork.AnimalGroups.Get(id);
        }

        public async Task<IList<AnimalGroup>> GetAllAnimalGroups()
        {
            IList<AnimalGroup> animalGroups = await UnitOfWork.AnimalGroups.GetAll();
            return animalGroups;
        }

        public async Task UpdateAnimalGroup(AnimalGroup animalGroup)
        {
            await UnitOfWork.AnimalGroups.Update(animalGroup);
        }

        public async Task DeleteAnimalGroup(AnimalGroup animalGroup)
        {
            await UnitOfWork.AnimalGroups.Delete(animalGroup);
        }
    }
}
