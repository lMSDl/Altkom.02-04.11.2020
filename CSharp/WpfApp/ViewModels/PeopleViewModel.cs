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

namespace WpfApp.ViewModels
{
    public abstract class PeopleViewModel
    {
        public ObservableCollection<Person> People { get; protected set; }
        public Person SelectedPerson { get; set; }

        public PeopleViewModel()
        {
            DeleteCommand = new CustomCommand(x => People.Remove(SelectedPerson), x => SelectedPerson != null && People.Contains(SelectedPerson));
        }

        public ICommand DeleteCommand { get; }
        public abstract ICommand AddCommand { get; }
        public ICommand EditCommand => new CustomCommand(x => AddOrEdit(SelectedPerson), x => SelectedPerson != null);

        protected virtual void AddOrEdit(Person person)
        {
            var clone = (Person)person.Clone();
            var dialog = GetDialogView(clone);
            if (dialog.ShowDialog() != true)
            {
                return;
            }

            if (People.Contains(SelectedPerson))
                People.Remove(SelectedPerson);
            People.Add(clone);
        }

        protected abstract Window GetDialogView(Person person);
    }
}
