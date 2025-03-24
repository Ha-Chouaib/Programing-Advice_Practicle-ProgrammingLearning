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
    public partial class frmErrorProvider: Form
    {
        public frmErrorProvider()
        {
            InitializeComponent();
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                e.Cancel = true;//Force the User To Stay on the txtBox Can not leave it
                txtFirstName.Focus();
                errorProvider1.SetError(txtFirstName, "First Name Should Have a value");
            }else
            {
                e.Cancel = false;//Can leave txtBox
                errorProvider1.SetError(txtFirstName, "");
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                e.Cancel = true;
                txtLastName.Focus();
                errorProvider1.SetError(txtLastName, "Last Name Field Should not be empty");
            }else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtLastName, "");
            }
        }
    }
}
