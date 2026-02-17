using Bank_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void _Add_EventLog()
        {
            if(!EventLog.SourceExists(clsGlobal_BL.EventLogSourceName))
            {
                EventLog.CreateEventSource(clsGlobal_BL.EventLogSourceName, "Application");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _Add_EventLog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           frmHomePage frmHomePage = new frmHomePage();
            frmHomePage.ShowDialog();
            
        }
        
    }
}
