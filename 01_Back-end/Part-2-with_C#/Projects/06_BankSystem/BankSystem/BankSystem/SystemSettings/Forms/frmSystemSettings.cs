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
            ctrlBtnSysLogs_Click(null, null);
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
            lblCurrentViewTitle.Text = "SYSTEM LOGS";
            lblCurrentViewTinyTitle.Text = lblCurrentViewTitle.Text.ToLower();
            AddControlToMainPanel(logsManager);
        }
        private void crtlBtnRoles_Click(object sender, EventArgs e)
        {
            lblCurrentViewTitle.Text = "ROLES";
            lblCurrentViewTinyTitle.Text = lblCurrentViewTitle.Text.ToLower();
            AddControlToMainPanel(manageRoles);
        }

        private void ctrlBtnCurrencies_Click(object sender, EventArgs e)
        {
            lblCurrentViewTitle.Text = "CURRENCIES";
            lblCurrentViewTinyTitle.Text = lblCurrentViewTitle.Text.ToLower();
            AddControlToMainPanel(manageCurrencies);
        }

        private void ctrlBtnAppInfo_Click(object sender, EventArgs e)
        {
            lblCurrentViewTitle.Text = "APP && BRANCH INFO";
            lblCurrentViewTinyTitle.Text = lblCurrentViewTitle.Text.ToLower();
            pnlMain.Controls.Clear();
            MessageBox.Show("Bank System Application\nVersion: 1.0.0\nDeveloped by: Your Name\n© 2024 Bank System Inc.", "Application Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ctrlBtnBackup_Click_1(object sender, EventArgs e)
        {
            lblCurrentViewTitle.Text = "BACKUP && RESTORE";
            lblCurrentViewTinyTitle.Text = lblCurrentViewTitle.Text.ToLower();
            pnlMain.Controls.Clear();
            MessageBox.Show("Backup feature is not implemented yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
