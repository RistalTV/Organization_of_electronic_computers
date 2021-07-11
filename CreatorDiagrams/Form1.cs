using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CreatorDiagrams.models;

namespace CreatorDiagrams
{
    public partial class Form1 : Form
    {
        public Queue<Command> queue;
        public Bitmap bmp;
        public Graphics gPanel;
        public modelViewModel model;

        public Form1()
        {
            InitializeComponent();
            model = new modelViewModel(); 
            gPanel = Graph.CreateGraphics();
            bmp = new Bitmap(Graph.Width, Graph.Height);
            queue = new Queue<Command>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new Settings(model);
            form.ShowDialog();
            MessageBox.Show(this.model.ToPrint);
            queue = RandomOperation(this.model.CountCommands);
            listCommands.Text = "";
            foreach (var el in new List<Command>(queue.ToArray()))
            {
                listCommands.Text += $"{el.TimeDo}({el.TypeS},{el.CacheS}); ";
            }
        }
        public static Queue<Command> RandomOperation(int N)
        {
            var rand = new Random();
            var queueMain = new Queue<Command>();
            int rand1;
            int rand2;
            for (var i = 0; i < N; i++)
            {
                var tmpCommand = new Command();
                _ = rand.Next(100);
                tmpCommand.Cache = (rand.Next(100) < 75);
                tmpCommand.Numb = i + 1;
                rand1 = rand.Next(100);
                rand2 = rand.Next(100);
                if (rand1 < 20)
                {
                    tmpCommand.Type = true;
                    if (rand2 < 70)
                    {
                        tmpCommand.TimeDo = 5;
                    }
                    else if (rand2 < 90)
                    {
                        tmpCommand.TimeDo = 2;
                    }
                    else
                    {
                        tmpCommand.TimeDo = 1;
                    }
                }
                else if (rand1 < 35)
                {
                    tmpCommand.Type = true;
                    if (rand2 < 70)
                    {
                        tmpCommand.TimeDo = 2;
                    }
                    else if (rand2 < 90)
                    {
                        tmpCommand.TimeDo = 5;
                    }
                    else
                    {
                        tmpCommand.TimeDo = 1;
                    }
                }
                else if (rand1 < 55)
                {
                    tmpCommand.Type = false;
                    if (rand2 < 80)
                    {
                        tmpCommand.TimeDo = 2;
                    }
                    else
                    {
                        tmpCommand.TimeDo = 1;
                    }
                }
                else
                {
                    tmpCommand.Type = true;
                    if (rand2 < 60)
                    {
                        tmpCommand.TimeDo = 2;
                    }
                    else
                    {
                        tmpCommand.TimeDo = 1;
                    }
                }
                queueMain.Enqueue(tmpCommand);
            }
            return queueMain;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Graph_Paint(object sender, PaintEventArgs e)
        {
            Pen p1 = new Pen(Color.Gray, 1);
            Pen p2 = new Pen(Color.Gray, 2);
            Pen p3 = new Pen(Color.Black, 3);
            Pen p4 = new Pen(Color.Black, 3)
            {
                StartCap = LineCap.ArrowAnchor//roundanchor
            };
            Graph.Width = model.delta + 20 * model.CountCommands + 8000;
            bmp = new Bitmap(Graph.Width, Graph.Height);
            gPanel = e.Graphics;
            gPanel = Graphics.FromImage(bmp);
            gPanel.Clear(Color.White);
            // Painting
            // Vetrical line
            gPanel.DrawLine(p1,
                    new Point(
                        model.delta + model.StartPosition.X, 
                        model.StartPosition.Y),
                    new Point(
                        model.delta + model.StartPosition.X,
                        model.StartPosition.Y+model.Height));
            // Vetrical line
            gPanel.DrawLine(p1,
                    new Point(
                        model.delta + model.width_Tact + model.StartPosition.X, 
                        model.StartPosition.Y),
                    new Point(
                        model.delta + model.width_Tact + model.StartPosition.X,
                        model.StartPosition.Y+model.Height));
            // Gorizontal line KK
            gPanel.DrawLine(p2,
                    new Point(
                        model.delta + model.StartPosition.X,
                        model.HeightKK),
                    new Point(
                        model.delta + model.StartPosition.X + Graph.Width,
                        model.HeightKK));
            gPanel.DrawLine(p1,
                    new Point(
                        model.delta + model.StartPosition.X,
                        model.HeightK1),
                    new Point(
                        model.delta + model.StartPosition.X + Graph.Width,
                        model.HeightK1));
            var hBrush = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Gray, Color.White);
            for(var i =0; i < model.CountCommands+200; i++)
            {
                gPanel.DrawLine(p1,
                    new Point(
                        model.delta + model.StartPosition.X + model.width_Tact * i,
                        model.StartPosition.Y),
                    new Point(
                        model.delta + model.StartPosition.X + model.width_Tact * i,
                        model.Height));
            }
            // End painting
            Graph.Image = bmp;
            bmp.Save(Application.StartupPath + "\\diagram.jpeg");
        }
    }
}
