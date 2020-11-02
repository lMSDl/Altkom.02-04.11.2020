using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels
{
    public class StudentsViewModel
    {
        //public ICollection<Student> Students { get; } = new List<Student>() { new Student { FirstName = "Ewa", LastName = "Ewowska" }, new Student { FirstName = "Piotr", LastName = "Piotrowski" } };

        public ICollection<Student> Students { get; }
        public StudentsViewModel() {
            Students = new List<Student>() { new Student { FirstName = "Ewa", LastName = "Ewowska" }, new Student { FirstName = "Piotr", LastName = "Piotrowski" } };
        }
    }
}
