using iTest.Data;
using iTest.Data.Models;
using iTest.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;

namespace iTest.Web.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<iTestDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();


                // create roles
                Task.Run(async () =>
                {
                    var roles = new[]
                    {
                            UserRoles.AdminRole,
                            UserRoles.UserRole
                    };

                    foreach (var role in roles)
                    {
                        var roleExists = await roleManager.RoleExistsAsync(role);

                        if (!roleExists)
                        {
                            var result = await roleManager.CreateAsync(new IdentityRole
                            {
                                Name = role
                            });

                            var error = result.Errors.SelectMany(e => e.Code);
                        }
                    }

                    // create admin
                    var admin = await userManager.FindByNameAsync("admin");

                    if (admin == null)
                    {
                        admin = new User
                        {
                            UserName = "admin"
                        };

                        await userManager.CreateAsync(admin, "admin12");

                        await userManager.AddToRoleAsync(admin, UserRoles.AdminRole);
                    }

                    var user = await userManager.FindByNameAsync("user");

                    if (user == null)
                    {
                        user = new User
                        {
                            UserName = "user"
                        };

                        await userManager.CreateAsync(user, "user12");

                        await userManager.AddToRoleAsync(user, UserRoles.UserRole);
                    }
                })
                .Wait();
            }

            return app;
        }
    }
}
