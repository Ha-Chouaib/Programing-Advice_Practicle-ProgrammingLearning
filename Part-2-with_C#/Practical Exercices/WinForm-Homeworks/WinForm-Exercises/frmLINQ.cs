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
    public partial class frmLINQ: Form
    {
        public frmLINQ()
        {
            InitializeComponent();
        }

        IEnumerable<Control> GetAllCountrols(Control parent)
        {
            foreach(Control ctrl in parent.Controls)
            {
                yield return ctrl;

                if(ctrl.HasChildren)
                {
                    foreach(Control Child in GetAllCountrols(ctrl))
                    {
                        yield return Child;
                    }
                    
                }
            }
        }
        private void _DisEn_ableAllButs(Control control, bool isEnable)
        {
            if(isEnable)
            {
                foreach(Control ctrl in GetAllCountrols(control).OfType<Button>())
                {
                    ctrl.Enabled = true;
                }
            }
            else
            {
                foreach (Control ctrl in GetAllCountrols(control).OfType<Button>().Where(btn => btn.Tag == null || string.IsNullOrWhiteSpace(btn.Tag.ToString()) ))
                {
                    ctrl.Enabled = false; ;
                }
            }
            
        }
        
        private int _SelectAllEmptyTxtBoxes(Control control)
        {
            int Count = 0;
            foreach(Control ctrl in GetAllCountrols(control).OfType<TextBox>().Where(txtB => txtB.Text == string.Empty))
            {

                ctrl.BackColor = Color.Cyan;
                Count++;
            }
            return Count;
        }
        
        
        private void btnDisableAllBtns_Click(object sender, EventArgs e)
        {
            _DisEn_ableAllButs(this,false);
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            _DisEn_ableAllButs(this, true);
        }

        private void btnSelectEmptyTxtB_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.AutoSize = true;
            btn.Text= "The Number  of Empty Text Boxes is: " + _SelectAllEmptyTxtBoxes(this).ToString();
        }
    }
}
