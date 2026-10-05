using ExpendProject.BLL.DTO_S;
using ExpendProject.BLL.Services.Classes;
using ExpendProject.BLL.Services.Interfces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpendProject.Controllers
{

    public class AuthentiactionController : BaseController
    {
        private readonly IAuthenticationServices authenticationServices;

        public AuthentiactionController(IAuthenticationServices authenticationServices )
        {
            this.authenticationServices = authenticationServices;
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>>login(LoginDto loginDto, CancellationToken ct = default)
        {
            return ToActionResult(await authenticationServices.LoginAsync(loginDto));
        }
    }
}
