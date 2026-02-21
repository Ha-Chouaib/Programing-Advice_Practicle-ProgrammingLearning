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

namespace BankSystem.Accounts.UserControls
{
    public partial class ctrlFindAccount : UserControl
    {
        public ctrlFindAccount()
        {
            InitializeComponent();
            ctrlAccountCard1.__AccountObjectCatched += (clsAccounts account) => { __AccountObjectCatched?.Invoke(account); };
        }
        public Action<clsAccounts> __AccountObjectCatched;
        private void _Initialize()
        {
            ctrlFind1.Enabled = true;
            ctrlFind1.__Initializing(_FindBy_Options(), clsAccounts.FindBy);
            ctrlFind1.__FindOptionsCombo.SelectedValueChanged += (s, e) =>
            {
                ctrlFind1.__txtSearchTerm.KeyPress -= null;
                if (((KeyValuePair<int, string>)ctrlFind1.__FindOptionsCombo.SelectedItem).Value == clsAccounts.FindBy_Mapping.AccountID.valueMember)
                    ctrlFind1.__txtSearchTerm.KeyPress += (s1, e1) => { e1.Handled = !char.IsControl(e1.KeyChar) && !char.IsDigit(e1.KeyChar); };
                else
                    ctrlFind1.__txtSearchTerm.KeyPress += (s1, e1) => { e1.Handled = false; };
            };
            ctrlFind1.__ObjectFound += _GetAccountRecord;
        }
        
        public void __Refresh()
        {
            ctrlAccountCard1?.__Refresh();
        }
        public void __FindAccount()
        {
            _Initialize();
        }
        public void __ShowCard(int accountId)
        {
            _DisplayAccountInfo(clsAccounts.FindByID(accountId));
        }
        public void __ShowCard(clsAccounts account)
        {
            _DisplayAccountInfo(account);

        }
        private void _DisplayAccountInfo(clsAccounts account)
        {
            if (account == null)
            {
                __FindAccount();
                return;
            }
            ctrlFind1.__txtSearchTerm.Text = account.AccountID.ToString();
            ctrlFind1.__FindOptionsCombo.Text = "Account ID";
            ctrlFind1.Enabled = false;
            _GetAccountRecord(this, account);
        }
        private void _GetAccountRecord(object s, object account)
        {
            ctrlAccountCard1.__DisplayAccountInfo(account as clsAccounts);
         
        }
        private Dictionary<string, string> _FindBy_Options()
        {
            return clsUtil_BL.MappingHelper.GetOptionsFromMapping(typeof(clsAccounts.FindBy_Mapping));
        }
    }
}
