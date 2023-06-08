using Agro.DataAccess.Entities;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace Agro.DataAccess
{
    public class AgroDbContext : DbContext
    {
        public AgroDbContext(DbContextOptions<AgroDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { Id = 1, Name = "Администратор" },
                new UserRole { Id = 2, Name = "Оператор" },
                new UserRole { Id = 3, Name = "Технолог" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { 
                    Id = 1, 
                    UserName = "admin",
                    FullName = "Администратор", 
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123"), 
                    UserRoleId = 1
            });

            modelBuilder.Entity<Area>().HasData(new Area { Id = 1, Code = 0, Name = "-" });

            modelBuilder.Entity<DosingType>().HasData(
                new DosingType { Id = 1, Code = 1, Name = "ручное" },
                new DosingType { Id = 2, Code = 2, Name = "жидкое" },
                new DosingType { Id = 3, Code = 3, Name = "автоматическое" }
            );

            modelBuilder.Entity<ResourceType>().HasData(new ResourceType { Id = 1, Code = 1, Name = "минеральное" });

            modelBuilder.Entity<AnimalGroup>().HasData(new AnimalGroup { Id = 1, Code = 0, Name = "-" });

            modelBuilder.Entity<SiloType>().HasData(new SiloType { Id = 1, Code = 1, Name = "дозаторный" });

            modelBuilder.Entity<TaskMessage>().HasData(
                new TaskMessage { Id = 1, Code = 0, Message = "-" },
                new TaskMessage { Id = 2, Code = 1, Message = "ожидает" },
                new TaskMessage { Id = 3, Code = 2, Message = "выполняется" },
                new TaskMessage { Id = 4, Code = 3, Message = "выполнено" },
                new TaskMessage { Id = 5, Code = 4, Message = "остановлено" }
            );

            modelBuilder.Entity<ArchiveMessage>().HasData(
                new ArchiveMessage { Id = 1, Code = 0, Message = "OK" },
                new ArchiveMessage { Id = 2, Code = 1, Message = ">T" },
                new ArchiveMessage { Id = 3, Code = 2, Message = ">A>T" },
                new ArchiveMessage { Id = 4, Code = 3, Message = ">T OK" },
                new ArchiveMessage { Id = 5, Code = 4, Message = ">T FAIL" },
                new ArchiveMessage { Id = 6, Code = 5, Message = ">A>T OK" },
                new ArchiveMessage { Id = 7, Code = 6, Message = ">A>T FAIL" }
            );

            modelBuilder.Entity<BatchReport>() .ToView("BatchReportView").HasNoKey();
            modelBuilder.Entity<TechCardReport>().ToView("TechCardReportView").HasNoKey();
        }

        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Area> Areas { get; set; }
        public DbSet<DosingType> DosingTypes { get; set; }
        public DbSet<ResourceType> ResourceTypes { get; set; }
        public DbSet<AnimalGroup> AnimalGroups { get; set; }
        public DbSet<SiloType> SiloTypes { get; set; }
        public DbSet<TaskMessage> TaskMessages { get; set; }
        public DbSet<Silo> Silos { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductRecipe> ProductRecipes { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<DosingTask> DosingTasks { get; set; }
        public DbSet<ArchiveMessage> ArchiveMessages { get; set; }

        public DbSet<BatchReport> BatchReports { get; set; }
    }
}
