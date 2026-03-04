using BankSystem.Transactions.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.GlobalElements.Forms
{
    public partial class frmMappTransactions : Form
    {
        public frmMappTransactions(object caller)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            if (caller is Control control)
            {
                Point screenPoint = control.PointToScreen(Point.Empty);
                this.Location = new Point(
                    screenPoint.X - Math.Abs(control.Width - this.Width) / 2,
                    screenPoint.Y + control.Height
                );
            }
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDepositMoney depositForm = new frmDepositMoney();
            depositForm.ShowDialog();
        }

        private void btnWithdrawal_Click(object sender, EventArgs e)
        {
            this.Close();

            frmWithdrawMoney withdrawForm = new frmWithdrawMoney();
            withdrawForm.ShowDialog();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            this.Close();

            frmTransferMoney transferForm = new frmTransferMoney();
            transferForm.ShowDialog();
        }

        private void CheckMouseOutside()
        {
            Point mousePos = Cursor.Position;

            if (!this.Bounds.Contains(mousePos))
            {
                this.Close();
            }
        }

        private void frmMappTransactions_MouseLeave(object sender, EventArgs e)
        {
            CheckMouseOutside();
        }
    }
}
