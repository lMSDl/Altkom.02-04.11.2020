﻿using Microsoft.Win32;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
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
        public ICommand ToJsonCommand => new CustomCommand(x => ToJson(SelectedPerson), x => SelectedPerson != null);
        public ICommand FromJsonCommand => new CustomCommand(x => FromJson());
        public ICommand ToXmlCommand => new CustomCommand(x => ToXml(SelectedPerson), x => SelectedPerson != null);

        public event PropertyChangedEventHandler PropertyChanged;

        protected void ToXml(T person)
        {
            //var serializer = new XmlSerializer(person.GetType());
            //var memoryStream = new MemoryStream();
            //serializer.Serialize(memoryStream, person);
            //var xml = Encoding.ASCII.GetString(memoryStream.ToArray());
            //memoryStream.Dispose();

            var json = ToJsonString(person);
            var xNode = JsonConvert.DeserializeXNode(json, person.GetType().Name);
        }

        protected void ToJson(T person)
        {
            string json = ToJsonString(person);

            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\{person.FullName}.json", json);
        }

        private static string ToJsonString(T person)
        {
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Newtonsoft.Json.Formatting.Indented,
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(person, settings);

            return json;
        }

        protected void FromJson()
        {
            var dialog = new OpenFileDialog()
            {
                FileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Filter = ".json|*.json|All|*.*"
        };
            if (dialog.ShowDialog() != true)
                return;

            var json = File.ReadAllText(dialog.FileName);
            var person = JsonConvert.DeserializeObject<T>(json);
            AddOrEdit(person);
        }

        protected async virtual void AddOrEdit(T person)
        {
            var clone = (T)person.Clone();
            var dialog = GetDialogView(clone);
            if (dialog.ShowDialog() != true)
            {
                return;
            }

            if (person.Id == 0)
            {
                await Create(clone);
            }
            else
            {
                await Update(clone);
            }
            Refresh();
        }

        protected abstract Task Create(T person);
        protected abstract Task Update(T person);
        protected abstract void Refresh();
        protected abstract Task Delete(T person);

        protected abstract Window GetDialogView(T person);
    }
}
