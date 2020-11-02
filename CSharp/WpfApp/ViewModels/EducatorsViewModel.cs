using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.Views;

namespace WpfApp.ViewModels
{
    public class EducatorsViewModel
    {
        public ObservableCollection<Educator> Educators { get; }
        public Educator SelectedEducator { get; set; }

        public EducatorsViewModel() {
            Educators = new ObservableCollection<Educator>() { new Educator { FirstName = "Filip", LastName = "Filipowski", Specialization = "Gotowanie" }, new Educator { FirstName = "Monika", LastName = "Monikowska", Specialization = "Mechanika" } };
            DeleteCommand = new CustomCommand(x => Educators.Remove(SelectedEducator), x => SelectedEducator != null && Educators.Contains(SelectedEducator));
        }

        public ICommand DeleteCommand {get; }
        public ICommand AddCommand => new CustomCommand(x => AddOrEdit(new Educator()));
        public ICommand EditCommand => new CustomCommand(x => AddOrEdit(SelectedEducator), x => SelectedEducator != null);

        private void AddOrEdit(Educator selectedEducator)
        {
            var clone = (Educator)selectedEducator.Clone();
            var dialog = new EducatorDialogView(clone);
            if (dialog.ShowDialog() != true)
            {
                return;
            }

            if (Educators.Contains(selectedEducator))
                Educators.Remove(selectedEducator);
            Educators.Add(clone);
        }
    }
}
