using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _03_PictureBox.Properties;

namespace _03_PictureBox
{
    public partial class frmCombo: Form
    {
        public frmCombo()
        {
            InitializeComponent();
        }

        private void frmCombo_Load(object sender, EventArgs e)
        {
            cbGetPicture.Items.Add("Book");
            cbGetPicture.Items.Add("Pen");
            cbGetPicture.Items.Add("Boy");
            cbGetPicture.Items.Add("Girl");
            cbGetPicture.SelectedIndex = 1;
            lblTitle.Text = cbGetPicture.Text;
        }

        private void cbGetPicture_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTitle.Text = cbGetPicture.Text;
            if (cbGetPicture.Text == "Book")
            {
                pictureBox1.Image = Resources.Book;
                return;
            }else if(cbGetPicture.Text == "Pen")
            {
                pictureBox1.Image = Resources.Pen;
                return;
            }
            else if (cbGetPicture.Text == "Boy")
            {
                pictureBox1.Image = Resources.Boy;
                return;
            }else
            {
                pictureBox1.Image = Resources.Girl;

            }
        }
    }
}
