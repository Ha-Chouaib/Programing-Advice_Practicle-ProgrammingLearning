using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_Project.Applications.ApplicationTypes
{
    public partial class frmEditApplicationType : Form
    {
        public frmEditApplicationType()
        {
            InitializeComponent();
        }

        public delegate void TriggerFunctionHandler(object sender);
        public event TriggerFunctionHandler ReloadContent;

        short _AppID;
        ErrorProvider errorProv = new ErrorProvider();
        public frmEditApplicationType(short AppID)
        {
            InitializeComponent();
            this._AppID = AppID;
        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _HoldInitialValues();
        }

        private void _HoldInitialValues()
        {
            clsApplicationTypes App = clsApplicationTypes.Find(_AppID);
            if(App != null)
            {
                txtAppTitle.Text = App.AppTitle;
                txtAppFees.Text = App.AppFees.ToString() ;
                lblAppID.Text = App.AppID.ToString();
            }
            else
            {
                MessageBox.Show($"No App With ID << {_AppID} >> is Exist !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAppTitle_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtB = (TextBox)sender;
            if(txtB.Text == string.Empty)
            {
                errorProv.SetError(txtB, "Required field !!");
            }else
            {
                errorProv.SetError(txtB, "");
            }
        }

        private void txtAppFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtAppTitle.Text == string.Empty || txtAppFees.Text == string.Empty)
            {
                txtAppTitle.Validating += txtAppTitle_Validating;
                txtAppFees.Validating += txtAppTitle_Validating;
                return;
            }
            if(MessageBox.Show("The Updates Will be Saved Prementlly","Confirm",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) ==DialogResult.OK)
            {
                clsApplicationTypes App = clsApplicationTypes.Find(_AppID);
                App.AppTitle = txtAppTitle.Text;
                App.AppFees = float.Parse(txtAppFees.Text);
                if(App.SaveAppUpdates())
                {
                    MessageBox.Show("Done Successfully");
                    ReloadContent?.Invoke(this);
                }else
                {
                    MessageBox.Show("Error! Coudn't Save The Current Updates", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else
            {
                MessageBox.Show("The Operation Cancelled Successfully");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
