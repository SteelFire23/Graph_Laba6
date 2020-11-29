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

namespace Graph_Laba6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(pictureBox1.BackColor);

            PrintEnvironment(g, pictureBox1.Width, pictureBox1.Height);
            PrintRoad(g, pictureBox1.Width, pictureBox1.Height);
            PrintBus(g, pictureBox1.Width, pictureBox1.Height);
            g.Dispose();
        }
        public static void PrintRoad(Graphics g, float width, float height)
        {
            SolidBrush grayBrush = new SolidBrush(Color.Gray);
            Pen markupPen = new Pen(Color.White, 5);

            markupPen.DashStyle = DashStyle.Dash;
            markupPen.DashPattern = new float[] { 25, 5 };

            g.FillRectangle(grayBrush, 0, height / 2, width, height / 4);
            g.DrawLine(markupPen, 0, (height / 2) + (height / 8), width, (height / 2) + (height / 8));           
        }
        public static void PrintBus(Graphics g, float width, float height)
        {
            float offsetX = width / 4,
                  offsetY = height / 4;
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush blueBrush = new SolidBrush(Color.AliceBlue);
            Pen pen = new Pen(Color.Black, 1);

            RectangleF[] wheels = new RectangleF[3];
            wheels[0].Location = new PointF(width / 2 - 0.7f * offsetX, 2.2f * offsetY);
            wheels[1].Location = new PointF(width / 2 - 0.7f * offsetX + offsetY / 2, 2.2f * offsetY);
            wheels[2].Location = new PointF(width / 2 + 0.7f * offsetX, 2.2f * offsetY);
            g.FillRectangle(redBrush, width / 2 - offsetX, height / 2 - offsetY, width / 2, 1.5f * offsetY);
            g.FillRectangle(blueBrush, width / 2 + offsetX / 2, height / 2 - 0.8f * offsetY, offsetX / 2, 0.8f * offsetY);
            g.FillRectangle(blueBrush, width / 2 - 0.8f * offsetX, height / 2 - 0.8f * offsetY, offsetX, offsetY / 2);
            g.DrawRectangle(pen, width / 2 + 0.22f * offsetX, height / 2 - 0.7f * offsetY, offsetY / 2, offsetY);
            for(int i = 0; i < wheels.Length; i++)
            {
                wheels[i].Width = offsetY / 2;
                wheels[i].Height = offsetY / 2;
                g.FillEllipse(blackBrush, wheels[i]);
            }
        }
        public static void PrintEnvironment(Graphics g, float width, float height)
        {
            SolidBrush greenBrush = new SolidBrush(Color.LightGreen);
            SolidBrush skyBrush = new SolidBrush(Color.LightBlue);
            g.FillRectangle(greenBrush, 0, height / 2 + height / 4, width, height / 4);
            g.FillRectangle(skyBrush, 0, 0, width, height / 2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(pictureBox1.BackColor);
        }
    }
}
