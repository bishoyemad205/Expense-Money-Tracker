using ExpendProject.DAL.Model.Identity_Entites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.DAL.Model
{
    public class Income : BaseEntites
    {
        public string Name { get; set; } = default!;
        public decimal Amount { get; set; }
        public string Description { get; set; } = default!; 
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ApplicationUser applicationUser { get; set; } = default!;
        public int userid { get; set; }
        
    }
}
