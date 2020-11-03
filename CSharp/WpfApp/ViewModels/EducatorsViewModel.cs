using DAL.Services;
using Models;
using Services.Interfaces;
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
    public class EducatorsViewModel : PeopleViewModel<Educator>
    {
        private ICrudService<Educator> Service { get; } = new EducatorService(); 

        public EducatorsViewModel() {
            Refresh();
        }

        public override ICommand AddCommand => new CustomCommand(x => AddOrEdit(new Educator()));

        protected override Window GetDialogView(Educator person)
        {
            return new EducatorDialogView(person);
        }

        protected override void Create(Educator person)
        {
            Service.Create(person);
        }

        protected override void Update(Educator person)
        {
            Service.Update(person);
        }

        protected override void Refresh()
        {
            People = new ObservableCollection<Educator> (Service.Read());
        }

        protected override void Delete(Educator person)
        {
            if (Service.Delete(person.Id))
                People.Remove(person);
        }
    }
}
