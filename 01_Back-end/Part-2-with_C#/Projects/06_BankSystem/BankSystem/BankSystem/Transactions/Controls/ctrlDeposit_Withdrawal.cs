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

namespace BankSystem.Transactions.Controls
{
    public partial class ctrlDeposit_Withdrawal : UserControl
    {
        public ctrlDeposit_Withdrawal()
        {
            InitializeComponent();
            clsUtil_PL.TextBoxHelper.AllowOnlyNumbers(txtAmount, true);
            ctrlFindAccount1.__AccountObjectCatched += _CatchAccount;
        }
        public Action __OperationDoneSuccessfully;
        public Action __OperationFaialed;
        ErrorProvider _error = new ErrorProvider();
        clsAccounts _account;
        enum enMode { enDeposit, enWithdrawal }
        enMode _Mode;
        public void __Deposit()
        {
            ctrlFindAccount1.__FindAccount();
            _Mode = enMode.enDeposit;
        }
        public void __Deposit(int accountId)
        {
            ctrlFindAccount1.__ShowCard(accountId);
            _Mode = enMode.enDeposit;
        }
        public void __Deposit(clsAccounts account)
        {
            ctrlFindAccount1.__ShowCard(account);
            _Mode = enMode.enDeposit;
        }

        public void __Withdrawal() 
        {
            ctrlFindAccount1.__FindAccount();
            _Mode = enMode.enWithdrawal;
        }
        public void __Withdrawal(int accountId)
        {
            ctrlFindAccount1.__ShowCard(accountId);
            _Mode = enMode.enWithdrawal;
        }
        public void __Withdrawal(clsAccounts account)
        {
            ctrlFindAccount1.__ShowCard(account);
            _Mode = enMode.enWithdrawal;
        }

        private void _CatchAccount(clsAccounts acc)
        {
            _account = acc;
        }
        private bool _ReadAmount(ref double amount)
        {
            return double.TryParse(txtAmount.Text, out amount);
        }
        private bool _HandleValidations()
        {

            if(_account == null)
            {
                _error.SetError(ctrlFindAccount1, "Please Pick an account First !");
                return false;
            }
            else
                _error.SetError(ctrlFindAccount1, "");

            if (MessageBox.Show("Are you sure to Complete the action ?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
                return false;

            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                _error.SetError(txtAmount, "Please Set an amount First !");
                return false;
            }
            else
                _error.SetError(txtAmount, "");


            return true;
        }
        private bool _PerformTransaction()
        {
            if (!_HandleValidations()) return false;
            double amount = 0;
            if(!_ReadAmount(ref amount))
            {
                MessageBox.Show("Can't Read amount value properly!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                clsGlobal_BL.LogHelper.LogError($"BL.ctrlDeposit_Withdrawal._ReadAmount() => Couldn't Parse amount[{amount}] to double data type");
                return false;
            }
            switch(_Mode)
            {
                case enMode.enDeposit:
                    if (!_account.DepositWithdraw(amount))
                    {
                        MessageBox.Show($"Couldn't Deposit the amount[{amount}] to the account[{_account.AccountID}] !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    return  true;
                case enMode.enWithdrawal:
                    if (!_account.DepositWithdraw(-amount))
                    {
                        MessageBox.Show($"Couldn't Perform withdrawal action from the account[{_account.AccountID}] with amount[{amount}] !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    return true;
                default: return false;
            }
       }

        private void button1_Click(object sender, EventArgs e)
        {
            if(_PerformTransaction())
            {
                __OperationDoneSuccessfully?.Invoke();
                ctrlFindAccount1.__Refresh();
                return;
            }
            __OperationFaialed?.Invoke();
        }
    }
}
