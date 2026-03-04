using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Reports.UserActivityReport
{
    public partial class frmUserReport_EntityChanges : Form
    {
        public frmUserReport_EntityChanges(string Before ,string After)
        {
            InitializeComponent();
            if(string.IsNullOrEmpty(Before) && string.IsNullOrEmpty(After))
            {
                MessageBox.Show("No changes to display.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Load += (s, e) => this.Close();
                return;
            }
            txtAfter.Text = After;
            txtBefore.Text = Before;
        }
    }
}
