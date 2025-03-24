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
    public partial class frmLinkLabel: Form
    {
        public frmLinkLabel()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;//The Link was clicked so the Color will changed
            System.Diagnostics.Process.Start("Here You Put The Target URL");//System will take you to the default browzer then applay the link.
        }
    }
}
