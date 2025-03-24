using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _03_PictureBox.Properties;

namespace _03_PictureBox
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void rbBoy_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBoy.Checked)
            {
                pictureBox1.Image = Resources.Boy;
                lblTitle.Text = ((RadioButton)sender).Tag.ToString();
            }
        }

        private void rbGirl_CheckedChanged(object sender, EventArgs e)
        {
            if(rbGirl.Checked)
            {
                pictureBox1.Image = Resources.Girl;
                lblTitle.Text = ((RadioButton)sender).Tag.ToString();

            }
        }

        private void rbBook_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBook.Checked)
            {
                pictureBox1.Image = Resources.Book;
                lblTitle.Text = ((RadioButton)sender).Tag.ToString();

            }
        }

        private void rbPen_CheckedChanged(object sender, EventArgs e)
        {
            if(rbPen.Checked)
            {
                pictureBox1.Image = Resources.Pen;
                lblTitle.Text = ((RadioButton)sender).Tag.ToString();

            }
        }

        private void btnToCombo_Click(object sender, EventArgs e)
        {
            Form frmCombo = new frmCombo();
            frmCombo.Show();
        }
    }
}
