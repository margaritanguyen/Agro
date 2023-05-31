using Agro.AutoMapper;
using Agro.DataAccess;
using Agro.DataAccess.DbPatterns;
using Agro.DataAccess.DbPatterns.Interfaces;
using Agro.Services.Interfaces;
using Agro.Services.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Agro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AgroDbContext>(options => options.UseSqlServer(connection));
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<IUserRoleService, UserRoleService>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IAnimalGroupService, AnimalGroupService>();
            builder.Services.AddTransient<IArchiveMessageService, ArchiveMessageService>();
            builder.Services.AddTransient<IAreaService, AreaService>();
            builder.Services.AddTransient<IBalanceService, BalanceService>();
            builder.Services.AddTransient<IDosingTypeService, DosingTypeService>();
            builder.Services.AddTransient<IProductRecipeService, ProductRecipeService>();
            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddTransient<IResourceTypeService, ResourceTypeService>();
            builder.Services.AddTransient<IResourceService, ResourceService>();
            builder.Services.AddTransient<ISiloTypeService, SiloTypeService>();
            builder.Services.AddTransient<ISiloService, SiloService>();
            builder.Services.AddTransient<ITaskMessageService, TaskMessageService>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

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
