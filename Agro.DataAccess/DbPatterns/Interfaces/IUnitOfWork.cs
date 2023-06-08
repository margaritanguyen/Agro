using Agro.DataAccess.Entities;

namespace Agro.DataAccess.DbPatterns.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<UserRole> UserRoles { get; }
        IGenericRepository<User> Users { get; }

        IGenericRepository<Area> Areas { get; }
        IGenericRepository<DosingType> DosingTypes { get; }
        IGenericRepository<ResourceType> ResourceTypes { get; }
        IGenericRepository<AnimalGroup> AnimalGroups { get; }
        IGenericRepository<SiloType> SiloTypes { get; }
        IGenericRepository<TaskMessage> TaskMessages { get; }
        IGenericRepository<Silo> Silos { get; }
        IGenericRepository<Balance> Balances { get; }
        IGenericRepository<Resource> Resources { get; }
        IGenericRepository<Product> Products { get; }
        IGenericRepository<ProductRecipe> ProductRecipes { get; }
        IGenericRepository<RecipeIngredient> RecipeIngredients { get; }
        IGenericRepository<DosingTask> DosingTasks { get; }
        IGenericRepository<ArchiveMessage> ArchiveMessages { get; }

        IGenericRepository<BatchReport> BatchReports { get; }
        IGenericRepository<TechCardReport> TechCardReports { get; }


    }
}
