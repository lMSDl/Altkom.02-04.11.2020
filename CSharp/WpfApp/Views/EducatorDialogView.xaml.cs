﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp.ViewModels;

namespace WpfApp.Views
{
    /// <summary>
    /// Interaction logic for EducatorDialogView.xaml
    /// </summary>
    public partial class EducatorDialogView : Window
    {
        public EducatorDialogView(Person person)
        {
            InitializeComponent();
            DataContext = new PersonDialogViewModel() { Person = person };
        }
    }
}
