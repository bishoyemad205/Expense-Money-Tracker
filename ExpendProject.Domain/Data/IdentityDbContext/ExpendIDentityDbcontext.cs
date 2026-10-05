using ExpendProject.DAL.Model.Identity_Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.DAL.Data.IdentityDbContext
{
    public class ExpendIDentityDbcontext :  IdentityDbContext<ApplicationUser>
    {
        public ExpendIDentityDbcontext(DbContextOptions<ExpendIDentityDbcontext> options) : base(options)  
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("RolesUsers");
 
        }
    }
}
