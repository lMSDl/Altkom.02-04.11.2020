using Models;
using Services.ClientService;
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
        private IEducatorsService Service { get; } = new EducatorsService(); 

        public EducatorsViewModel() {
            Refresh();
        }

        public override ICommand AddCommand => new CustomCommand(x => AddOrEdit(new Educator()));
        public ICommand FilterCommand => new CustomCommand(async x => People = new ObservableCollection<Educator>( await Service.ReadBySpecializationAsync("asd")));

        protected override Window GetDialogView(Educator person)
        {
            return new EducatorDialogView(person);
        }

        protected async override Task Create(Educator person)
        {
            await Service.CreateAsync(person);
        }

        protected async override Task Update(Educator person)
        {
           await Service.UpdateAsync(person);
        }

        protected async override void Refresh()
        {
            People = new ObservableCollection<Educator> (await Service.ReadAsync());
        }

        protected override Task Delete(Educator person)
        {
            Service.DeleteAsync(person.Id)
                .ContinueWith(task =>
            {
                if(task.Result)
                    Application.Current.Dispatcher.Invoke(() => 
                    People.Remove(person));
            });

            return Task.FromResult(0);
        }
    }
}
