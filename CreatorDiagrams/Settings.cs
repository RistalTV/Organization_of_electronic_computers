using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CreatorDiagrams.models;

namespace CreatorDiagrams
{
    public partial class Settings : Form
    {
        modelViewModel model;
        public Settings(modelViewModel model)
        {
            InitializeComponent();
            this.model = model;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            model.FrequencyCP = (int)tab_settings_FrequencyCP.Value;
            model.FrequencyBUS = (int)tab_settings_FrequencyBUS.Value;
            model.FormRAM = (int)tab_settings_FormRAM.Value;
            model.CacheFetchTime = (int)tab_settings_CacheFetchTime.Value;
            model.CountCommands = (int)tab_settings_CountCommands.Value;
            this.Close();
        }
    }
}
