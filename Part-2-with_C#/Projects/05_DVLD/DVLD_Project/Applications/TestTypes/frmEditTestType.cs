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

namespace DVLD_Project.Applications.TestTypes
{
    public partial class frmEditTestType : Form
    {
        clsTestTypes Test;
        short _TestID;
        ErrorProvider errorProv = new ErrorProvider();
        public delegate void TriggerFunctionHandler(object sender);
        public event TriggerFunctionHandler ReloadContent;
        public frmEditTestType()
        {
            InitializeComponent();
        }
        public frmEditTestType(short TestID)
        {
            InitializeComponent();
            this._TestID = TestID;
        }
        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            _LoadOldTestInfo();
        }

        private void _LoadOldTestInfo()
        {
            Test = clsTestTypes.Find(_TestID);
            if (Test != null)
            {
                txtTestTitle.Text = Test.TestTitle;
                txtTestFees.Text = Test.TestFees.ToString();
                txtDescription.Text = Test.TestDescription;
            }
        }


        private void txtTestFields_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtB = (TextBox)sender;
            if(txtB.Text == string.Empty)
            {
                errorProv.SetError(txtB, "Required Field!");
            }else
            {
                errorProv.SetError(txtB, "");
            }

        }

        private void txtTestFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if(e.KeyChar == '.' && txtTestFees.Text.Contains('.'))
            {
                e.Handled = true;
            }
        }


        private void _GetTestUpdatedInfo()
        {
            if (txtTestTitle.Text == string.Empty || txtTestFees.Text == string.Empty || txtDescription.Text == string.Empty)
            {
                txtTestFees.Validating += txtTestFields_Validating;
                txtDescription.Validating += txtTestFields_Validating;
                txtTestFees.Validating += txtTestFields_Validating;
                return;
            }

            Test.TestTitle = txtTestTitle.Text;
            Test.TestFees = float.Parse(txtTestFees.Text);
            Test.TestDescription = txtDescription.Text;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Sure To Save The Current Updated Info","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _GetTestUpdatedInfo();
                if(Test.SaveAppUpdates())
                {
                    MessageBox.Show("Done Successfully");
                    ReloadContent?.Invoke(this);
                }else
                {
                    MessageBox.Show("Error Can't Update This Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else
            {
                MessageBox.Show("Ignored Successfully");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Sure To Leave?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
