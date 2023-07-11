using Agro.AutoMapper;
using Agro.DataAccess;
using Agro.DataAccess.DbPatterns;
using Agro.DataAccess.DbPatterns.Interfaces;
using Agro.Services.Interfaces;
using Agro.Services.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Agro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSwaggerGen();

            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AgroDbContext>(options => options.UseSqlServer(connection));
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<IUserRoleService, UserRoleService>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IAnimalGroupService, AnimalGroupService>();
            builder.Services.AddTransient<IArchiveMessageService, ArchiveMessageService>();
            builder.Services.AddTransient<IAreaService, AreaService>();
            builder.Services.AddTransient<IBalanceService, BalanceService>();
            builder.Services.AddTransient<IDosingTaskService, DosingTaskService>();
            builder.Services.AddTransient<IDosingTypeService, DosingTypeService>();
            builder.Services.AddTransient<IProductRecipeService, ProductRecipeService>();
            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddTransient<IRecipeIngredientService, RecipeIngredientService>();
            builder.Services.AddTransient<IResourceTypeService, ResourceTypeService>();
            builder.Services.AddTransient<IResourceService, ResourceService>();
            builder.Services.AddTransient<ISiloTypeService, SiloTypeService>();
            builder.Services.AddTransient<ISiloService, SiloService>();
            builder.Services.AddTransient<ITaskMessageService, TaskMessageService>();

            builder.Services.AddTransient<IBatchReportService, BatchReportService>();
            builder.Services.AddTransient<ITechCardReportService, TechCardReportService>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/User/Login");
                    options.ExpireTimeSpan = new TimeSpan(0, 5, 0);
                });

            builder.Services.AddAutoMapper(typeof(AppMappingProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); 
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
