using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PianoGame
{
    public partial class UserControl1 : UserControl
    {
        public int score = 0;
        Rectangle mRectCircle;
        //Form1 MainForm;
        public UserControl1()
        {
            InitializeComponent();
            //this.MainForm = MainForm;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void DrawGauge(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            //g.DrawRectangle(pen, new Rectangle(0, 0, 300, 300));
            g.DrawRectangle(pen, new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            mRectCircle = new Rectangle(this.ClientRectangle.Width / 2, this.ClientRectangle.Height / 2, 10, 10);
            g.DrawEllipse(pen, mRectCircle);

            float x1, y1, x2, y2;
            int[] arr = { 0, 18, 18 * 2, 18 * 3, 18 * 4 };
            foreach (int i in arr)
            {
                x1 = Convert.ToSingle(150 - (Math.Cos(i * Math.PI / 180) * 150));
                y1 = Convert.ToSingle(Math.Sin(i * Math.PI / 180) * 150);
                x2 = Convert.ToSingle(150 - (Math.Cos(i * Math.PI / 180) * 140));
                y2 = Convert.ToSingle(Math.Sin(i * Math.PI / 180) * 140);
                g.DrawLine(pen, 0 + x1, 200 - y1, 0 + x2, 200 - y2);
                g.DrawLine(pen, 300 - x1, 200 - y1, 300 - x2, 200 - y2);
            }
            g.DrawLine(pen, 150, 50, 150, 60);
            
            pen.Dispose();
            //g.Dispose();
        }

        private void DrawArrow(Graphics g)
        {
            Pen pen2 = new Pen(Color.Blue, 3);
            pen2.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            //int score = Convert.ToInt32(MainForm.textBox1.Text);
            //int score = 0;
            double[] arr2 = {1.8,3.6,5.4,7.2,9,10.8,12.6,14.4,16.2,18,19.8,21.6,
                        23.4,25.2,27,28.8,30.6,32.4,34.2,36,37.8,39.6,41.4,43.2,
                45,46.8,48.6,50.4,52.2,54,55.8,57.6,59.4,61.2,63,64.8,66.6,68.4,
                70.2,72,73.8,75.6,77.4,79.2,81,82.8,84.6,86.4,88.2};
            float x1, y1,x2,y2;

            if (score <= 0)
            {
                g.DrawLine(pen2, 0, 200, 150, 200);
            }
            else if (score > 0 && score < 50)
            {
                x1 = Convert.ToSingle(150 - (Math.Cos(arr2[score - 1] * Math.PI / 180) * 150));
                y1 = Convert.ToSingle(Math.Sin(arr2[score - 1] * Math.PI / 180) * 150);
                g.DrawLine(pen2, 0 + x1, 200 - y1, 150, 200);
            }
            else if (score == 50)
            {
                g.DrawLine(pen2, 150, 50, 150, 200);
            }
            else if (score > 50 && score < 100)
            {

                x1 = Convert.ToSingle(150 - (Math.Cos(arr2[100 - score - 1] * Math.PI / 180) * 150));
                y1 = Convert.ToSingle(Math.Sin(arr2[100 - score - 1] * Math.PI / 180) * 150);
                g.DrawLine(pen2, 300 - x1, 200 - y1, 150, 200);
            }
            else if (score >= 100)
            {
                g.DrawLine(pen2, 300, 200, 150, 200);
            }

            pen2.Dispose();
            //g.Dispose();
        }
        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {
            DrawGauge(e.Graphics);

            DrawArrow(e.Graphics);
            e.Dispose();

        }
        public void DoPaint()
        {
            Invalidate();
        }

        private void UserControl1_Resize(object sender, EventArgs e)
        {
            mRectCircle = new Rectangle(this.ClientRectangle.Width / 2, this.ClientRectangle.Height / 2, this.ClientRectangle.Width * 10 / 300, this.ClientRectangle.Height * 10 / 300);

        }
    }
}
