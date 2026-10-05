using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendProject.DAL.Data.Configuration
{
    public class UserConfigurration : IEntityTypeConfiguration<UserConfigurration>
    {
        public void Configure(EntityTypeBuilder<UserConfigurration> builder)
        {
            throw new NotImplementedException();
        }
    }
}
