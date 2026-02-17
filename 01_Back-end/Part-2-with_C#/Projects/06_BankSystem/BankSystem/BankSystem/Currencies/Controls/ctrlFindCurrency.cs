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
    public partial class ctrlFindCurrency : UserControl
    {
        public ctrlFindCurrency()
        {
            InitializeComponent();
            _InitiateFindControl();
        }
        public Action<clsCurrencies> __CurrencyFound;
        private void _InitiateFindControl()
        {
            ctrlFind1.__Initializing(clsUtil_BL.MappingHelper.GetOptionsFromMapping(typeof(clsCurrencies.FindBy_Mapping)), clsCurrencies.FindBy);
            ctrlFind1.__txtSearchTerm.KeyPress += (s, e) => 
            {
                if (clsCurrencies.FindBy_Mapping.ID.valueMember == ctrlFind1.__FindOptionsCombo.SelectedValue.ToString())
                    e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
            };
            ctrlFind1.__ObjectFound += _DisplayInfo;
        }
        private void _DisplayInfo(object s,object currency)
        {
            ctrlCurrencyCard1.__ShowCard(currency as clsCurrencies);
            __CurrencyFound?.Invoke(currency as clsCurrencies);
        }
        public void __ShowCard(clsCurrencies currency)
        {
            if(currency == null)
            {
                _InitiateFindControl();
                return;
            }
            ctrlFind1.__FindOptionsCombo.Text = "Currency ID";
            ctrlFind1.__txtSearchTerm.Text = currency.ID.ToString();
            ctrlFind1.Enabled = false;
            ctrlCurrencyCard1.__ShowCard(currency);
        }
        public void __ShowCard(int currencyId)
        {
            __ShowCard(clsCurrencies.FindByID(currencyId));
        }
        public void __ShowCard(string currencyCode)
        {
            __ShowCard(clsCurrencies.FindByCode(currencyCode));
        }
    }
}
