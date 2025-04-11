using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04_Drawing
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color Black = Color.Black;
            Pen Pen = new Pen(Black);
            Pen.Width = 8;

            // Determine the Pen Ends aspects
            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Triangle;

            //Draw Line
            e.Graphics.DrawLine(Pen, 200, 200, 200, 300);

            e.Graphics.DrawRectangle(Pen, 400, 400, 500, 500);
            e.Graphics.DrawEllipse(Pen, 700, 30, 200, 100);
        }
    }
}
