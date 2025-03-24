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
    public partial class frmDynamicManipulation: Form
    {
        public frmDynamicManipulation()
        {
            InitializeComponent();
        }

        private void ReseteTextBoxs_Lables(Control parent)
        {
            foreach(Control ctrl in  parent.Controls)
            {
                if(ctrl is TextBox txtbox)
                {
                    txtbox.Clear();
                } 
                if(ctrl is  Label lbl)
                {
                    lbl.Text = "";
                }
                if(ctrl.HasChildren)
                {
                    ReseteTextBoxs_Lables(ctrl);
                }
            }

        }
        
        private void  Dis_En_ableBtns( Control parent, bool IsEnable=true)
        {
            foreach(Control ctrl in parent.Controls )
            {
                if(ctrl is Button btn)
                {
                    btn.Enabled = IsEnable;
                }
                if(ctrl.HasChildren)
                {
                    Dis_En_ableBtns(ctrl, IsEnable);
                }
            }
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            ReseteTextBoxs_Lables(this);
        }

        private void btnDisableBtns_Click(object sender, EventArgs e)
        {
            Dis_En_ableBtns(this,false);
            btnEnableAllbtns.Enabled = true;
        }

        private void btnEnableAllbtns_Click(object sender, EventArgs e)
        {
            Dis_En_ableBtns(this);
        }
    }
}
