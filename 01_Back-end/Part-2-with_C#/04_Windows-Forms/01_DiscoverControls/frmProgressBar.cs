using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_FirstWinFormsPro
{
    public partial class frmProgressBar: Form
    {
        public frmProgressBar()
        {
            InitializeComponent();
        }

        private void btnIcreasePB_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;

            for(byte i=1; i<=10; i++)
            {
                if(progressBar1.Value < progressBar1.Maximum)
                {
                    Thread.Sleep(500);
                    progressBar1.Value += 10;
                    label1.Text = (((float)progressBar1.Value / progressBar1.Maximum) * 100) + "%";
                    
                    //we Do Thread Sleep So we should refresh the values to update them on the screen
                    progressBar1.Refresh();  
                    label1.Refresh();
                }else
                {
                    btnIcreasePB.Enabled = false;
                }
            }
        }

        private void btnResetPB_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            label1.Text = "0%";
        }
    }
}
