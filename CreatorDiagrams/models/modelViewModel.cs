using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatorDiagrams.models
{
    public class modelViewModel
    {
        public int FrequencyCP = 1;
        public int FrequencyBUS = 1;
        public int FormRAM = 1;
        public int CacheFetchTime = 1;
        public int CountCommands = 1;
        public int delta = 0;
        public int Height = 250;
        public int width_Tact = 20;
        public int HeightKK = 100;
        public int HeightK1 = 200;
        public string ToPrint =>  $"{FrequencyCP}\n{FrequencyBUS}\n{FormRAM}\n{CacheFetchTime}\n{CountCommands}\n";
        public Point StartPosition = new Point(0,0);
        public Point EndPosition = new Point(0, 0);
        public Point SelectStart = new Point(0, 0);
        public Point SelectEnd = new Point(0, 0);

    }
}
