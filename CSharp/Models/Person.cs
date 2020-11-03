using Newtonsoft.Json;
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
        [JsonIgnore]
        public string FullName => $"{LastName} {FirstName}";
        public Genders Gender { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Today;

        [JsonIgnore]
        public abstract int Id {get;}

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
