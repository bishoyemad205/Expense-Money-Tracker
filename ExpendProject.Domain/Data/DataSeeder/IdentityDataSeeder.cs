using ExpendProject.DAL.Data.DataSeeder;
using ExpendProject.DAL.Data.IdentityDbContext;
using ExpendProject.DAL.Model.Identity_Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.DAL.Data.IdentityDataSeeder
{
    public class IdentityDataSeeder : IdataSeeder
    {
        private readonly ExpendIDentityDbcontext dbcontext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ILogger<IdentityDataSeeder> logger;

        public IdentityDataSeeder(ExpendIDentityDbcontext dbcontext
            , UserManager<ApplicationUser> userManager
            , RoleManager<IdentityRole> roleManager ,
              ILogger<IdentityDataSeeder> logger)
        {
            this.dbcontext = dbcontext;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.logger = logger;
        }
        public async Task SeedAsync(CancellationToken ct = default)
        {
            try
            {
                var PendingMigration = await dbcontext.Database.GetPendingMigrationsAsync(ct);
                if (PendingMigration.Any())
                    await dbcontext.Database.MigrateAsync(ct);

                if (!await roleManager.Roles.AnyAsync())
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                    await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                }

                if (!await userManager.Users.AnyAsync())
                {
                    var admin = new ApplicationUser()
                    {
                        DisplayName = "BeshoyEmad",
                        UserName = "Beshoy",
                        PhoneNumber = "01222639261",
                        Email = "Bishoyemad205@Gmail.com"
                    };
                    var createduser = await userManager.CreateAsync(admin, "P@ssw0rd");
                    if (createduser.Succeeded)
                    {
                        await userManager.AddToRoleAsync(admin, "SuperAdmin");
                    }
                    else
                    {
                        var Error = string.Join('/', createduser.Errors.Select(e => e.Description));
                        logger.LogWarning($"Can not seed Default{Error}");
                    }
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Identity DataSeeder Failed");
                return;
            }


           
        }
    }
}
