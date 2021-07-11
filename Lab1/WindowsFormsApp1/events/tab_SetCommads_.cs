using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormLab_1
{
    public partial class MainForm : Form
    {
        private void Btn_step_2_random_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tab_settings_CountCommands.Text, out int int5))
            {
                tab_SetCommads_DataGrid.Rows.Clear();
                foreach (var el in new List<Command>(Computer.RandomOperation(int5).ToArray()))
                {
                    tab_SetCommads_DataGrid.Rows.Add(el.TimeDo, el.TypeS, el.CacheS);
                }
            }
        }

        private void tab_SetCommads_DataGrid_Resize(object sender, System.EventArgs e)
        {
            int columnWidth = (int)(tab_SetCommads_DataGrid.Width / tab_SetCommads_DataGrid.ColumnCount);
            tab_SetCommads_Column1.Width = columnWidth;
            tab_SetCommads_Column2.Width = columnWidth;
            tab_SetCommads_Column3.Width = columnWidth;

        }

        private void Btn_step_2_Click(object sender, EventArgs e)
        {
            var commands_label = "";
            queue.Clear();
            for (var i = 1; i < tab_SetCommads_DataGrid.Rows.Count - 1; i++)
            {
                var term = new Command
                {
                    Numb = i
                };
                if (!int.TryParse(tab_SetCommads_DataGrid.Rows[i].Cells[0].Value.ToString(), out int int1))
                {
                    int1 = 1;
                }
                term.TimeDo = int1;
                term.TypeS = tab_SetCommads_DataGrid.Rows[i].Cells[1].Value.ToString();
                term.CacheS = tab_SetCommads_DataGrid.Rows[i].Cells[2].Value.ToString();
                commands_label += $" {term.TimeDo} т.( {term.CacheS}, {term.TypeS} ); ";
                queue.Enqueue(term);
            }
            MainForm_MainTabControl.SelectedTab = tab_ViewDiagram;
            tab_ViewDiagram_label_Commands.Text = $"Команды: {commands_label}";
            DiagnosticsCommands();
        }

    }
}
