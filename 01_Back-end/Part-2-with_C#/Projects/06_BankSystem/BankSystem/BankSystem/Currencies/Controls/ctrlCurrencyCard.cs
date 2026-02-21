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

namespace BankSystem.Currencies.Controls
{
    public partial class ctrlCurrencyCard : UserControl
    {
        public ctrlCurrencyCard()
        {
            InitializeComponent();
        }
        clsCurrencies _currency;
        public Action<clsCurrencies> __currencyCatched;
        public void __ShowCard(clsCurrencies currency)
        {
            _currency = currency;
            _DisplayCardInfo();
        }
        public void __ShowCard(int currencyID)
        {
            _currency = clsCurrencies.FindByID(currencyID);
            _DisplayCardInfo();
        }
        public void __ShowCard(string Code)
        {
            _currency = clsCurrencies.FindByCode(Code);
            _DisplayCardInfo();
        }
        private void _DisplayCardInfo()
        {
            if (_currency == null) 
            {
                MessageBox.Show("Couldn't Found the currency object","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };
            __currencyCatched?.Invoke(_currency);

            txtID.Text = _currency.ID.ToString();
            txtCode.Text = _currency.Code;
            txtName.Text = _currency.Name;
            txtCountry.Text = _currency.Country;
            txtRate.Text = _currency.Rate.ToString();

        }
    
        public void __Refresh()
        {
            if (_currency == null) return;
            _currency = clsCurrencies.FindByID(_currency.ID);
            _DisplayCardInfo();
        }
    }
}
