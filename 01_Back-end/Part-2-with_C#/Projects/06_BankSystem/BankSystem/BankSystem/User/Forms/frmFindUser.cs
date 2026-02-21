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

namespace BankSystem.User.Forms
{
    public partial class frmFindUser : Form
    {
        public frmFindUser()
        {
            InitializeComponent();
            _HasPermissions();
        }
        public frmFindUser( int user)
        {
            InitializeComponent();
            _HasPermissions();
            ctrlFindUser1.__ShowUserCard( clsUser.FindUserByID(user));
        }
        private void _HasPermissions()
        {
            if (!clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Users_Find))
            {
                MessageBox.Show("You don't have permission to search for Users.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Load += (s, e) => this.Close();
                return;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
