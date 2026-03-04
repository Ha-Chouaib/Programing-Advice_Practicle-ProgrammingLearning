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
        public frmFindUser( clsUser user)
        {
            InitializeComponent();
            _HasPermissions(user.UserID);
            ctrlFindUser1.__ShowUserCard(user);
        }
        private void _HasPermissions()
        {
            if (!clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Users_Find))
            {
               AccessDenied();
                return;
            }
        }
        private void _HasPermissions(int userid)
        {
            if (clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Users_Find) || clsGlobal_BL.LoggedInUser.UserID == userid) return;
            
           AccessDenied();
            return;
            
        }
        private void AccessDenied()
        {
            MessageBox.Show("You don't have permission to search for Users.",
                "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Load += (s, e) => this.Close();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
