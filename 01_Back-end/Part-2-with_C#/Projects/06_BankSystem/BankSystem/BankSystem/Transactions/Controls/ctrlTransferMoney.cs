using Bank_BusinessLayer;
using BankSystem.Accounts.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Transactions.Controls
{
    public partial class ctrlTransferMoney : UserControl
    {
        public ctrlTransferMoney()
        {
            InitializeComponent();
            _Initialize();
        }
        public Action __OperationDoneSuccessfully;
        public Action __OperationFaialed;
        clsAccounts _accountFrom;
        clsAccounts _accountTo;
        ErrorProvider _error = new ErrorProvider();

        private void _Initialize()
        {
            clsUtil_PL.TextBoxHelper.AllowOnlyNumbers(txtAmount, true);

            ctrlFindAccountFrom.__AccountObjectCatched += _CatchAccountFrom;
            ctrlFindAccountTo.__AccountObjectCatched += _CatchAccountTo;

        }

        private void _CatchAccountFrom(clsAccounts accountFrom) => _accountFrom = accountFrom;
        private void _CatchAccountTo(clsAccounts accountTo) => _accountTo = accountTo;

        public void __TransferMoney()
        {
            ctrlFindAccountFrom.__FindAccount();
            ctrlFindAccountTo.__FindAccount();
        }
        public void __TransferMoney(clsAccounts accountFrom,clsAccounts accountTo)
        {
            ctrlFindAccountFrom.__ShowCard(accountFrom);
            ctrlFindAccountTo.__ShowCard(accountTo);
        }
        public void __TransferMoney(int accountFromId,int accountToId) 
        {
            ctrlFindAccountFrom.__ShowCard(accountFromId);
            ctrlFindAccountTo.__ShowCard(accountToId);
        }
        public void __TransferMoney(clsAccounts accountFrom)
        {
            ctrlFindAccountFrom.__ShowCard(accountFrom);
            ctrlFindAccountTo.__FindAccount();

        }
        public void __TransferMoney(int accountFromId)
        {
            ctrlFindAccountFrom.__ShowCard(accountFromId);
            ctrlFindAccountTo.__FindAccount();
        }


        private bool _ReadAmount(ref double amount)
        {
            return double.TryParse(txtAmount.Text, out amount);
        }
        private bool _HandleValidations()
        {
            if (_accountFrom == null)
            {
                _error.SetError(ctrlFindAccountFrom, "Please Pick the source account First !");
                return false;
            }
            else
                _error.SetError(ctrlFindAccountFrom, "");

            if (_accountTo == null)
            {
                _error.SetError(ctrlFindAccountTo, "Please Pick the destination account First !");
                return false;
            }
            else
                _error.SetError(ctrlFindAccountTo, "");


            if (MessageBox.Show("Are you sure to Complete the action ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
        private bool _PerformTransfer()
        {
            if (!_HandleValidations()) return false;
            double amount = 0;
            if (!_ReadAmount(ref amount))
            {
                MessageBox.Show("Can't Read amount value properly!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal_BL.LogHelper.LogError($"BL.ctrlDeposit_Withdrawal._ReadAmount() => Couldn't Parse amount[{amount}] to double data type");
                return false;
            }
           
            if (!clsAccounts.TransferMoney(_accountFrom.AccountID,_accountTo.AccountID,amount))
            {
                MessageBox.Show($"Couldn't Perform Transefr action for amount[{amount}] from the account[{_accountFrom.AccountID}] to account[{_accountTo.AccountID}] !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_PerformTransfer())
            {
                ctrlFindAccountFrom.__Refresh();
                ctrlFindAccountTo.__Refresh();
                __OperationDoneSuccessfully?.Invoke();
                return;
            }
            __OperationFaialed?.Invoke();
        }
    }
}
