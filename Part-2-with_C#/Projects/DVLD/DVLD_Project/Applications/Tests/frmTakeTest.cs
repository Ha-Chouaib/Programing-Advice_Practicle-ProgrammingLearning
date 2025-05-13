using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer.Applications;
using DVLD_BusinessLayer;
using DVLD_BusinessLayer.Tests;

namespace DVLD_Project.Applications.Tests
{
    public partial class frmTakeTest : Form
    {
        public frmTakeTest()
        {
            InitializeComponent();
        }

        int _SchedualedTestAppID = -1;
        byte _Trials=0;
        clsTestAppointments TestAppointment;

        public delegate void TriggerFunctionEventHandler(object sender);
        public event TriggerFunctionEventHandler __ReloadList;

        public frmTakeTest(int TestAppointmentID,byte Trials)
        {
            InitializeComponent();

            _SchedualedTestAppID = TestAppointmentID;
            _Trials = Trials;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _LoadSchedualeTestInfo();
            rbFail.Checked = true;
        }

        private void _LoadSchedualeTestInfo()
        {
            if (_SchedualedTestAppID != -1)
            {
                TestAppointment = clsTestAppointments.Find(_SchedualedTestAppID);

                clsLocalDrivingLicense LocalLicenseApp = clsLocalDrivingLicense.Find(TestAppointment.LDL_AppID);
                clsMainApplication MainApp = clsMainApplication.Find(LocalLicenseApp.MainApplicationID);
                clsPeople Person = clsPeople.Find(MainApp.ApplicantPersonID);

                lblDL_AppID.Text = TestAppointment.LDL_AppID.ToString();
                lblLicenseClass.Text = clsLicenseClasses.Find(LocalLicenseApp.LicenseClassID).LicenseClassName;

                lblFullName.Text = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;

                lblFees.Text = clsTestTypes.Find(1).TestFees.ToString();
                lblTestDate.Text=TestAppointment.AppointmentDate.ToShortDateString();
                lblTrial.Text = _Trials.ToString();

            }
        }
        
        private void _Save()
        {  
            clsTests MainTest = new clsTests();
            if (rbPass.Checked == true)
            {
                MainTest.TestResult_IsPassed = true;                
            }
            else
            {
                MainTest.TestResult_IsPassed = false;
            }
            MainTest.TestAppointmentID = _SchedualedTestAppID;
            MainTest.Notes = txtNotes.Text;
            MainTest.CreatedByUserID = TestAppointment.CreatedByUserID;
            if(MainTest.Save())
            {
                
                TestAppointment.IsLocked = true;
                if(TestAppointment.Save())
                {
                    MessageBox.Show("Done Successfully");
                    __ReloadList?.Invoke(this);
                    btnSave.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Error! Couldn't Lock This Test Appointment Scheduale, Please Try Again Later !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if(!clsTests.DeleteTest(MainTest.TestID))
                    {
                        MessageBox.Show("Error! Couldn't Remove this Extra Test result Please Check Your DB [<Tests> Table] !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

            }
            else
            {
                MessageBox.Show("Error! Couldn't Save Test Result !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("The Current Data Will be Saved Permenently once you click [Save] btn","Confirm",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)== DialogResult.OK)
            {
                _Save();
            }else
            {
                MessageBox.Show("Ignored Successfully");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
