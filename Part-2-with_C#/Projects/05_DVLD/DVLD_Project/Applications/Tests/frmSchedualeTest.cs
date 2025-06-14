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
        int _LocalDrivingLicenseApplicationID = -1;
        int _TestAppointmentID = -1;
        int _TestTypeID=-1;
        Image TestImg;

        bool _IsValide = true;

        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        clsMainApplication _RetakeTest_App = new clsMainApplication();
        clsTestAppointments _TestAppointment= new clsTestAppointments();
        clsTestTypes TestType;
        enum enMode { eAddNew, eUpdate }
        enum enNewTestMode { eFirstTime, eRetakeTest}

        enMode _Mode;
        enNewTestMode _NewAppointmentMode;

        public delegate void TriggerFunctionEventHandler(object sender);
        public event TriggerFunctionEventHandler __ReLoadSchedualeTest_List;
        public frmSchedualeTest(int TestAppointmentID, Image TestImg)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
            _Mode = enMode.eUpdate;
        }
        public frmSchedualeTest( int LocalDrivingLicenseApplicationID ,int TestTypeID,Image TestImg)
        {
            InitializeComponent();
            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this._TestTypeID = TestTypeID;
            this.TestImg = TestImg;
            _Mode = enMode.eAddNew;
           
        }

        private void frmSchedulingTest_Load(object sender, EventArgs e)
        {
            _PerformMode();
            _DisplayAppointmentInfo();
            _PerfomSchedualingConstraints();
        }


        private void _PerformMode()
        {
            
            if(_Mode== enMode.eUpdate)
            {
                _TestAppointment = clsTestAppointments.Find(_TestAppointmentID);
                _TestTypeID = _TestAppointment.TestTypeID;
                _LocalDrivingLicenseApplicationID = _TestAppointment.LDL_AppID;
               
                gbRetakeTestInfo.Enabled = false;
                return;
            }else
            {
               
                if (clsTestAppointments._GetTestTrials(_LocalDrivingLicenseApplicationID, _TestTypeID) == 0)
                {
                    _NewAppointmentMode = enNewTestMode.eFirstTime;
                    gbRetakeTestInfo.Enabled = false;
                    return;
                }
                _NewAppointmentMode = enNewTestMode.eRetakeTest;
                gbRetakeTestInfo.Enabled = true;
            }

        }
        private void _HandleRetakeTestGroupBox_BackColor()
        {

            foreach (Control ctrl in gbRetakeTestInfo.Controls)
            {
                if (ctrl is Panel pnl)
                {
                    if (gbRetakeTestInfo.Enabled)
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

        private bool _HandleIfRetakeTestApplication()
        {
            if(_NewAppointmentMode == enNewTestMode.eRetakeTest)
            {
                _RetakeTest_App.CreatedByUserID = clsGlobal.CurrentUserID;
                _RetakeTest_App.ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                _RetakeTest_App.ApplicationDate = DateTime.Now;
                _RetakeTest_App.ApplicationTypeID = (int)clsMainApplication.enApplicationTypes_IDs.RetakeTest;
                _RetakeTest_App.ApplicationStatus = (byte)clsMainApplication.enApplicationStatus.Completed;
                _RetakeTest_App.LastStatusDate = DateTime.Now;
                _RetakeTest_App.PaidFees = clsApplicationTypes.Find(_RetakeTest_App.ApplicationTypeID).AppFees;

                if(!_RetakeTest_App.Save())
                {
                    MessageBox.Show("Error Cannot Save Retake Test Application !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.RetakeTestApplicationID = _RetakeTest_App.MainApplicationID;
                lblR_TestAppID.Text = _RetakeTest_App.MainApplicationID.ToString();
            }
            return true;



        }

        private void _FillTestAppointmentRecord()
        {
            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.LDL_AppID = _LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dtSechedualeDate.Value;
            _TestAppointment.PaidFees = float.Parse(lbl_Fees.Text);
            _TestAppointment.IsLocked = false;
            _TestAppointment.CreatedByUserID = (short)clsGlobal.CurrentUserID;
        }

        private bool _HandleActiveLicenseConstraint()
        {
            if (_Mode == enMode.eAddNew && clsTestAppointments.HasActiveAppointment(_LocalDrivingLicenseApplicationID, _TestTypeID))
            {
                btnSave.Enabled=false;
                dtSechedualeDate.Enabled = false;
                lblErrorMSG.Visible=true;
                lblErrorMSG.Text = "This Person Already Has an Active Schedualed Tset! You Cannot Have Tow Active Appointments";
                return false;
            }

            return true;
        }
        private bool _HandleLockedAppointmentConstraint()
        {
            if ( _TestAppointment.IsLocked )
            {
                btnSave.Enabled = false;
                dtSechedualeDate.Enabled = false;
                lblErrorMSG.Visible = true;
                lblErrorMSG.Text = "This Appointment Is Locked Cannot Be Updated, The User Already Sat This Schadualed Test Before !";
                return false;
            }
            return true;
        }
        private bool _HandlePasingTestsHierarchy()
        {

            switch((clsTestTypes.enTestType)_TestTypeID)
            {
                case clsTestTypes.enTestType.eVisionTest:
                    lblErrorMSG.Visible = false;
                    return true;
                case clsTestTypes.enTestType.eWrittenTest:
                    if(!clsTestAppointments.DoesTestTypePassed(_LocalDrivingLicenseApplicationID,(int)clsTestTypes.enTestType.eVisionTest))
                    {
                        btnSave.Enabled = false;
                        dtSechedualeDate.Enabled = false;
                        lblErrorMSG.Visible = true;
                        lblErrorMSG.Text = "Should First Pass << Vision Test >> Before Moving To Written Test !";
                        return false;
                    }
                    return true;

                case clsTestTypes.enTestType.eStreetTest:

                    if (!clsTestAppointments.DoesTestTypePassed(_LocalDrivingLicenseApplicationID, (int)clsTestTypes.enTestType.eWrittenTest))
                    {
                        btnSave.Enabled = false;
                        dtSechedualeDate.Enabled = false;
                        lblErrorMSG.Visible = true;
                        lblErrorMSG.Text = "Should First Pass << Written Test >> Before Moving To Street Test !";
                        return false;
                    }
                    return true;
            }

            return true;
        }
        private bool _PerfomSchedualingConstraints()
        {
            if(!_HandleActiveLicenseConstraint()) return false;
            if(!_HandleLockedAppointmentConstraint()) return false;
            if(!_HandlePasingTestsHierarchy()) return false;

            return true;
        }
        private void _DisplayAppointmentInfo()
        {
            _HandleRetakeTestGroupBox_BackColor();

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
           
            TestType = clsTestTypes.Find(_TestTypeID);

            pbTestIMG.Image = TestImg;
            gbSchedualeTestContainer.Text = TestType.TestTitle;
            lblErrorMSG.Visible = false;


            lblDL_AppID.Text = _LocalDrivingLicenseApplicationID.ToString();

            lblLicenseClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.LicenseClassName;

            lblFullName.Text = _LocalDrivingLicenseApplication.PersonInfo.FullName;

            lbl_Fees.Text = TestType.TestFees.ToString();
            lblR_AppFees.Text = "0";

            lblTotalFees.Text = (TestType.TestFees + float.Parse(lblR_AppFees.Text)).ToString();

            lblTrial.Text = clsTestAppointments._GetTestTrials(_LocalDrivingLicenseApplicationID,_TestTypeID).ToString();
             
            if(_NewAppointmentMode == enNewTestMode.eRetakeTest)
                lblR_AppFees.Text = clsApplicationTypes.Find((int)clsMainApplication.enApplicationTypes_IDs.RetakeTest).AppFees.ToString();

        }

        private void dtSechedualeDate_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider errorP = new ErrorProvider();
            if (dtSechedualeDate.Value < DateTime.Now)
            {
                errorP.SetError(dtSechedualeDate, "The Current Date Is Under The Valide Scheduling Date Please Enter A Valide One!");
                _IsValide = false;
            }
            else
            {
                errorP.SetError(dtSechedualeDate, "");
            }
        }

        private bool _SchedualeTest()
        {

            if(!_HandleIfRetakeTestApplication()) return false;

            _FillTestAppointmentRecord();

            if (!_TestAppointment.Save())
            {
                MessageBox.Show("Error Cannot Save Updated Schedualed Appointment !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (_NewAppointmentMode == enNewTestMode.eRetakeTest) clsMainApplication.DeleteApp(_RetakeTest_App.MainApplicationID);
                return false;
            }

            return true;
        }

       

        private bool _TriggerValidations()
        {
            clsGlobal.ActivateContainerControlsOneByOne(DateContainer, typeof(DateTimePicker));
            return _IsValide;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_TriggerValidations())
            {
                _IsValide = true;
                return;
            }

            if (MessageBox.Show("Sure to Completed Test Schedualing Operation ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(_SchedualeTest())
                {
                    _Mode = enMode.eUpdate;
                    MessageBox.Show("Done Successfully");
                    btnSave.Text = "Update";
                    __ReLoadSchedualeTest_List?.Invoke(this);
                }
            }

        }
        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
