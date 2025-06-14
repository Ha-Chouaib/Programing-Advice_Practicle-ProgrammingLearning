using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp_Level2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ctrlSimpleEvent1_OnbtnCliked(string obj)
        {
            MessageBox.Show(obj);
        }

        private void ctrlSimpleEventWithParameters1_OnCalculationComplete(object sender, ctrlSimpleEventWithParameters.GetCalcResultEventArgs e)
        {
            MessageBox.Show($"Result= {e.Result}, Val1= {e.Val1}, Val2= {e.Val2}");
        }
    }
}
