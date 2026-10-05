using ExpendProject.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.DAL.Data.DB
{
    public class ExpendProjectDBcontext : DbContext
    {
        public ExpendProjectDBcontext(DbContextOptions<ExpendProjectDBcontext> options) : base(options)
        { 
        
        }

       

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> incomes { get; set; }

    }
}
