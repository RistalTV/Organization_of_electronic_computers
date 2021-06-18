using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormLab_1
{
    public partial class MainForm : Form
    {
        private void Btn_step_3_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tab_settings_FrequencyCP.Text, out int int1) && 
                int.TryParse(tab_settings_FrequencyBUS.Text, out int int2) && 
                int.TryParse(tab_settings_FormRAM.Text, out int int3) && 
                int.TryParse(tab_settings_CacheFetchTime.Text, out int int4) && 
                queue != null)
            {
                var copyQueue = new Queue<Command>(queue);
                lisrR = Computer.DoDo(copyQueue, int4, int3, int1 / int2);
            }
            tab_ViewDiagram_Graph.Invalidate();
        }

        private void tab_ViewDiagram_Graph_Paint(object sender, PaintEventArgs e)
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
                tab_ViewDiagram_Graph.Width = 20 * lisrR.Count + 40;
                bmp = new Bitmap(tab_ViewDiagram_Graph.Width, tab_ViewDiagram_Graph.Height);
                gPanel = e.Graphics;
                gPanel = Graphics.FromImage(bmp);
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
                                gPanel.DrawString(item.ConveerN.ToString(), this.Font, Brushes.Black,
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
                tab_ViewDiagram_Graph.Image = bmp;
            }
        }


        private async void DiagnosticsCommands()
        {
            if (int.TryParse(tab_settings_FrequencyCP.Text, out int int1) &&
                int.TryParse(tab_settings_FrequencyBUS.Text, out int int2) &&
                int.TryParse(tab_settings_FormRAM.Text, out int int3) &&
                int.TryParse(tab_settings_CacheFetchTime.Text, out int int4) &&
                int.TryParse(tab_settings_CountCommands.Text, out int int5)
                && int5 < 99)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                await Computer.DoDoM(queue, int1 / int2, int4, int3);
                watch.Stop();
                try
                {
                    tab_ViewDiagram_label_Diagnostic.Text = $"Производительность: {int5 / (int)(watch.ElapsedMilliseconds / 100)}";
                }
                catch(Exception e)
                {
                    tab_ViewDiagram_label_Diagnostic.Text = $"Ошибка: {e.Message}";
                    return;
                }
            }
        }
    }
}
