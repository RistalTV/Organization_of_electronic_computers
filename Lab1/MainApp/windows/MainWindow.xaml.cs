using LibGenerateOfDiagrams;
using MainApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MainApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel Model { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            this.Model = new MainViewModel();
            this.DataContext = this.Model;
        }

        
    }
}
