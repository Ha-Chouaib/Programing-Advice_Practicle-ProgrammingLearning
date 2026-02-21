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

namespace BankSystem.Currencies.Forms
{
    public partial class frmCurrencyUpdateRate : Form
    {
        public frmCurrencyUpdateRate()
        {
            InitializeComponent();
            _HasPermissions();
        }

        public frmCurrencyUpdateRate(int currencyId)
        {
            InitializeComponent();
            _HasPermissions();
            ctrlCurrency_UpdateRate1.__EditCurrencyRate(currencyId);
        }
        private void _HasPermissions()
        {
            if (!clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Users_ChangePassword))
            {
                MessageBox.Show("You don't have permission to Update currency rate.",
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
