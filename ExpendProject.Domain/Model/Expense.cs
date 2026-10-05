using ExpendProject.DAL.Model.Identity_Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.DAL.Model
{
    public class Expense : BaseEntites
    {  
        public string Description { get; set; } = default!;
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public ApplicationUser applicationUser { get; set; } = default!;
        public int userid { get; set; }

    }
}
