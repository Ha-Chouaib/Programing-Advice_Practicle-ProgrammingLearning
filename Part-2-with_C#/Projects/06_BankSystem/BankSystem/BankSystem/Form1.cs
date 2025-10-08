﻿using Bank_BusinessLayer;
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
            clsPerson person =  clsPerson.FindByPersonID(3);

            person.FirstName = "Ahmed";
            if (person.Save())
                MessageBox.Show($"PersonID: {person.PersonID} | Full Name: {person.FirstName}");
            else MessageBox.Show("Something is Going Wrong");
        }
    }
}
