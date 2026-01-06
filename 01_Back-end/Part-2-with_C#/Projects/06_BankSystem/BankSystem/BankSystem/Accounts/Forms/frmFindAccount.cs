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
            ctrlFind1.Enabled = true;
            ctrlFind1.__Initializing(_FilterBy_Options(),clsAccounts.FindBy);
            ctrlFind1.__FindOptionsCombo.SelectedValueChanged += (s, e) =>
            {
                ctrlFind1.__txtSearchTerm.KeyPress -= null;
                if (((KeyValuePair<int, string>)ctrlFind1.__FindOptionsCombo.SelectedItem).Value == "AccountID")
                    ctrlFind1.__txtSearchTerm.KeyPress += (s1, e1) => { e1.Handled = !char.IsControl(e1.KeyChar) && !char.IsDigit(e1.KeyChar); };
                else
                    ctrlFind1.__txtSearchTerm.KeyPress += (s1, e1) => { e1.Handled = false; };
            };
            ctrlFind1.__ObjectFound += _GetAccountRecord;
        }
        public frmFindAccount(clsAccounts account)
        {

            InitializeComponent();
            _DisplayAccountInfo(account);
        }
        private void _DisplayAccountInfo(clsAccounts account)
        {
            ctrlFind1.__txtSearchTerm.Text = account.AccountID.ToString();
            ctrlFind1.__FindOptionsCombo.Text = "Account ID";
            ctrlFind1.Enabled = false;
           _GetAccountRecord(this, account);
        }
        private void _GetAccountRecord(object s, object account)
        {
            ctrlAccountCard1.__DisplayAccountInfo(account as clsAccounts);
            ctrlAccountCard1.__OnClose = () =>
            {
                this.Close();
            };

        }
        private Dictionary<string, string> _FilterBy_Options()
        {
            Dictionary<string, string> Options = new Dictionary<string, string>
            {
                {"Account ID","AccountID" },
                {"Account Number","AccountNumber" },
            };
            return Options;
        }
    }
}
