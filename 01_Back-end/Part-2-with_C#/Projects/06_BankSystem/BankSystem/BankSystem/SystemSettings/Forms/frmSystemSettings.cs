using BankSystem.Currencies.Controls;
using BankSystem.Reports.Controls.Customer;
using BankSystem.Roles.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.SystemSettings.Forms
{
    public partial class frmSystemSettings : Form
    {
        ctrlSystemLogsManager logsManager = new ctrlSystemLogsManager();
        ctrlManageRoles manageRoles = new ctrlManageRoles();
        ctrlManageCurrencies manageCurrencies = new ctrlManageCurrencies();

        public frmSystemSettings()
        {
            InitializeComponent();
        }

        private void AddControlToMainPanel(Control control)
        {
            if (!pnlMain.Controls.Contains(control))
            {
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(control);
                control.Location = new Point((pnlMain.Width - control.Width) / 2, (pnlMain.Height - control.Height) / 2);
                pnlMain.SizeChanged += (s, ev) => { control.Location = new Point((pnlMain.Width - control.Width) / 2, (pnlMain.Height - control.Height) / 2); };
                control.BringToFront();
            }
        }

        private void ctrlBtnSysLogs_Click(object sender, EventArgs e)
        {
            AddControlToMainPanel(logsManager);
        }
        private void crtlBtnRoles_Click(object sender, EventArgs e)
        {
            AddControlToMainPanel(manageRoles);
        }

        private void ctrlBtnCurrencies_Click(object sender, EventArgs e)
        {
            AddControlToMainPanel(manageCurrencies);
        }
    }
}
