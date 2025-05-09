﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_Project.Applications;
using DVLD_Project.Applications.ApplicationTypes;
using DVLD_Project.Applications.LDLApps;
using DVLD_Project.Applications.TestTypes;
using DVLD_Project.Users;
using DVLD_Project.Users.Forms;

namespace DVLD_Project
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form MangePeopleForm = new frmManagePeople();

            MangePeopleForm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers ManageUsers = new frmManageUsers();
            ManageUsers.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CurrentUserID= clsGlobal.CurrentUserID;
            frmDisplayUserDetails CurrentUserDetails = new frmDisplayUserDetails(CurrentUserID);
            CurrentUserDetails.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CurrentUserID = clsGlobal.CurrentUserID;
            frmChangePassword ChangePass = new frmChangePassword(CurrentUserID);

            ChangePass.ShowDialog();
        }

        public delegate void TriggerFunctionHandler(object sender, string UserName, string UserPass);
        public event TriggerFunctionHandler TriggerRememberMeFunc;

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsUsers User = clsUsers.Find(clsGlobal.CurrentUserID);
            TriggerRememberMeFunc?.Invoke(this, User.UserName, User.Password);
            this.Close();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes  AppType=new frmManageApplicationTypes();
            AppType.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes TestsManagment = new frmManageTestTypes();
            TestsManagment.ShowDialog();
           
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicenseApps LDL_Apps = new frmManageLocalDrivingLicenseApps();
            LDL_Apps.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewLocalDrivingLicense AddNewLocalLicense = new frmAddNewLocalDrivingLicense();
            AddNewLocalLicense.ShowDialog();
        }
    }
}
