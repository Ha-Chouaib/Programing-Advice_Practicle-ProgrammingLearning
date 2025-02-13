using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_FirstWinFormsPro
{
    public partial class Frm_Main: Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {

        }

        private void btnShowPart1_Click(object sender, EventArgs e)
        {
            Form Frm1 = new Form1();
            Frm1.Show();
        }

        private void btn_ShowForm1AsDaialog_Click(object sender, EventArgs e)
        {
            Form Frm1 = new Form1();
            Frm1.ShowDialog();
        }

        private void btnMSG_BoxForm_Click(object sender, EventArgs e)
        {
            Form frmMSGBox = new MessageBoxForm();
            frmMSGBox.ShowDialog();
        }

        private void btnToRadio_Click(object sender, EventArgs e)
        {
            Form frmCheckBoxForm = new RadioBoxForm();
            frmCheckBoxForm.Show();
        }
    }
}
