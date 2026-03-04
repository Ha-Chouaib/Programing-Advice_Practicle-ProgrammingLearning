using Bank_BusinessLayer;
using Bank_BusinessLayer.Reports;
using BankSystem.Accounts.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Reports.TransactionHistory
{
    public partial class ctrlTranactionsHistCard : UserControl
    {
        public ctrlTranactionsHistCard()
        {
            InitializeComponent();
        }
        
        public void __ShowCard(clsTransactionsReport report)
        {
            if (report == null)
            {
                MessageBox.Show("No data to display", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtTransactionID.Text = report.TransactionID.ToString();
            txtYtansactionType.Text = report.TransactionType.ToString();
            txtAmount.Text = report.Amount.ToString("C");
            txtTransactionDate.Text = report.TransactionDate.ToString("g");
            txtAccountFromID.Text = report.AccountFromID.ToString();

            txtAccountToID.Text = report.AccountToID.ToString();
            if (!report.AccountToID.HasValue)
            {
                txtAccountToID.Text = "N/A";
                lnkAccountTo.Enabled = false;
            }
            lnkAccountFrom.Enabled = report.AccountFromID > 0;
            lnkAccountFrom.Tag = report.AccountFromID;
            lnkAccountTo.Tag = report.AccountToID;

            txtNewBalance.Text = report.NewBalance.ToString("C");
            txtOldBalance.Text = report.OldBalance.ToString("C");
            txtNotes.Text = report.Notes ?? "No Notes";
            txtPerformedByUser.Text = report.PerformedByUserID != -1 ? clsUser.FindUserByID(report.PerformedByUserID).UserName : "Performed By Customer";

        }

        private void lnkAccountFrom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(lnkAccountFrom.Tag is int accountId)
            {
                frmFindAccount detailsForm = new frmFindAccount(accountId);
                detailsForm.ShowDialog();
            }
        }

        private void lnkAccountTo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lnkAccountTo.Tag is int accountId)
            {
                frmFindAccount detailsForm = new frmFindAccount(accountId);
                detailsForm.ShowDialog();
            }
        }
    }
}
