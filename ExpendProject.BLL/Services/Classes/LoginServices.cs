using ExpendProject.BLL.Common;
using ExpendProject.BLL.DTO_S;
using ExpendProject.BLL.Services.Interfces;
using ExpendProject.DAL.Model.Identity_Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.BLL.Services.Classes
{
    public class LoginServices : ILoginServices
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public LoginServices(UserManager<ApplicationUser> userManager , RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<Result<bool>> CheckPassAsync(string Email, string Password, CancellationToken ct = default)
        {
            var user = await userManager.FindByEmailAsync(Email);
            if (user is null)
            {
                return Result<bool>.Fail($"User With{Email} is Not Found");
            }
            var isvalid = await userManager.CheckPasswordAsync(user, Password);
            return Result<bool>.ok(isvalid);
        }

        public async Task<Result<IdentityUserResult>> FindUserByEmailAsync(string Email, CancellationToken ct = default)
        {
            var user = await userManager.FindByEmailAsync(Email);
            if (user is null)
            {
                return Result <IdentityUserResult>.Fail($"User With{Email} is Not Found");
            }
            else
            {
                return Result<IdentityUserResult>.ok(new IdentityUserResult(user.Id, user.UserName, user.DisplayName, user.Email));
            }
        }
    }
}
