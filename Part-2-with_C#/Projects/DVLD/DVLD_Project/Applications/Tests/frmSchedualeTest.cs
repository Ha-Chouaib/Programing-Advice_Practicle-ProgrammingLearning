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
using DVLD_BusinessLayer.Applications;
using DVLD_BusinessLayer.Tests;

namespace DVLD_Project.Applications.Tests
{
    public partial class frmSchedualeTest : Form
    {
        public frmSchedualeTest()
        {
            InitializeComponent();
        }
        public delegate void TriggerFunctionEventHandler(object sender);
        public event TriggerFunctionEventHandler __ReLoadSchedualeTest_List;
        int _ID = -1;
        enum enMode { eAddNew,eUpdate}
        enMode _Mode;
        public frmSchedualeTest(int ID,bool isAddNewMode)
        {
            InitializeComponent();
            this._ID = ID;
            if (isAddNewMode)
            {
                _Mode = enMode.eAddNew;
            }
            else
                _Mode = enMode.eUpdate;
        }

        private void frmSchedualeTest_Load(object sender, EventArgs e)
        {
            _LoadAppInfo();
        }

        private void _LoadAppInfo()
        {
            if (_ID != -1)
            {
                if(_Mode == enMode.eUpdate)
                {
                    clsTestAppointments TestAppointment = clsTestAppointments.Find(_ID);
                    clsMainApplication MainApplication = clsMainApplication.Find(TestAppointment.LDL_AppID);

                    dtSechedualeDate.Value = TestAppointment.AppointmentDate;
                    if(TestAppointment.IsLocked)
                    {
                        btnSave.Enabled = false;
                        dtSechedualeDate.Enabled = false;
                        lblUpdateErrorMSG.Enabled = true;
                        return;
                    }
                   
                }
                else
                {

                }
                //dtSechedualeDate.MinDate = DateTime.Now;

                clsLocalDrivingLicense LocalLicenseApp = clsLocalDrivingLicense.Find(_ID);
                clsMainApplication MainApp = clsMainApplication.Find(LocalLicenseApp.AppID);
                clsPeople Person = clsPeople.Find(MainApp.ApplicantPersonID);

                lblDL_AppID.Text = _ID.ToString();
                lblLicenseClass.Text = clsLicenseClasses.Find(LocalLicenseApp.LicenseClassID).LicenseClassName;

                lblFullName.Text = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;

                lblFees.Text = clsTestTypes.Find(1).TestFees.ToString();
                lblTotalFees.Text = lblFees.Text;
                
            }    
        }

        private void _SaveSchedualeTest()
        {
            if(MessageBox.Show("Sure to Complete Test Schedualing Operation ?", "Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsTestAppointments NewAppointment=new clsTestAppointments();
                NewAppointment.TestTypeID = 1;
                NewAppointment.LDL_AppID = _ID;
                NewAppointment.AppointmentDate = dtSechedualeDate.Value;
                NewAppointment.PaidFees = float.Parse(lblFees.Text);
                NewAppointment.IsLocked = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _SaveSchedualeTest();
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
