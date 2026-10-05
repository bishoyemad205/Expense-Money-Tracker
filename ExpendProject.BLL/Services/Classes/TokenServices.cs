using ExpendProject.BLL.Services.Interfces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.BLL.Services.Classes
{
    public class TokenServices : ITokenServices
    {
        public string CreateToken(string userid, string Email, string username, IEnumerable<string> Roles)
        {
            throw new NotImplementedException();
        }

        public class JwtSetting
        {
            public string SecretKey { get; set; } = default!;
            public string Issuer { get; set; } = default!;
            public string Audience { get; set; } = default!;
            public int ExpirationMinutes { get; set; }
        }
    }
}
