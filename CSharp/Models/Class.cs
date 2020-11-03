using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Class
    {
        public int ClassId { get; set; }

        public Educator Educator { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
