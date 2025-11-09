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
    public partial class frmGenericFunctions: Form
    {
        public frmGenericFunctions()
        {
            InitializeComponent();
        }

        private void _ChangeControlText(Control ctrl, string txt)
        {
             if(ctrl is TextBox txtB )
             {
                txtB.Text = txt;
             }
             if(ctrl is Label lbl)
             {
                 lbl.Text = txt;
             }
             if(ctrl is Button btn)
             {
                 btn.Text = txt;
             }
            
        }

        private void _ApplyUniformStyle(Control control)
        {
            foreach(Control ctrl in control.Controls)
            {
                if(ctrl is TextBox txtb)
                {
                    txtb.ForeColor = Color.BurlyWood;
                    txtb.BorderStyle = BorderStyle.None;
                }
                if(ctrl is Button btn)
                {
                    btn.BackColor = Color.Black;
                    btn.ForeColor = Color.Bisque;
                    btn.Font = new Font("Impact", 15,FontStyle.Bold);
                        
                 }
                if(ctrl is Label lbl)
                {
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Font =new Font("Arial", 12, FontStyle.Italic);
                }
                if(ctrl is Panel pnl)
                {
                    pnl.BackColor = Color.Aquamarine;
                }

                if (control.HasChildren)
                {
                    _ApplyUniformStyle(ctrl);
                }
            }

          
        }
        private void btnChangeBtnTxt_Click(object sender, EventArgs e)
        {
            _ChangeControlText(btn,"I am a Button");

        }

        private void btnChangeTxtBoxText_Click(object sender, EventArgs e)
        {
            _ChangeControlText(txtbox, "I am a TextBox");

        }

        private void btnChangelblTxt_Click(object sender, EventArgs e)
        {
            _ChangeControlText(lbl, "I am a Label");

        }

        private void btnApplyUniformStyle_Click(object sender, EventArgs e)
        {
            _ApplyUniformStyle(this);
        }
    }
}
