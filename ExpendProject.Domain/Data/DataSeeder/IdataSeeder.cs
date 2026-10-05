using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.DAL.Data.DataSeeder
{
    public interface IdataSeeder
    {

        Task SeedAsync(CancellationToken ct = default);
    }
}
