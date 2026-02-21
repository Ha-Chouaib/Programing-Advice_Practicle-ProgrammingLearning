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
using System.Xml.Linq;

namespace BankSystem.Currencies.Controls
{
    public partial class ctrlCurrencyCalculator : UserControl
    {
        public ctrlCurrencyCalculator()
        {
            InitializeComponent();
            ctrlCurrencyFrom.__currencyCatched += _CatchCurrencyFrom;
            ctrlCurrencyTo.__currencyCatched += _CatchCurrencyTo;
            clsUtil_PL.TextBoxHelper.AllowOnlyNumbers(txtAmount, true);

        }
        private void ctrlCurrencyCalculator_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            _LoadCurrenciesNameToCombo();
           
        }

        enum enCurrency_Oprions { enFrom,enTo}
        enCurrency_Oprions _CurrencyOption;
        clsCurrencies _currencyFrom;
        clsCurrencies _currencyTo;
        ErrorProvider error = new ErrorProvider();

        private void _LoadCurrenciesNameToCombo()
        {

            DataTable dt = clsCurrencies.ListAll();
            Dictionary<string,string> dic = new Dictionary<string,string>();
            foreach (DataRow dr in dt.Rows)
            {
                dic.Add($"{dr["Name"]}", $"{dr["ID"]}");
            }

            cmbCurrencyOptions.DataSource = new BindingSource(dic, null);
            cmbCurrencyOptions.DisplayMember = "Key";
            cmbCurrencyOptions.ValueMember = "Value";
            cmbCurrencyOptions.SelectedIndex = 0;
        }
        private void _DetectSelectedCurrencyType()
        {
            if(rbFrom.Checked)
            {
                _CurrencyOption = enCurrency_Oprions.enFrom;
            }else
                _CurrencyOption = enCurrency_Oprions.enTo;
           
        }
        private void _PerformCurrencySelection()
        {
            switch(_CurrencyOption)
            {
                case enCurrency_Oprions.enFrom:
                    
                    ctrlCurrencyFrom.__ShowCard((int)cmbCurrencyOptions.SelectedValue);
                    break;
                case enCurrency_Oprions.enTo:
                    ctrlCurrencyTo.__ShowCard((int)cmbCurrencyOptions.SelectedValue);
                    break;
                default:
                    break;

            }
        }

        private void _CatchCurrencyFrom(clsCurrencies currency)
        {
            _currencyFrom = currency;
        }
        private void _CatchCurrencyTo(clsCurrencies currency)
        {
            _currencyTo = currency;
        }
        private bool _HandleCalculatingValidations()
        {
            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                error.SetError(txtAmount, "Please Enter an amount before start calculating");
                return false;
            }
            else
                error.SetError(txtAmount, "");
            if (_currencyFrom == null)
            {
                error.SetError(ctrlCurrencyFrom, "Please Select the base currency First");
                return false;
            }
            else
                error.SetError(ctrlCurrencyFrom, "");
            if (_currencyTo == null)
            {
                error.SetError(ctrlCurrencyFrom, "Please Select the target currency First");
                return false;
            }
            else
                error.SetError(ctrlCurrencyFrom, "");

            return true;
        }
        private void _CalculateAmount()
        {
            if (!_HandleCalculatingValidations()) return;

            txtResult.Clear();
            if(double.TryParse(txtAmount.Text.Trim(), out double amount))
                txtResult.Text = clsCurrencies.CalculateCurrency(amount,_currencyFrom.Rate,_currencyTo.Rate).ToString();
            else
            {
                MessageBox.Show("Calculation Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal_BL.LogHelper.LogError($"PL.ctrlCurrencyCalculator.CalculateAmount() => Failed To Parse The Amount[{txtAmount.Text.Trim()}] to double DataType");
            }

        }
        private void rbFrom_CheckedChanged(object sender, EventArgs e)
        {
            _DetectSelectedCurrencyType();
        }

        private void cmbCurrencyOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            _PerformCurrencySelection();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            _CalculateAmount();
        }

       
    }
}
