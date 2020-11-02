using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels
{
    public class EducatorsViewModel
    {
        //public ICollection<Student> Students { get; } = new List<Student>() { new Student { FirstName = "Ewa", LastName = "Ewowska" }, new Student { FirstName = "Piotr", LastName = "Piotrowski" } };

        public ICollection<Educator> Educators { get; }
        public EducatorsViewModel() {
            Educators = new List<Educator>() { new Educator { FirstName = "Filip", LastName = "Filipowski", Specialization = "Gotowanie" }, new Educator { FirstName = "Monika", LastName = "Monikowska", Specialization = "Mechanika" } };
        }
    }
}
