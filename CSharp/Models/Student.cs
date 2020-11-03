using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Student : Person
    {
        public int StudentId { get; set; }

        public ICollection<Class> Classes {get ;set; }
        public override int Id => StudentId;
    }
}
