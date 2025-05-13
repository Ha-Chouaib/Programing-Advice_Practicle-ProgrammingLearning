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
using DVLD_BusinessLayer.Tests;
using DVLD_BusinessLayer;
using DVLD_Project.Properties;

namespace DVLD_Project.Applications.Tests
{
    public partial class frmSchedualeTest : Form
    {
        int _LDLApp_OR_Appointment_ID = -1;
        byte _Trials = 0;
        int _TestTypeID=-1;
        enum enMode { eAddNew, eUpdate }
        enMode _Mode;
        public frmSchedualeTest()
        {
            InitializeComponent();
        }
        public frmSchedualeTest( int LDLApp_OR_Appointment_ID, byte Trials, bool isAddNewMode, int TestTypeID)
        {
            InitializeComponent();
            this._LDLApp_OR_Appointment_ID = LDLApp_OR_Appointment_ID;
            this._Trials = Trials;
            this._TestTypeID = TestTypeID;
            if (isAddNewMode)
            {
                _Mode = enMode.eAddNew;
            }
            else
                _Mode = enMode.eUpdate;
        }

        private void frmSchedulingTest_Load(object sender, EventArgs e)
        {
            _LoadAppInfo();

        }

        clsTestAppointments TestAppointment;
        clsLocalDrivingLicense LocalDrivingLicenseApp;
        clsPeople Person;
        public delegate void TriggerFunctionEventHandler(object sender);
        public event TriggerFunctionEventHandler __ReLoadSchedualeTest_List;
        private void _RetakeTestGroupBox_BackColorHandler(bool IsEnable)
        {

            foreach (Control ctrl in gbRetakeTestInfo.Controls)
            {
                if (ctrl is Panel pnl)
                {
                    if (IsEnable)
                    {
                        gbRetakeTestInfo.BackColor = Color.FromArgb(30, 30, 30);
                        pnl.BackColor = Color.FromArgb(20, 20, 20);

                    }
                    else
                    {
                        gbRetakeTestInfo.BackColor = Color.FromArgb(60, 60, 60);
                        pnl.BackColor = Color.FromArgb(60, 60, 60);

                    }

                }
            }

        }
        private void _LoadAppInfo()
        {
            if (_LDLApp_OR_Appointment_ID != -1)
            {
                gbSchedualeTestContainer.Text = clsTestTypes.Find(_TestTypeID).TestTitle;
                gbRetakeTestInfo.Enabled = false;
                _RetakeTestGroupBox_BackColorHandler(false);
                lblUpdateErrorMSG.Visible = false;
                lblR_AppFees.Text = "0";
                if (_Mode == enMode.eUpdate)
                {
                    TestAppointment = clsTestAppointments.Find(_LDLApp_OR_Appointment_ID);
                    LocalDrivingLicenseApp = clsLocalDrivingLicense.Find(TestAppointment.LDL_AppID);

                    dtSechedualeDate.Value = TestAppointment.AppointmentDate;
                    if (TestAppointment.IsLocked)
                    {
                        btnSave.Enabled = false;
                        dtSechedualeDate.Enabled = false;
                        lblUpdateErrorMSG.Visible = true;

                        btnSave.BackColor = Color.FromArgb(50, 50, 50);
                        lblUpdateErrorMSG.ForeColor = Color.Red;

                    }
                }
                else
                {
                    LocalDrivingLicenseApp = clsLocalDrivingLicense.Find(_LDLApp_OR_Appointment_ID);

                    if (this._Trials > 0)
                    {
                        gbRetakeTestInfo.Enabled = true;
                        _RetakeTestGroupBox_BackColorHandler(false);

                        lblR_AppFees.Text = clsApplicationTypes.Find(2).AppFees.ToString();
                    }
                }

                lblDL_AppID.Text = _LDLApp_OR_Appointment_ID.ToString();

                lblLicenseClass.Text = clsLicenseClasses.Find(LocalDrivingLicenseApp.LicenseClassID).LicenseClassName;

                Person = clsPeople.Find(clsMainApplication.Find(LocalDrivingLicenseApp.MainApplicationID).ApplicantPersonID);
                lblFullName.Text = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;

                lbl_Fees.Text = clsTestTypes.Find(1).TestFees.ToString();

                lblTotalFees.Text = (float.Parse(lbl_Fees.Text) + float.Parse(lblR_AppFees.Text)).ToString();

                lblTrial.Text = this._Trials.ToString();
            }
        }

        private bool _AddNewScheduale()
        {
            clsTestAppointments NewAppointment = new clsTestAppointments();
            NewAppointment.TestTypeID = _TestTypeID;
            NewAppointment.LDL_AppID = LocalDrivingLicenseApp.LDL_ID;
            NewAppointment.AppointmentDate = dtSechedualeDate.Value;
            NewAppointment.PaidFees = float.Parse(lbl_Fees.Text);
            NewAppointment.IsLocked = false;
            NewAppointment.CreatedByUserID = (short)clsGlobal.CurrentUserID;
            if (_Trials > 0)
            {
                clsMainApplication RetakeTest_App = new clsMainApplication();
                RetakeTest_App.CreatedByUserID = clsGlobal.CurrentUserID;
                RetakeTest_App.ApplicantPersonID = Person.PersonID;
                RetakeTest_App.AppDate = DateTime.Now;
                RetakeTest_App.AppTypeID = 2;//2== Retake Test
                RetakeTest_App.AppStatus = 3;//3 == Complete
                RetakeTest_App.LastStatusDate = DateTime.Now;
                RetakeTest_App.PaidFees = clsApplicationTypes.Find(2).AppFees;
                if (!RetakeTest_App.Save())
                {
                    MessageBox.Show("Error Cannot Save Retake Test Application !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                    lblR_TestAppID.Text = RetakeTest_App.AppID.ToString();
            }
            return NewAppointment.Save();
        }

        private bool _UpdateScheduling()
        {
            TestAppointment.AppointmentDate = dtSechedualeDate.Value;
            return TestAppointment.Save();
        }
        private void _SaveSchedualedTestData()
        {
            if (MessageBox.Show("Sure to Complete Test Schedualing Operation ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                switch (_Mode)
                {
                    case enMode.eUpdate:
                        if (_UpdateScheduling())
                        {
                            MessageBox.Show("Done Successfully");
                            __ReLoadSchedualeTest_List?.Invoke(this);
                        }
                        else
                            MessageBox.Show("Error Cannot Save Updated Scheduale !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        break;

                    case enMode.eAddNew:
                        if (_AddNewScheduale())
                        {
                            MessageBox.Show("Done Successfully");

                            __ReLoadSchedualeTest_List?.Invoke(this);
                            btnSave.Enabled = false;
                        }
                        break;

                }


            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ErrorProvider errorP = new ErrorProvider();
            if (dtSechedualeDate.Value < DateTime.Now)
            {
                errorP.SetError(dtSechedualeDate, "The Current Date Is Under The Valide Scheduling Date Please Enter A Valide One!");
                return;
            }
            else
            {
                errorP.SetError(dtSechedualeDate, "");
            }
            _SaveSchedualedTestData();
        }
        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
