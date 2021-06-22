using System;
using System.Windows.Forms;

namespace WinFormLab_1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception e )
            {
                MessageBox.Show($"{e.Message}","Ошибка" );
            }
        }
    }
}
