using Bank_BusinessLayer.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Reports.TransactionHistory
{
    public partial class frmTransactionHistCard : Form
    {
        public frmTransactionHistCard(clsTransactionsReport report)
        {
            InitializeComponent();
            ctrlTranactionsHistCard1.__ShowCard(report);
        }
    }
}
