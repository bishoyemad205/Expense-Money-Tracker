using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.BLL.Common
{
    public class IdentityUserResult
    {
        public IdentityUserResult(string id, string email, string userName, string displayName)
        {
            this.id = id;
            Email = email;
            UserName = userName;
            DisplayName = displayName;
        }

        public string id { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string DisplayName { get; set; } = default!;
    }
}
