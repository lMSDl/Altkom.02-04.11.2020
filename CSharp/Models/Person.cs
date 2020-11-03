using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Person : ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{LastName} {FirstName}";
        public Genders Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
