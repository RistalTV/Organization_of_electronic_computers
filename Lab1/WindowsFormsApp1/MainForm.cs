using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace WinFormLab_1
{
    public partial class MainForm : Form
    {
        List<ClassRet> lisrR;
        public Queue<Command> queue;
        private Bitmap bmp;
        Graphics gPanel;
        
        public MainForm()
        {
            InitializeComponent();
            gPanel = tab_ViewDiagram_Graph.CreateGraphics();
            bmp = new Bitmap(tab_ViewDiagram_Graph.Width, tab_ViewDiagram_Graph.Height);
            lisrR = null;
            queue = new Queue<Command>();
            tab_settings_FrequencyCP.Text = "700";
            tab_settings_FrequencyBUS.Text = "233";
            tab_settings_FormRAM.Text = "5";
            tab_settings_CacheFetchTime.Text = "1";
        }

        
    }
}
