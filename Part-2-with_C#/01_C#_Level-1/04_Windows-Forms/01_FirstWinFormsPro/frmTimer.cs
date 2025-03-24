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
    public partial class frmTimer: Form
    {
        public frmTimer()
        {
            InitializeComponent();
        }
        private int Counter;

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Evrey Second Execute the function
            Counter++;
            label1.Text = Counter.ToString();
            TimeSpan TS = TimeSpan.FromSeconds(Counter);
            lbltimerHist.Text += TS.ToString(@"hh\:mm\:ss") +Environment.NewLine;
        }
    }
}
