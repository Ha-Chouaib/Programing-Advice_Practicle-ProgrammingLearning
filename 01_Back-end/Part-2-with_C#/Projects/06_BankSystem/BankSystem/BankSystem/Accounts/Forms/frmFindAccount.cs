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

namespace BankSystem.Accounts.Forms
{
    public partial class frmFindAccount : Form
    {
        public frmFindAccount()
        {
            InitializeComponent();
            _HasPermissions();
            ctrlFindAccount1.__FindAccount();
        }
        public frmFindAccount(clsAccounts account)
        {

            InitializeComponent();
            _HasPermissions();
           ctrlFindAccount1.__ShowCard(account);
        }

        public frmFindAccount(int accountId)
        {

            InitializeComponent();
            _HasPermissions();
            ctrlFindAccount1.__ShowCard(accountId);

        }

        private void _HasPermissions()
        {
            if (!clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Accounts_Find))
            {
                MessageBox.Show("You don't have permission to Access accounts Info.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Load += (s, e) => this.Close();
                return;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
