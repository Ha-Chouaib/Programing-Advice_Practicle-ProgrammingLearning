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
    public partial class frmNotifyIcon: Form
    {
        public frmNotifyIcon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            notifyIcon1.Icon = SystemIcons.Application; // Give the notify Balloon The App Icon
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;// Icon Type
            notifyIcon1.BalloonTipTitle = "Set a Title";
            notifyIcon1.BalloonTipText = "Set MSG Body";
            notifyIcon1.ShowBalloonTip(1000);
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            // Do Any Action when the NotifyBaloon Clicked
            MessageBox.Show("The Balloon Was clicked");
        }
    }
}
