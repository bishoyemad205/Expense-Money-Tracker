using ExpendProject.DAL.Data.DataSeeder;
using ExpendProject.DAL.Data.IdentityDataSeeder;
using Microsoft.AspNetCore.DataProtection;

namespace ExpendProject
{
    public static class WebAppEx
    {
        public static async Task SeedingMigrationDataAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredKeyedService<IdataSeeder>("Identity");
            await seeder.SeedAsync();
            

        }
    }
}
