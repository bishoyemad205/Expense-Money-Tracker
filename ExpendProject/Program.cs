
using ExpendProject.BLL.Services.Classes;
using ExpendProject.BLL.Services.Interfces;
using ExpendProject.BLL.Utilites;
using ExpendProject.DAL.Data.DataSeeder;
using ExpendProject.DAL.Data.DB;
using ExpendProject.DAL.Data.IdentityDataSeeder;
using ExpendProject.DAL.Data.IdentityDbContext;
using ExpendProject.DAL.Model.Identity_Entites;
using ExpendProject.DAL.Repository.Classes;
using ExpendProject.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;

namespace ExpendProject
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ExpendProjectDBcontext>(Options =>
            Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddDbContext<ExpendIDentityDbcontext>(Options =>
            Options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

            // Add services to the container.
            builder.Services.AddKeyedScoped<IdataSeeder, IdentityDataSeeder>("Identity");
            builder.Services.AddScoped<IExpenseService, ExpenseService>();

            builder.Services.AddScoped<IIncomServices, IncomServices>();
            builder.Services.AddScoped<IAuthenticationServices, AuthenticationServices>();
            builder.Services.AddScoped<ILoginServices, LoginServices>();

            builder.Services.AddScoped(typeof(IgenericRepo<,>), typeof(GenericReposiorty<,>));

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddIdentity < ApplicationUser, IdentityRole>(); //باضيف كله لكن ال
                                                                    //  coreبتضيف للي كاتبه ولو عايز حاجه بضيفها 
            builder.Services.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddEntityFrameworkStores<ExpendIDentityDbcontext>();


            var app = builder.Build();
            await app.SeedingMigrationDataAsync();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
