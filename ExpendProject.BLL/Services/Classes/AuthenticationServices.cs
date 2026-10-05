using ExpendProject.BLL.Common;
using ExpendProject.BLL.DTO_S;
using ExpendProject.BLL.Services.Interfces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.BLL.Services.Classes
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly ILoginServices loginServices;

        public AuthenticationServices(ILoginServices loginServices)
        {
            this.loginServices = loginServices;
        }
        public async Task<Result<UserDto>> LoginAsync(LoginDto loginDto, CancellationToken ct = default)
        {
            var UserResult = await loginServices.FindUserByEmailAsync(loginDto.Email);
            // Get user email 
            if (!UserResult.Succes)
            {
                return Result<UserDto>.Fail(UserResult.Error);
            }
            // check pass
            var passcheck = await loginServices.CheckPassAsync(loginDto.Email, loginDto.Password, ct);
            if (!passcheck.Succes)
            { 
              return Result<UserDto>.Fail("Invalid Email Or Password");
            }
            if (!passcheck.Value)
            {
                return Result<UserDto>.Fail("UnAuthorized");
            }
            return Result<UserDto>.ok(new UserDto()
            {
                Email = loginDto.Email,
                DisplayName = UserResult.Value.DisplayName,
                Token = "Token"
            });
              
          
        }
    }
}
