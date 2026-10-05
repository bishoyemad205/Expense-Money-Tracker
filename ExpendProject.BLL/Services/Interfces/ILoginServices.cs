using ExpendProject.BLL.Common;
using ExpendProject.BLL.DTO_S;
using ExpendProject.DAL.Model.Identity_Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.BLL.Services.Interfces
{
    public interface ILoginServices
    {
        Task<Result<IdentityUserResult>> FindUserByEmailAsync(String Email, CancellationToken ct = default);
        Task<Result<bool>> CheckPassAsync(string Email, string Password, CancellationToken ct = default);

    }
}
