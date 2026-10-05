using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.BLL.DTO_S.Inom_Dto
{
    public class IncomDtos
    {
        public string Name { get; set; } = default!;
        public decimal Amount { get; set; }
        public string Description { get; set; } = default!;
        public DateTime Date { get; set; }

        public DateTime CreatedAt { get;  } = DateTime.Now;
    }
}
