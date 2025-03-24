using System;
using System.Windows.Forms;
using MyCustomControls;

namespace WinForm_Exercises
{   
    public partial class frmCustomControl: Form
    {
        public frmCustomControl()
        {
            InitializeComponent();
           

        }

        private void ReseteSmartLable(clsSmartLabel smtLabel)
        {
            smtLabel.Text = string.Empty;
        }
        private void ValidateSmartLabel(clsSmartLabel smtlabel)
        {
            smtlabel.Validate();
        }
        private void frmCustomControl_Load(object sender, EventArgs e)
        {

        }

        private void btnResete_Click(object sender, EventArgs e)
        {
            ReseteSmartLable(clsSmartLabel1);
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            ValidateSmartLabel(clsSmartLabel1);
        }

        private void myHoverButton2_Click(object sender, EventArgs e)
        {
            clsSmartLabel1.Text = "Finaly The Smart Btn Works Also Like Me.";
        }
    }
}
