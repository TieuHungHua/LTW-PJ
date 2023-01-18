﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_Photo_Editor.Paint_Tools
{
    public partial class Shape : UserControl
    {
        PointF startP;
        PointF endP;
        int size;
        Graphics gSize;
        public Rectangle Rect { get; set; }
        public Pen Pen { get; set; }

        public Shape()
        {
            InitializeComponent();
            Location = new Point(0, 20);
            radioButton1.Checked = true;
            this.Dock = DockStyle.Fill;
            Pen = new Pen(Color.Black, 5);
            size = 5;
            sizeBar.Image = new Bitmap(sizeBar.Width, sizeBar.Height);
            gSize = Graphics.FromImage(sizeBar.Image);
            comboBox1.SelectedIndex = 0;
        }

        public bool Drawed;
        public void GetLocation(PointF p)
        {
            startP = p;
            Drawed = false;
        }

        public void DrawRect(Graphics g, PointF p)
        {
            endP = p;

            Point p1 = new Point((int)Math.Min(startP.X, endP.X), (int)Math.Min(startP.Y, endP.Y));
            Point p2 = new Point((int)Math.Max(startP.X, endP.X), (int)Math.Max(startP.Y, endP.Y));
            Size size = new Size(p2.X - p1.X, p2.Y - p1.Y);

            Rect = new Rectangle(p1.X, p1.Y, size.Width, size.Height);

            Drawed = true;
            Draw(g);
        }

        public void Draw(Graphics g)
        {
            if (!Drawed) return;

            if (radioButton1.Checked)
            {
                if (comboBox1.SelectedIndex == 0)
                    g.DrawRectangle(Pen, Rect);
                else if (comboBox1.SelectedIndex == 1)
                    g.FillRectangle(new SolidBrush(Pen.Color), Rect);
            }
            else if (radioButton2.Checked)
            {
                if (comboBox1.SelectedIndex == 0)
                    g.DrawEllipse(Pen, Rect);
                else if (comboBox1.SelectedIndex == 1)
                    g.FillEllipse(new SolidBrush(Pen.Color), Rect);
            }
        }

        public Color Color
        {
            set
            {
                Pen.Color = value;
            }
        }

        private void Bar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control c = sender as Control;

                int val = (int)((float)e.Location.X / c.Width * 100);
                if (val > 100) val = 100;
                if (val < 0) val = 1;
                size = val;
                label3.Text = size.ToString();
                Pen.Width = size;
                BarUpdate(sizeBar, gSize, size);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            BarUpdate(sizeBar, gSize, size);
        }

        private void BarUpdate(Control sender, Graphics g, int val)
        {
            int w = (int)Math.Ceiling(((float)val / 100) * sender.Width);
            g.Clear(sender.BackColor);
            g.FillRectangle(Brushes.Gainsboro, new Rectangle(0, 0, w, sender.Height));
            sender.Invalidate();
        }
    }
}