using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.Views;

namespace WpfApp.ViewModels
{
    public class StudentsViewModel : PeopleViewModel
    {
        public StudentsViewModel() {
            People = new ObservableCollection<Person>() { new Student { FirstName = "Ewa", LastName = "Ewowska" }, new Student { FirstName = "Piotr", LastName = "Piotrowski" } };
        }

        public override ICommand AddCommand => new CustomCommand(x => AddOrEdit(new Student()));

        protected override Window GetDialogView(Person person)
        {
            return new StudentDialogView(person);
        }
    }
}
