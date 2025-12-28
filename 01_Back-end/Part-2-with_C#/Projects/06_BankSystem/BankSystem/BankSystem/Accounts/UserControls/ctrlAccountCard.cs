using Bank_BusinessLayer;
using BankSystem.Customer.Forms;
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
    public partial class ctrlAccountCard : UserControl
    {
        public ctrlAccountCard()
        {
            InitializeComponent();
        }

        public Action __OnClose;
        private clsAccounts _account;
        public void __DisplayAccountInfo(clsAccounts account)
        {
            _account = account;
            if (_account == null) return;

            txtCustomerName.Text = _account.CustomerInf.PersonalInf.FullName;
            txtCustomerID.Text = _account.CustomerID.ToString();
            txtAccountID.Text = _account.AccountID.ToString();
            txtAccountNumber.Text = _account.AccountNumber;
            switch(_account.AccountType)
            {
                case clsAccounts.enAccountType.enIndividual:
                    txtAccountType.Text = "Individual";
                    break;
                case clsAccounts.enAccountType.enBusiness:
                    txtAccountType.Text = "Business";
                    break;
                case clsAccounts.enAccountType.enSave:
                    txtAccountType.Text = "Save";
                    break;
                default:
                    txtAccountType.Text = "Unknown";
                    break;
            }
            txtAccountType.Text = _account.AccountType.ToString();
            txtBalance.Text = _account.Balance.ToString("C2");
            txtStatus.Text = _account.IsActive ? "Active" : "Inactive";
            txtCreatedDate.Text = _account.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss");
            txtCreatedByUser.Text = _account.CreatedByUser.UserName;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_account != null)
            {
                frmCustomerCard customerCard = new frmCustomerCard(_account.CustomerInf);
                customerCard.ShowDialog();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            __OnClose?.Invoke();
        }
    }
}
