using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.BLL.Services.Interfces
{
    public interface ITokenServices
    {
        string CreateToken(string userid , string Email , string username, IEnumerable<string> Roles);
    }
}
