using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormLab_1
{
    public partial class MainForm : Form
    {
        private void Btn_step_1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tab_settings_CountCommands.Text, out int int5))
            {
                tab_SetCommads_DataGrid.Rows.Clear();
                foreach(var el in new List<Command>(Computer.RandomOperation(int5).ToArray()))
                {
                    tab_SetCommads_DataGrid.Rows.Add(el.TimeDo,el.TypeS,el.CacheS);
                }
                int columnWidth = (int)(tab_SetCommads_DataGrid.Width / tab_SetCommads_DataGrid.ColumnCount);
                tab_SetCommads_Column1.Width = columnWidth;
                tab_SetCommads_Column2.Width = columnWidth;
                tab_SetCommads_Column3.Width = columnWidth;
                MainForm_MainTabControl.SelectedTab = tab_SetCommads;
            }
        }

    }
}
