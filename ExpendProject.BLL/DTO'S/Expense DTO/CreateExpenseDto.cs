using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.BLL.DTO_S
{
    public class CreateExpenseDto
    {
        public string Description { get; set; } = default!;
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
