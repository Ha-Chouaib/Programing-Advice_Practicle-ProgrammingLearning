using System;
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
using DVLD_Project.Applications.Detain_License_App;
using DVLD_Project.Applications.Detain_Release_License_App;
using DVLD_Project.Applications.LDLApps;
using DVLD_Project.Applications.RenewLocalDrivingLicense_App;
using DVLD_Project.Applications.ReplaceLocalLicense_Damage_Lost;
using DVLD_Project.Applications.TestTypes;
using DVLD_Project.Drivers;
using DVLD_Project.License;
using DVLD_Project.License.Forms;
using DVLD_Project.Users;
using DVLD_Project.Users.Forms;

namespace DVLD_Project
{
    public partial class MainForm: Form
    {
        frmLogin _Login;
        public MainForm(frmLogin LoginForm)
        {
            InitializeComponent();
            _Login = LoginForm;
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

       

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUserID = -1;
            _Login.Show();
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
            frmAddNewLocalDrivingLicense_App AddNewLocalLicense = new frmAddNewLocalDrivingLicense_App();
            AddNewLocalLicense.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDrivers ManageDrivers = new frmManageDrivers();
            ManageDrivers.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicenseApplication AddNewInternationalLicense = new frmAddNewInternationalLicenseApplication();
            AddNewInternationalLicense.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicense RenewDrivingLicens = new frmRenewLocalDrivingLicense();
            RenewDrivingLicens.ShowDialog();
        }

        private void replacmentForLostOrDamageLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLocalLicense_Application LicenseReplacement = new frmReplaceLocalLicense_Application();
            LicenseReplacement.ShowDialog();
        }

        private void manageDetianLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicenses ManageDetainedLicenses = new frmManageDetainedLicenses();
            ManageDetainedLicenses.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense DetainLicense = new frmDetainLicense();
            DetainLicense.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense ReleaseLicense = new frmReleaseDetainedLicense();
            ReleaseLicense.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense ReleaseLicense = new frmReleaseDetainedLicense();
            ReleaseLicense.ShowDialog();
        }

        private void retackeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicenseApps  localDrivingLicenseApplications =new frmManageLocalDrivingLicenseApps();
            localDrivingLicenseApplications.ShowDialog();
        }

        private void internationalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageInternationalLicenses ManageInterNationalLicense = new frmManageInternationalLicenses();
            ManageInterNationalLicense.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            logOutToolStripMenuItem_Click(null, null);
        }
    }
}
