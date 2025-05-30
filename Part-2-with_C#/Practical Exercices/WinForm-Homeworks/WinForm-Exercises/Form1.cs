﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_Exercises
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn01CheckedListBox_Click(object sender, EventArgs e)
        {
            Form frmCheckedListBox = new frmTaskManager();
            frmCheckedListBox.Show();
        }

        private void btnDateTimePicker_Click(object sender, EventArgs e)
        {
            Form frmDTpicker = new frmDateTimePicker();
            frmDTpicker.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frmManip=new frmDynamicManipulation();
            frmManip.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frmCustomCtrl = new frmCustomControl();
            frmCustomCtrl.Show();
        }

        private void btnGenericCode_Click(object sender, EventArgs e)
        {
            Form frmGenerric = new frmGenericFunctions();
            frmGenerric.Show();
        }

        private void btnLINQ_Click(object sender, EventArgs e)
        {
            Form frmLINQ = new frmLINQ();
            frmLINQ.Show();
        }
    }
}
