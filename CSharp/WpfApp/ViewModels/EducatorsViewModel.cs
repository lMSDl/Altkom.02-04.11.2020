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
using System.Windows.Threading;
using WpfApp.Commands;
using WpfApp.Views;

namespace WpfApp.ViewModels
{
    public class EducatorsViewModel : PeopleViewModel<Educator>
    {
        private ICrudServiceAsync<Educator> Service { get; } = new CrudServiceAsync<Educator>(); 

        public EducatorsViewModel() {
            Refresh();
        }

        public override ICommand AddCommand => new CustomCommand(x => AddOrEdit(new Educator()));

        protected override Window GetDialogView(Educator person)
        {
            return new EducatorDialogView(person);
        }

        protected async override void Create(Educator person)
        {
            await Service.CreateAsync(person);
        }

        protected async override void Update(Educator person)
        {
           await Service.UpdateAsync(person);
        }

        protected async override void Refresh()
        {
            People = new ObservableCollection<Educator> (await Service.ReadAsync());
        }

        protected override void Delete(Educator person)
        {
            Service.DeleteAsync(person.Id)
                .ContinueWith(task =>
            {
                if(task.Result)
                    Application.Current.Dispatcher.Invoke(() => 
                    People.Remove(person));
            });
        }
    }
}
