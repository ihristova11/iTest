using System;
using System.Linq;
using System.Threading.Tasks;
using iTest.Data.Models.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace iTest.Data
{
    public static class DataSeeder
    {
        public static async Task InitializeAsync(IServiceProvider service)
        {
            using (var serviceScope = service.CreateScope())
            {
                var scopeServiceProvider = serviceScope.ServiceProvider;
                var db = scopeServiceProvider.GetService<iTestDbContext>();
                db.Database.Migrate();
                await InsertTestData(db);
            }
        }

        private static async Task InsertTestData(iTestDbContext context)
        {
            if (context.Categories.Any())
                return;
            var categoryNET = new Category() { Name = ".NET", CreatedOn = DateTime.Now };
            var categoryJava = new Category() { Name = "Java", CreatedOn = DateTime.Now };
            var categoryJs = new Category() { Name = "JavaScript", CreatedOn = DateTime.Now };
            var categorySQL = new Category() { Name = "SQL", CreatedOn = DateTime.Now };

            context.Add(categoryNET);
            context.Add(categoryJava);
            context.Add(categoryJs);
            context.Add(categorySQL);

            await context.SaveChangesAsync();
        }

    }
}
