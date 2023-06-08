using Agro.DataAccess.DbPatterns.Interfaces;
using Agro.DataAccess.Entities;

namespace Agro.DataAccess.DbPatterns
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AgroDbContext _context;

        public UnitOfWork(AgroDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<UserRole> UserRoles => new GenericRepository<UserRole>(_context);
        public IGenericRepository<User> Users => new GenericRepository<User>(_context);

        public IGenericRepository<AnimalGroup> AnimalGroups => new GenericRepository<AnimalGroup>(_context);
        public IGenericRepository<ArchiveMessage> ArchiveMessages => new GenericRepository<ArchiveMessage>(_context);
        public IGenericRepository<Area> Areas => new GenericRepository<Area>(_context);
        public IGenericRepository<Balance> Balances => new GenericRepository<Balance>(_context);
        public IGenericRepository<DosingType> DosingTypes => new GenericRepository<DosingType>(_context);
        public IGenericRepository<Product> Products => new GenericRepository<Product>(_context);
        public IGenericRepository<ResourceType> ResourceTypes => new GenericRepository<ResourceType>(_context);
        public IGenericRepository<Resource> Resources => new GenericRepository<Resource>(_context);
        public IGenericRepository<SiloType> SiloTypes => new GenericRepository<SiloType>(_context);
        public IGenericRepository<Silo> Silos => new GenericRepository<Silo>(_context);
        public IGenericRepository<TaskMessage> TaskMessages => new GenericRepository<TaskMessage>(_context);
        public IGenericRepository<ProductRecipe> ProductRecipes => new GenericRepository<ProductRecipe>(_context);
        public IGenericRepository<RecipeIngredient> RecipeIngredients => new GenericRepository<RecipeIngredient>(_context);
        public IGenericRepository<DosingTask> DosingTasks => new GenericRepository<DosingTask>(_context);

        public IGenericRepository<BatchReport> BatchReports => new GenericRepository<BatchReport>(_context);
        public IGenericRepository<TechCardReport> TechCardReports => new GenericRepository<TechCardReport>(_context);

    }
}
