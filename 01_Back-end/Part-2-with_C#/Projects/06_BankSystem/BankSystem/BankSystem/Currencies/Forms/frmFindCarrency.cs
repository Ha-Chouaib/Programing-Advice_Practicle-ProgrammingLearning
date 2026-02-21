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

namespace BankSystem.Currencies.Forms
{
    public partial class frmFindCarrency : Form
    {
        public frmFindCarrency()
        {
            InitializeComponent();
            _ShowInfo();
        }
        public frmFindCarrency(clsCurrencies currency)
        {
            InitializeComponent();
            _ShowInfo(currency);
        }
        public frmFindCarrency(int currencyId)
        {
            InitializeComponent();
            _ShowInfo(currencyId);
        }
        public frmFindCarrency(string currencyCode)
        {
            InitializeComponent();
            _ShowInfo(currencyCode);
        }

        private void _ShowInfo()
        {
            ctrlFindCurrency1.__ShowCard();
        }
        private void _ShowInfo(clsCurrencies currency)
        {
            ctrlFindCurrency1.__ShowCard(currency);
        }
        private void _ShowInfo(int currencyId)
        {
            ctrlFindCurrency1.__ShowCard(currencyId);
        }
        private void _ShowInfo(string currencyCode)
        {
            ctrlFindCurrency1.__ShowCard(currencyCode);
        }

    }
}
