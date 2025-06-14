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
    public partial class ctrlSimpleEventWithParameters : UserControl
    {
        public ctrlSimpleEventWithParameters()
        {
            InitializeComponent();
        }

        public class GetCalcResultEventArgs : EventArgs
        {
            public int Val1 { get; }
            public int Val2 { get; }
            public int Result { get; }

            public GetCalcResultEventArgs(int Val1,int Val2, int Results)
            {
                this.Val1 = Val1;
                this.Val2 = Val2;
                this.Result = Results;
            }
        }

        public event EventHandler<GetCalcResultEventArgs> OnCalculationComplete;

        public void RaiseOnCalculationComplete(int Val1,int Val2,int Results)
        {
            RaiseOnCalculationComplete(new GetCalcResultEventArgs(Val1,Val2, Results));
        }
        protected virtual void RaiseOnCalculationComplete(GetCalcResultEventArgs e)
        {
            OnCalculationComplete?.Invoke(this, e);
        }

        private void btnGetResult_Click(object sender, EventArgs e)
        {
            int Val1, Val2;
            Val1 = Convert.ToInt32(textBox1.Text);
            Val2 = Convert.ToInt32(textBox2.Text);

            int Results = Val1 + Val2;
            lblResult.Text = Results.ToString();
            if(OnCalculationComplete != null) RaiseOnCalculationComplete(Val1 , Val2, Results); 
        }

    }
}
