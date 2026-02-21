using Bank_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Person
{
    public partial class frmAddNewPerson : Form
    {
        public frmAddNewPerson()
        {
            InitializeComponent();
            _HasPermissions();
            ctrlAddEditPerson1.OnPersonAdded_Updated += _GetNewPersonAdded;
            ctrlAddEditPerson1.OnOperationCanceled += _LeaveForm;
        }
        private void _HasPermissions()
        {
            if (!clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.People_Add))
            {
                MessageBox.Show("You don't have permission to add new person record.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Load += (s, e) => this.Close();
                return;
            }
        }
        clsPerson _Person= new clsPerson();
        public Action __RefreshContent;
        public Action<clsPerson> __PersonAdded;
        private void _GetNewPersonAdded(object sender, clsPerson person)
        {
            if (person != null)
            {
                _Person = person;
                __RefreshContent?.Invoke();
                __PersonAdded?.Invoke(_Person);
                MessageBox.Show("Operation done Successfully");
                return;
            }
            MessageBox.Show("The System Can't Complete The Operation! Please Go To [Event Viewer] To See The Problem.");

        }

        private void _LeaveForm(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to Leave", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

    }
}
