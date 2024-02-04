using Microsoft.EntityFrameworkCore;
using Molla.Domain.Common;
using Molla.Application.Services;
using Molla.Domain.IRepositories;
using Molla.Infrastructure.persistence.Common;
using Molla.Infrastructure.persistence.Repositories;
using Molla.Infrastructure.EmailProvider;
using Microsoft.AspNetCore.Identity;
using Molla.Application.Interfaces.IPoviders;
using Molla.Application.Interfaces;
using Molla.Infrastructure.persistence.UnitOfWork;
using Molla.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Molla.Domain.Entities;


namespace Molla.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();//.AddRazorRuntimeCompilation();

            builder.Services.AddHttpContextAccessor();


            #region Services
            builder.Services.AddScoped<ISliderService, SliderService>();
            builder.Services.AddScoped<IBanerService, BanerService>();
            builder.Services.AddScoped<IEmailProvider, EmailProvider>();
            builder.Services.AddScoped<IUserAccountService, UserAccountService>();
            builder.Services.AddScoped<IPhotoService, PhotoService>();
            builder.Services.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();
            builder.Services.AddScoped<IAdminDashboardService, AdminDashBoardService>();
            builder.Services.AddScoped<IHomeIndexService, HomeIndexService>();
            #endregion


            #region Repositories
            builder.Services.AddScoped<ISliderRepository, SliderRepository>();
            builder.Services.AddScoped<IBanerRepository, BanerRepository>();
            builder.Services.AddScoped<IOFFRepository,OFFRepository>();
            builder.Services.AddScoped<IAdminRepository, AdminRepository>();
            builder.Services.AddScoped<ICategoryGroupRepository, CategoryGroupRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IProductRepository,ProductRepository>();
            builder.Services.AddScoped<IColorRepository, ColorRepository>();
            builder.Services.AddScoped<ISizeRepository,SizeRepository>();
            builder.Services.AddScoped<IGalleryRepository,GalleryRepository>();
            builder.Services.AddScoped<IStockByColorSizeRepository,StockByColorSizeRepository>();
            builder.Services.AddScoped<IAboutUsRepository, AboutUsRepository>();
            builder.Services.AddScoped<IContactUsRepository,ContactUsRepository>();
            #endregion




            #region Configs

            //Cloudinary 
            builder.Services.Configure<CloudinarySetup>(builder.Configuration.GetSection("CloudinarySetup"));


            //DataBase
            builder.Services.AddDbContext<ApplicationDbContext>(
                x => x.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefualtConnection")));

            //builder.Services.AddDefaultIdentity<IdentityUser>()
            //                .AddEntityFrameworkStores<ApplicationDbContext>()
            //                .AddDefaultTokenProviders();
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddMemoryCache();

            builder.Services.AddSession();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            #endregion


           


            var app = builder.Build();


            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //run this method once
            //await Seed.SeedUsersAndRolesAsync(app);

            

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapAreaControllerRoute(
                name: "MyAdmin",
                areaName: "Admin",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                 );

            app.Run();
        }
    }
}