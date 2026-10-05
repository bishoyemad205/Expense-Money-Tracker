using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.BLL.DTO_S
{
    public class ExpenseDto
    {
       public int Id { get; set; }
       public decimal Amount { get; set; }
       public string Description { get; set; }
       public DateTime Date { get; set; }
        
    }
}
