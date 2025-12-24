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
    public partial class frmAddNewUser : Form
    {
        public frmAddNewUser()
        {
            InitializeComponent();
            ctrlAddEditUser1.__OnPermissionChanged += TestPerm;
            ctrlAddEditUser1.__LoadPermissions(0);
        }

        private void TestPerm(ulong per)
        {
            //MessageBox.Show("Current Permissions Value: " + Convert.ToInt64(per).ToString());

        }
    }
}
