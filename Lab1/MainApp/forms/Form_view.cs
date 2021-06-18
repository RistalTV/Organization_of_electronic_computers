using LibGenerateOfDiagrams;
using MainApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace MainApp.forms
{
    public partial class Form_view : Form
    {
        readonly MainViewModel Model;
        public List<ClassRet> lisrR;
        public Queue<Command> queue;
        public Graphics gPanel;
        public Form_view(MainViewModel model, string commands)
        {
            InitializeComponent();
            label_commands.Text = commands;
            Model = model;
            lisrR = Model.LisrR;
            queue = Model.Queue;
            Model.gPanel = pictureBox1.CreateGraphics();
            gPanel = Model.gPanel;
            
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (lisrR != null)
            {
                Pen p1 = new Pen(Color.Gray, 1);
                Pen p2 = new Pen(Color.Gray, 2);
                Pen p3 = new Pen(Color.Black, 3);
                Pen p4 = new Pen(Color.Black, 3)
                {
                    StartCap = LineCap.ArrowAnchor//roundanchor
                };
                ClassRet LasrR = new ClassRet() { Cash = false, CashN = 0, Conveer = 0, ConveerN = 0 };
                pictureBox1.Width = 20 * lisrR.Count + 40;
                gPanel = e.Graphics;
                gPanel.Clear(Color.White);
                gPanel.DrawLine(p1,
                    new Point(0, 0),
                    new Point(0, 250));
                gPanel.DrawLine(p1,
                    new Point(20, 0),
                    new Point(20, 250));
                gPanel.DrawLine(p2,
                    new Point(0, 100),
                    new Point(20, 100));
                gPanel.DrawLine(p1,
                    new Point(0, 200),
                    new Point(20, 200));
                var i = 2;
                var hBrush = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Gray, Color.White);
                foreach (var item in lisrR)
                {
                    gPanel.DrawLine(p1,
                        new Point(20 * i, 0),
                        new Point(20 * i, 250));
                    gPanel.DrawLine(p2,
                        new Point(20 * (i - 1), 100),
                        new Point(20 * i, 100));
                    gPanel.DrawLine(p1,
                        new Point(20 * (i - 1), 200),
                        new Point(20 * i, 200));
                    if (LasrR.Conveer != item.Conveer || LasrR.ConveerN != item.ConveerN)
                    {
                        if (LasrR.ConveerN != 0)
                        {
                            if (LasrR.Conveer == 1)
                            {
                                gPanel.DrawLine(p3,
                                    new Point(20 * (i - 1), 100),
                                    new Point(20 * (i - 1), 80));
                            }
                            else if (LasrR.Conveer != 0)
                            {
                                gPanel.DrawLine(p3,
                                    new Point(20 * (i - 1), 100),
                                    new Point(20 * (i - 1), 120));
                            }
                        }
                        if (item.ConveerN != 0)
                        {
                            if (item.Conveer == 1)
                            {
                                gPanel.DrawString(item.ConveerN.ToString(), this.Font, Brushes.Black,
                                    new Point(20 * (i - 1), 80));
                                gPanel.DrawLine(p3,
                                    new Point(20 * (i - 1), 100),
                                    new Point(20 * (i - 1), 80));
                            }
                            else if (item.Conveer != 0)
                            {
                                gPanel.DrawString(item.ConveerN.ToString(), Font, Brushes.Black,
                                    new Point(20 * (i - 1), 80));
                                gPanel.DrawLine(p3,
                                    new Point(20 * (i - 1), 100),
                                    new Point(20 * (i - 1), 120));
                            }
                        }
                    }
                    if (item.ConveerN != 0)
                    {

                        if (item.Conveer == 1)
                        {
                            gPanel.DrawLine(p3,
                                new Point(20 * (i - 1), 80),
                                new Point(20 * (i), 80));
                        }
                        else if (item.Conveer != 0)
                        {
                            if (item.Conveer == 3)
                            {
                                gPanel.FillClosedCurve(hBrush,
                                    new PointF[] {
                                        new PointF(20 * (i - 1) + 3 , 103),
                                        new PointF(20 * (i) - 3     , 103),
                                        new PointF(20 * (i) - 3     , 117),
                                        new PointF(20 * (i - 1) + 3 , 117)
                                    });
                            }
                            gPanel.DrawLine(p3,
                                new Point(20 * (i - 1), 120),
                                new Point(20 * (i), 120));
                        }
                    }
                    if (LasrR.CashN != item.CashN)
                    {
                        if (LasrR.Cash || item.Cash)
                        {
                            if (item.Cash)
                            {
                                gPanel.DrawString(item.CashN.ToString(), this.Font, Brushes.Black,
                                    new Point(20 * (i - 1), 160));
                            }
                            gPanel.DrawLine(p3,
                                new Point(20 * (i - 1), 200),
                                new Point(20 * (i - 1), 180));
                        }
                    }
                    if (item.CashN != 0)
                    {
                        gPanel.FillClosedCurve(hBrush,
                            new PointF[] {
                                new PointF(20 * (i - 1) + 3, 183),
                                new PointF(20 * (i) - 3, 183),
                                new PointF(20 * (i) - 3, 197),
                                new PointF(20 * (i - 1) + 3, 197)
                            });
                        gPanel.DrawLine(p3,
                            new Point(20 * (i - 1), 180),
                            new Point(20 * (i), 180));
                    }
                    if (item.ListQuest.Count != 0)
                    {
                        gPanel.DrawLine(p4,
                            new Point(20 * (i - 1), 50),
                            new Point(20 * (i - 1), 100));
                        gPanel.DrawString(item.ListQuest[0].ToString(), this.Font, Brushes.Black,
                            new Point(20 * (i - 1), 50));
                        var i2 = 1;
                        for (var i1 = 1; i1 < item.ListQuest.Count; i1++)
                        {
                            if (i1 < 4)
                            {
                                gPanel.DrawLine(p4,
                                    new Point(20 * (i - 1), 50 - i1 * 10),
                                    new Point(20 * (i - 1), 60 - i1 * 10));
                                gPanel.DrawString(item.ListQuest[i1].ToString(), this.Font, Brushes.Black,
                                    new Point(20 * (i - 1), 50 - i1 * 10));
                            }
                            else
                            {
                                gPanel.DrawString(item.ListQuest[i1].ToString(), this.Font, Brushes.Black,
                                    new Point(20 * (i - 1) + i2 * 10, 10));
                                i2++;
                            }
                        }
                    }
                    i++;
                    LasrR = item;
                }
                if (LasrR.ConveerN != 0)
                {
                    if (LasrR.Conveer == 1)
                    {
                        gPanel.DrawLine(p3,
                            new Point(20 * (i - 1), 100),
                            new Point(20 * (i - 1), 80));
                    }
                    else if (LasrR.Conveer != 0)
                    {
                        gPanel.DrawLine(p3,
                            new Point(20 * (i - 1), 100),
                            new Point(20 * (i - 1), 120));
                    }
                }
                if (LasrR.CashN != 0)
                {
                    gPanel.DrawLine(p3,
                        new Point(20 * (i - 1), 200),
                        new Point(20 * (i - 1), 180));
                }
                gPanel.DrawLine(p2,
                    new Point(20 * (i - 1), 100),
                    new Point(20 * i, 100));
                gPanel.DrawLine(p1,
                    new Point(20 * (i - 1), 200),
                    new Point(20 * i, 200));
            }
        }

        private void Forming_diagrams_Click(object sender, EventArgs e)
        {

            if (queue != null)
            {
                var copyQueue = new Queue<Command>(queue);
                lisrR = Computer.DoDo(copyQueue, (int)Model.CacheFetchTime, (int)Model.FormRAM, (int)Model.FrequencyCP / (int)Model.FrequencyBUS);
            }

            pictureBox1.Invalidate();
        }

        private void Form_view_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void Form_view_FormClosed(object sender, FormClosingEventArgs e)
        {

            this.Hide();
        }
    }
}
