using Microsoft.EntityFrameworkCore;
 
using Molla.Domain.Common;
 
using Molla.Application.IServices;
using Molla.Application.Services;
 
using Molla.Domain.IRepositories;
using Molla.Infrastructure.persistence.Common;
using Molla.Infrastructure.persistence.Repositories;

namespace Molla.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            #region Configs
            
            
            //DataBase
            builder.Services.AddDbContext<ApplicationDbContext>(
                x => x.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefualtConnection")
                    ));
 


            //Cloudinary 
            builder.Services.Configure<CloudinarySetup>(builder.Configuration.GetSection("CloudinarySetup"));



            #endregion
 
            /* register services */
            builder.Services.AddScoped<ISliderService, SliderService>();

            /* register repository */
            builder.Services.AddScoped<ISliderRepository, SliderRepository>();
 

            var app = builder.Build();


            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


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