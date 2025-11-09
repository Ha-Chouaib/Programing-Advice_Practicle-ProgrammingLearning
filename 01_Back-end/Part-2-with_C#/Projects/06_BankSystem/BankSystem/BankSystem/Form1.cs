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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void _Add_EventLog()
        {
            if(!EventLog.SourceExists(clsGlobal.EventLogSourceName))
            {
                EventLog.CreateEventSource(clsGlobal.EventLogSourceName, "Application");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _Add_EventLog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsUser User= clsUser.FindUserByName("Admin01");



            if (clsUser.ExistByUserName("Admin01"))
            {
                MessageBox.Show($" Found  ");
            }

            else MessageBox.Show("SomeThing is going wrong!");
        }
    }
}
