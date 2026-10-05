using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.BLL.DTO_S.Inom_Dto
{
    public class UpDateIncomDto
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

    }
}
