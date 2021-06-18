using LibGenerateOfDiagrams;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainApp.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        private uint _formRAM;
        private uint _frequencyCP;
        private uint _FrequencyBUS;
        private uint _cacheFetchTime;
        private uint _CountCommands;
        public Graphics gPanel;
        private List<Commands> _Commands = new List<Commands>(1);
        private List<ClassRet> lisrR;
        private Queue<Command> queue;

        public MainViewModel()
        
        {
            FormRAM = 700;
            FrequencyCP =233;
            FrequencyBUS =5;
            CacheFetchTime =1;
            LisrR = null;
            Queue = new Queue<Command>();
        }

        public List<ClassRet> LisrR { get => lisrR; set { lisrR = value;OnPropertyChanged();} }
        public Queue<Command> Queue { get => queue; set { queue = value;OnPropertyChanged();} }
        public uint FormRAM { get => _formRAM; set { _formRAM = value;OnPropertyChanged();} }
        public uint FrequencyCP { get => _frequencyCP; set { _frequencyCP = value;OnPropertyChanged();} }
        public uint FrequencyBUS { get => _FrequencyBUS; set { _FrequencyBUS = value;OnPropertyChanged();} }
        public uint CacheFetchTime { get => _cacheFetchTime; set { _cacheFetchTime = value;OnPropertyChanged();} }
        public List<Commands> Commands { get => _Commands; set { _Commands = value; OnPropertyChanged(); } }
        public uint CountCommands { get => _CountCommands; set { _CountCommands = value; OnPropertyChanged(); } }
    }
}
