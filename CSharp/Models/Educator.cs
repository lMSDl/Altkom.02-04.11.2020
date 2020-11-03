using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Educator : Person
    {
        public int EducatorId { get; set; }
        public string Specialization { get; set; }
    }
}
