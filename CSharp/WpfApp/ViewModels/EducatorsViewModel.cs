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
    public class EducatorsViewModel : PeopleViewModel
    {

        public EducatorsViewModel() {
            People = new ObservableCollection<Person>() { new Educator { FirstName = "Filip", LastName = "Filipowski", Specialization = "Gotowanie" }, new Educator { FirstName = "Monika", LastName = "Monikowska", Specialization = "Mechanika" } };
            
        }

        public override ICommand AddCommand => new CustomCommand(x => AddOrEdit(new Educator()));

        protected override Window GetDialogView(Person person)
        {
            return new EducatorDialogView(person);
        }
    }
}
