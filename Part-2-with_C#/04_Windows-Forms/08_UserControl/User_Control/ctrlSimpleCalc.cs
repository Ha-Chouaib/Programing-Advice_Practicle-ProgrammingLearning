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
        public event Action<int> OnCalculationComplete;

        protected void CalculationComplete(int ID)
        {
            Action<int> handler = OnCalculationComplete;
            if (handler != null) handler(ID);

        }
        public float Result
        {
            get { return (float)Convert.ToDouble(lblresult.Text); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result = (int.Parse(textBox1.Text) + int.Parse(textBox2.Text));
            lblresult.Text =result.ToString();
            if (OnCalculationComplete != null) CalculationComplete(result);
        }
    }
}
