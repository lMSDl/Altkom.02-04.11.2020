using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            Property(educator => educator.LastName)
                .IsRequired()
                .HasMaxLength(15);

            Property(educator => educator.FirstName)
                .HasMaxLength(15);
        }
    }
}
