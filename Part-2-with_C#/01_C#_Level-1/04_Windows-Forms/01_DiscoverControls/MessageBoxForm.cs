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
    public partial class MessageBoxForm: Form
    {
        public MessageBoxForm()
        {
            InitializeComponent();
        }

        private void btnMSGBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowMSGBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Laa Ilaaha Illa Allah","Allaho Akbar");
        }

        private void btnMSGwithCanlcelBtn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Soubhan ALAAH", "Islam", MessageBoxButtons.OKCancel)== DialogResult.OK)
            {
                MessageBox.Show("The User Is Said Ok", " Confirm");
            }else
            {
                this.Close();
            }
        }

        private void MSG_Icons_Click(object sender, EventArgs e)
        {
           if( MessageBox.Show("La Hawla Walla 9owata Illa Billah", "Islam", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)== DialogResult.OK)
            {
                MessageBox.Show("Alhamde LI AllAh", "Islam",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }else
            {
                MessageBox.Show("Close It Your Self","Islam",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        private void MessageBoxForm_Load(object sender, EventArgs e)
        {

        }
    }
}
