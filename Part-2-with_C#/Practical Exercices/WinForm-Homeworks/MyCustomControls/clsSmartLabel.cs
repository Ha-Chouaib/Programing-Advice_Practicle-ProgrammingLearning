using System;
using System.Windows.Forms;
using System.Drawing;

namespace MyCustomControls
{
    public class clsSmartLabel:Label
    {
        public clsSmartLabel()
        {
            this.AutoSize = true;
        }
        public void Validate()
        {
            if(string.IsNullOrWhiteSpace(this.Text))
            {
                this.BackColor = Color.Red;
            }else
            {
                this.BackColor = Color.White;
            }
        }
    }
}
