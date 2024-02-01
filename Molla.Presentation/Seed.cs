using Microsoft.AspNetCore.Identity;
using Molla.Domain.Entities;
using System.Net;

namespace Molla.Presentation
{
    public class Seed
    {
        /// <summary>
        /// pass must contain UpperCase, LowerCase , SpecialChars(!@#) , and numbers 
        /// </summary>
        /// <param name="applicationBuilder"></param>
        /// <param name="username"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder, string username , string pass)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync("admin"))
                    await roleManager.CreateAsync(new IdentityRole("admin"));
                if (!await roleManager.RoleExistsAsync("user"))
                    await roleManager.CreateAsync(new IdentityRole("user"));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                string adminUserEmail = "mehreganabdix@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new User()
                    {
                        UserName = username,
                        Email = adminUserEmail,
                        EmailConfirmed = true
                        
                    };
                    await userManager.CreateAsync(newAdminUser, pass);
                    await userManager.AddToRoleAsync(newAdminUser, "admin");
                }

            }
        }
    }
}
