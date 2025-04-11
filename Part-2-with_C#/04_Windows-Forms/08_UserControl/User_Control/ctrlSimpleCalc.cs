using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Control
{
    public partial class ctrlSimpleCalc: UserControl
    {
        public ctrlSimpleCalc()
        {
            InitializeComponent();
        }
        public float Result
        {
            get { return (float)Convert.ToDouble(lblresult.Text); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblresult.Text =(float.Parse( textBox1.Text) + float.Parse(textBox2.Text)).ToString();
        }
    }
}
