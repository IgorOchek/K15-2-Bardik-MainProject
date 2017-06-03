using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace lab02
{
    public partial class Form1 : Form
    {
        int x = 0, y = 50, r = 20;
        int centerX, centerY;
        int a = 200;
        int m = 5;
        LinkedList<Point[]> points = new LinkedList<Point[]>();
        Point lastPoint;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.FillEllipse(Brushes.Red, lastPoint.X - r / 2, lastPoint.Y - r / 2, r, r);    
            foreach(Point[] p in points)
            {
                gr.DrawLine(Pens.Red, p[0], p[1]);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point[] p = new Point[2];
            p[0] = new Point(centerX + x,centerY - y);
            lastPoint = p[0];
            x = (int)(a * Math.Log((a + Math.Sqrt(Math.Pow(a, 2) - Math.Pow(y, 2)))/y) - Math.Sqrt(Math.Pow(a, 2) - Math.Pow(y, 2)));
            y += 1;
            if (y >= a) timer1.Enabled = false;
            p[1] = new Point(centerX + x,centerY - y);
            points.AddLast(p);
            points.AddLast(new Point[] { new Point(-p[0].X + centerX * 2, p[0].Y), new Point(-p[1].X + centerX * 2, p[1].Y) });
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            centerX = ClientRectangle.Width / 2;
            centerY = ClientRectangle.Height / 2;
        }
    }
}
