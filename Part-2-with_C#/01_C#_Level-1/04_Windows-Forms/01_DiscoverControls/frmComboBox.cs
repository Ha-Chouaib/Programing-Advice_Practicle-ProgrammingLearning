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
    public partial class frmComboBox: Form
    {
        public frmComboBox()
        {
            InitializeComponent();
        }

       

        private void frmComboBox_Load(object sender, EventArgs e)
        {
            //To Set The Default option in The Combo
            comboBox1.SelectedIndex = 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Sql");

        }
    }
}
