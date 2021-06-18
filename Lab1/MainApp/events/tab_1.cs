using LibGenerateOfDiagrams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MainApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml c 1 вкладкой
    /// </summary>
    public partial class MainWindow : Window
    {
        private void next_step_1_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(CountCommands.Model.Value.ToString(), out int CountCommand))
            {
                MessageBox.Show("Ошибка");
            }
            Model.Commands.Clear();
            Model.Commands.Add(new Commands(geterate_command(CountCommand)));
            this.Lists_of_Commands.ItemsSource = Model.Commands[0].Lists;
            MainTab.SelectedItem = Commands;
        }

        private List<Command> geterate_command(int CountCommand)
        {
            var Cache = true;
            var Type = true;
            var Num = 0;
            var ChanceCache1 = 85;
            var ChanceCache2 = 90;
            var ChanceCO = 15;
            var ChanceMDO = 20;
            var ChanceMSO = 15;
            var commands = new List<Command>(CountCommand);

            for (var i = 0; i < CountCommand; i++)
            {
                Random rnd = new Random(DateTime.Now.Second);
                int chance = rnd.Next(1, 101);
                if (chance <= ChanceCO) // Управление Объектом
                {
                    Type = false;
                    chance = rnd.Next(1, 11);
                    if (chance <= 2) // 20%
                    {
                        Num = 1;
                        rnd = new Random(DateTime.Now.Second);
                        chance = rnd.Next(1, 101);
                        if (chance <= ChanceCache1)
                            Cache = false;
                        else
                            Cache = true;
                    }
                    else  // 80%
                    {
                        Num = 2;
                        rnd = new Random(DateTime.Now.Second);
                        chance = rnd.Next(1, 101);
                        if (chance <= ChanceCache2)
                            Cache = false;
                        else
                            Cache = true;
                    }
                }
                else// Остальные комманды
                {
                    Type = true;
                    rnd = new Random(DateTime.Now.Second);
                    chance = rnd.Next(1, 101);

                    if (chance <= ChanceMSO)// Моделирование систем объекта
                    {
                        rnd = new Random(DateTime.Now.Second);
                        chance = rnd.Next(1, 11);
                        if (chance <= 1)//10%
                        { Num = 1; }
                        else if (chance <= 2)// 20%
                        { Num = 5; }
                        else//70%
                        { Num = 2; }
                    }
                    else if (chance <= ChanceMDO)// Моделирование динамики объекта
                    {
                        rnd = new Random(DateTime.Now.Second);
                        chance = rnd.Next(1, 11);
                        if (chance <= 1)//10%
                        { Num = 1; }
                        else if (chance <= 2)// 20%
                        { Num = 2; }
                        else//70%
                        { Num = 5; }
                    }
                    else // Дисперизация вычислительного процесса
                    {
                        rnd = new Random(DateTime.Now.Second);
                        chance = rnd.Next(1, 11);
                        if (chance <= 4)//40%
                        { Num = 1; }
                        else // 60%
                        { Num = 2; }
                    }
                }
                commands.Add(
                    new Command()
                    {
                        Cache = Cache,
                        Type = Type,
                        Numb = Num
                    }
                    );
            }
            return commands;
        }

    }
}
