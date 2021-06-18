using LibGenerateOfDiagrams;
using MainApp.forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MainApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml c 2 вкладкой
    /// </summary>
    public partial class MainWindow : Window
    {
        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
        private void Next_step_2_Click(object sender, RoutedEventArgs e)
        {
            var Commands = "";
            var i = 0;
            foreach (var el in Model.Commands[0].Lists)
            {
                Commands += $" {el.Numb} ( {el.TypeS}, {el.CacheS} ); ";
                var term = new Command
                {
                    Numb = i
                };
                i++;
                term.TimeDo = el.Numb;
                term.Type = el.Type;
                term.Cache = el.Cache;
                Model.Queue.Enqueue(term);
            }

            var Form_View = new Form_view(Model, $"Команды: {Commands}");
            Form_View.ShowDialog();
            
        }
    }
}
