using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerProject_ThreeCircles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool ka = false;
        double R1, R2, R3, center;
        double a, b, c;


        double k, w1, w2, w3, v;
        Graphics g;
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            R1 = double.Parse(textBox1.Text);
            R2 = double.Parse(textBox2.Text);
            R3 = double.Parse(textBox3.Text);
            w2 = double.Parse(textBox4.Text);
            a = 0; b = 0; c = 0;
            v = w2 * R2;
            w3 = -v / R3;
            w1 = -v / R1;
            label5.Text = "Result(m/s): w1 =" + Math.Round(w1, 2) + ", w2 = " + Math.Round(w2, 2) + ", w3 = " + Math.Round(w3, 2);

            //Scale
            double L = pictureBox1.Width - 50;
            double l = 2 * (R1 + R2 + R3);
            k = l / L;
            R1 = (int)(R1 / k);
            R2 = (int)(R2 / k);
            R3 = (int)(R3 / k);
            label6.Text = "Scale(px:m): 1:" + Math.Round(k, 2);

            //Drawing circles
            center = pictureBox1.Height / 2;
            g = pictureBox1.CreateGraphics();
            g.DrawEllipse(Pens.Black, 25, (int)(center - R1), (int)(R1 * 2), (int)(R1 * 2));
            g.DrawEllipse(Pens.Black, (int)(25 + R1 * 2), (int)(center - R2), (int)(R2 * 2), (int)(R2 * 2));
            g.DrawEllipse(Pens.Black, (int)(25 + R1 * 2 + R2 * 2), (int)(center - R3), (int)(R3 * 2), (int)(R3 * 2));

            ka = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ka)
            {
                g.DrawLine(Pens.White, (int)(25 + R1), (int)center, (int)(25 + R1 + (R1 - 2) * Math.Cos(a)), (int)(center + (R1 - 2) * Math.Sin(a)));
                g.DrawLine(Pens.White, (int)(25 + R2 + 2 * R1), (int)center, (int)(25 + R1 * 2 + R2 + (R2 - 2) * Math.Cos(b)), (int)(center + (R2 - 2) * Math.Sin(b)));
                g.DrawLine(Pens.White, (int)(25 + R3 + 2 * R2 + 2 * R1), (int)center, (int)(25 + R3 + R1 * 2 + R2 * 2 + (R3 - 2) * Math.Cos(c)), (int)(center + (R3 - 2) * Math.Sin(c)));
                a += w1 / 100;
                b += w2 / 100;
                c += w3 / 100;
                g.DrawLine(Pens.Black, (int)(25 + R1), (int)center, (int)(25 + R1 + (R1 - 2) * Math.Cos(a)), (int)(center + (R1 - 2) * Math.Sin(a)));
                g.DrawLine(Pens.Black, (int)(25 + R2 + 2 * R1), (int)center, (int)(25 + R1 * 2 + R2 + (R2 - 2) * Math.Cos(b)), (int)(center + (R2 - 2) * Math.Sin(b)));
                g.DrawLine(Pens.Black, (int)(25 + R3 + 2 * R2 + 2 * R1), (int)center, (int)(25 + R3 + R1 * 2 + R2 * 2 + (R3 - 2) * Math.Cos(c)), (int)(center + (R3 - 2) * Math.Sin(c)));
            }
        }
    }
}
