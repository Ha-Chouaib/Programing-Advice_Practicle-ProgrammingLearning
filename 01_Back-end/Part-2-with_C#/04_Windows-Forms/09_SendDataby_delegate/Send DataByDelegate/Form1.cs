using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Send_DataByDelegate
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frmForm2 = new Form2();
            frmForm2.SendDataBack += GetDataFromForm2;
            frmForm2.Show();
        }
        private void GetDataFromForm2(object sender, int PersonID)
        {
            textBox1.Text = PersonID.ToString();
        }
    }
}
