using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_FirstWinFormsPro
{
    public partial class MonthCalandar: Form
    {
        public MonthCalandar()
        {
            InitializeComponent();
        }

        private void btnSelectedRange_Click(object sender, EventArgs e)
        {
            MessageBox.Show(monthCalendar1.SelectionRange.ToString());
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            MessageBox.Show(monthCalendar1.SelectionRange.Start.ToShortDateString());
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            MessageBox.Show(monthCalendar1.SelectionRange.End.ToShortDateString());

        }
    }
}
