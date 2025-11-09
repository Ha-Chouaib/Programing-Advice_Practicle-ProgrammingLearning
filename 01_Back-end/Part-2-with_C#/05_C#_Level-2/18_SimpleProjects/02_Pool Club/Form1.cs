using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_Pool_Club
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ctrlPoolClub1_TableComplated(object sender, ctrlPoolClub.TableEventArgs e)
        {
            MessageBox.Show($"Player Name: {e.PlayerName} | Time Consumed: {e.TimeConsumed} | Total Seconds: {e.TotalSeconds} | Total Fees: {e.TotalFees}");
        }
    }
}
