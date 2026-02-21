using Bank_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Currencies.Controls
{
    public partial class ctrlCurrency_UpdateRate : UserControl
    {
        public ctrlCurrency_UpdateRate()
        {
            InitializeComponent();
            _Initialize();
        }

        clsCurrencies _targetCurrency;
        private void _Initialize()
        {
            ctrlFindCurrency1.__CurrencyFound += _catchTargetCurrency;
            clsUtil_PL.TextBoxHelper.AllowOnlyNumbers(txtAmount, true);
        }
        public void __EditCurrencyRate(int currencyId)
        {
            ctrlFindCurrency1.__ShowCard(currencyId);
        }
        private void _catchTargetCurrency(clsCurrencies currency)
        {
            _targetCurrency = currency;
        }
        private bool _HandleValidations()
        {
            if (_targetCurrency == null)
            {
                MessageBox.Show("Please select the target currency First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                MessageBox.Show("Please Enter the rate First", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (MessageBox.Show("Are you sure to change the currency rate?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return false;

            return true;
        }
        private bool _ReadUpdatedRate(ref float rate)
        {
            if (float.TryParse(txtAmount.Text.Trim(), out rate)) return true;
            return false;
        }
        private void _UpdateRate()
        {
            if (!_HandleValidations()) return;

            float rate = 0;
            if (!_ReadUpdatedRate(ref rate))
            {
                MessageBox.Show("Fialed To Read The rate value !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal_BL.LogHelper.LogError($"PL.ctrlCurrency_UpdateRate._ReadUpdatedRate() => Couldn't parse the value [{rate}] to float data type");
                return;
            }
            if (!clsCurrencies.UpdateRate(_targetCurrency.ID, rate))
            {
                MessageBox.Show("Fialed To Update The rate value !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("The Rate Updated Successfully");
            ctrlFindCurrency1.__Refresh();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _UpdateRate();
        }
    }
}
