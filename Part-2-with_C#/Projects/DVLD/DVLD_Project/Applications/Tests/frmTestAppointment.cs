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
    public partial class frmTestAppointment : Form
    {
        public frmTestAppointment()
        {
            InitializeComponent();
        }

        int _LDL_AppID = -1;
        int _TestTypeID = -1;

        public delegate void TriggerFunctionEventHandler(object sender);
        public event TriggerFunctionEventHandler __ReLoadList;
        public frmTestAppointment(int LocalDrivingLicenseAppID,int TestTypeID)
        {
            InitializeComponent();
            this._LDL_AppID = LocalDrivingLicenseAppID;
            this._TestTypeID = TestTypeID;
        }

        private void frmVisionTestAppointment_Load(object sender, EventArgs e)
        {
            _DisplayLocalAppInfo();
            _LoadSchedualedTestList();
        }

        private void _DisplayLocalAppInfo()
        {
            lblTestApointmentName.Text = clsTestTypes.Find(_TestTypeID).TestTitle+" Appointment";
            ctrlDisplayApplicationLicenseInfo1.__DisplayLDL_AppInfo(_LDL_AppID);
            ctrlDisplayApplicationInfo1.__DisplayApplicationInfo(clsLocalDrivingLicense.Find(_LDL_AppID).MainApplicationID);
        }

        private void _LoadSchedualedTestList()
        {
            DataTable DT = clsTestAppointments.ListTestAppointments_SchedualeInfo(_LDL_AppID,_TestTypeID);

            dgvListVisionTests.DataSource = DT;

            byte IsLockedCellIndex= (byte)dgvListVisionTests.Columns["IsLocked"].Index;
            dgvListVisionTests.Columns.Remove("IsLocked");

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.Name = "IsLocked";
            checkBoxColumn.HeaderText = "IsLocked";
            checkBoxColumn.DataPropertyName = "IsLocked";
            dgvListVisionTests.Columns.Insert(IsLockedCellIndex, checkBoxColumn);

            lblRecords.Text = $"[ {dgvListVisionTests.RowCount} ]";
            
        }
        private void _ReLoadList(object sender)
        {
            _LoadSchedualedTestList();
        }
        private void _ReloadLocalDrivingLicenseList(object sender)
        {
            __ReLoadList?.Invoke(this);
        }

        private void btnAddAppointmrnt_Click(object sender, EventArgs e)
        {
            byte Trials = (byte)dgvListVisionTests.RowCount;
            frmSchedualeTest NewSchedualeTest;
            if (Trials > 0)
            {   
                int CurrentSchedualedTest_ID =clsTestAppointments.GetCurrentAppointmetID(_LDL_AppID,_TestTypeID);

                clsTestAppointments TestAppointment = clsTestAppointments.Find(CurrentSchedualedTest_ID);
                if (TestAppointment != null)
                {
                    if(! TestAppointment.IsLocked)
                    {
                        MessageBox.Show("There's Already An Active Schedualed Test, You Cannot Add New One !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }

                    if (clsTests.Find(CurrentSchedualedTest_ID).TestResult_IsPassed)
                    {
                        MessageBox.Show("The Vision Test is Already Passed Successfully, You Cannot Retake it Now!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            NewSchedualeTest = new frmSchedualeTest(_LDL_AppID, Trials,true,_TestTypeID);
            NewSchedualeTest.__ReLoadSchedualeTest_List += _ReLoadList;
            NewSchedualeTest.ShowDialog();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvListVisionTests.CurrentRow.Cells[0].Value;

            frmSchedualeTest SchedualeTest_Update = new frmSchedualeTest(TestAppointmentID,(byte)dgvListVisionTests.RowCount,false,_TestTypeID);
            SchedualeTest_Update.__ReLoadSchedualeTest_List += _ReLoadList;
            SchedualeTest_Update.Show();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvListVisionTests.CurrentRow.Cells[0].Value;
            byte Trials = (byte)dgvListVisionTests.RowCount;
            clsTestAppointments TestAppoint = clsTestAppointments.Find(TestAppointmentID);
            if (TestAppoint != null)
            {
                if (TestAppoint.IsLocked)
                {
                    MessageBox.Show("You can Not Take This Test it's Already Taken", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else
                {
                    frmTakeTest TakeTest = new frmTakeTest(TestAppointmentID,Trials);
                    TakeTest.__ReloadList += _ReLoadList;
                    TakeTest.__ReloadList += _ReloadLocalDrivingLicenseList;
                    TakeTest.ShowDialog();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}

