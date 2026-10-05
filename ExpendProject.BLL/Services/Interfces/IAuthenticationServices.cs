using ExpendProject.BLL.Common;
using ExpendProject.BLL.DTO_S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.BLL.Services.Interfces
{
    public interface IAuthenticationServices
    {
        Task<Result<UserDto>> LoginAsync(LoginDto loginDto, CancellationToken ct = default);
        //Task<UserDto> RegisterAsync(RegisterDto registerDto, CancellationToken ct = default);
        //Task<Result<bool>> CheckEmailAsync(string email, CancellationToken ct = default);
        //Task<Result<UserDto>> GetCurrentUserAsync(string email, CancellationToken ct = default);



    }
}
