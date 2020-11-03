using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Commands;

namespace WpfApp.ViewModels
{
    public abstract class PeopleViewModel<T> : INotifyPropertyChanged where T : Person
    {
        private ObservableCollection<T> _people;

        public ObservableCollection<T> People
        {
            get => _people;
            protected set
            {
                _people = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(People)));
            }
        }
        public T SelectedPerson { get; set; }

        public PeopleViewModel()
        {
            DeleteCommand = new CustomCommand(x => Delete(SelectedPerson), x => SelectedPerson != null && People.Contains(SelectedPerson));
        }

        public ICommand DeleteCommand { get; }
        public abstract ICommand AddCommand { get; }
        public ICommand EditCommand => new CustomCommand(x => AddOrEdit(SelectedPerson), x => SelectedPerson != null);

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void AddOrEdit(T person)
        {
            var clone = (T)person.Clone();
            var dialog = GetDialogView(clone);
            if (dialog.ShowDialog() != true)
            {
                return;
            }

            if (person.Id == 0)
            {
                Create(clone);
            }
            else
            {
                Update(clone);
            }
            Refresh();
        }

        protected abstract void Create(T person);
        protected abstract void Update(T person);
        protected abstract void Refresh();
        protected abstract void Delete(T person);

        protected abstract Window GetDialogView(T person);
    }
}
