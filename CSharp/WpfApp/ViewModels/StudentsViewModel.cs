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
    public class StudentsViewModel : PeopleViewModel<Student>
    {
        public StudentsViewModel() {
            People = new ObservableCollection<Student>() { new Student { FirstName = "Ewa", LastName = "Ewowska" }, new Student { FirstName = "Piotr", LastName = "Piotrowski" } };
        }

        public override ICommand AddCommand => new CustomCommand(x => AddOrEdit(new Student()));

        protected override void Create(Student person)
        {
            throw new NotImplementedException();
        }

        protected override void Delete(Student person)
        {
            throw new NotImplementedException();
        }

        protected override Window GetDialogView(Student person)
        {
            return new StudentDialogView(person);
        }

        protected override void Refresh()
        {
            throw new NotImplementedException();
        }

        protected override void Update(Student person)
        {
            throw new NotImplementedException();
        }
    }
}
