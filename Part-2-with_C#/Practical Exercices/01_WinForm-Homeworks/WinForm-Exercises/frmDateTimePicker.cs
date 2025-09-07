using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_Exercises
{
    public partial class frmDateTimePicker: Form
    {
        public frmDateTimePicker()
        {
            InitializeComponent();
        }

        private void SetDateValueToControle(DateTime dateTime, Control SetTo)
        {

            SetTo.Text = dateTime.ToShortDateString();
            if(SetTo is Label lbl)
            {
                lbl.Text = dateTime.ToShortDateString();

            }else if(SetTo is TextBox txtBox)
            {
                txtBox.Text = dateTime.ToShortDateString();

            }else if (SetTo is Button btn)
            {
                btn.Text = dateTime.ToShortDateString();
            }else
            {
                throw new InvalidExpressionException("Unsuported Control Type");
            }


        }
        private void SetTimeToControl(DateTime time, Control SetTo)
        {
            SetTo.Text = time.ToShortTimeString();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SetDateValueToControle((sender as DateTimePicker).Value, label1);
        }
    }
}
