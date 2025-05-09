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

namespace DVLD_Project.Applications.Tests
{
    public partial class frmVisionTestAppointment : Form
    {
        public frmVisionTestAppointment()
        {
            InitializeComponent();
        }

        int _LDL_AppID = -1;
        public frmVisionTestAppointment(int LocalAppID)
        {
            InitializeComponent();
            _LDL_AppID = LocalAppID;
        }

        private void frmVisionTestAppointment_Load(object sender, EventArgs e)
        {
            _LoadSchedualedTestList();
        }

        private void _LoadSchedualedTestList()
        {
            DataTable DT = clsTestAppointments.ListTestAppointments_SchedualeInfo(_LDL_AppID,1);

            DT.DefaultView.Sort = "TestAppointmentID DESC";
            dgvListVisionTests.DataSource = DT;

            byte IsLockedCellIndex= (byte)dgvListVisionTests.Columns["IsLocked"].Index;
            dgvListVisionTests.Columns.Remove("IsLocked");

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.Name = "IsLocked";
            checkBoxColumn.HeaderText = "IsLocked";
            checkBoxColumn.DataPropertyName = "IsLocked";
            dgvListVisionTests.Columns.Insert(IsLockedCellIndex, checkBoxColumn);
        }
        private void _ReLoadList(object sender)
        {
            _LoadSchedualedTestList();
        }
        
        private void btnAddAppointmrnt_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicense LocalApp = clsLocalDrivingLicense.Find(_LDL_AppID);
            frmSchedualeTest NewSchedualeTest = new frmSchedualeTest(_LDL_AppID, true);

            if (dgvListVisionTests.RowCount > 0)
            {
                int CurrentSchedualedTest_ID =(int) dgvListVisionTests.Rows[0].Cells[0].Value;
                clsTestAppointments TestAppointment = clsTestAppointments.Find(CurrentSchedualedTest_ID);
                if (TestAppointment != null)
                {
                    if(! TestAppointment.IsLocked)
                    {
                        MessageBox.Show("Can't NewSchedualeTest Another Test There's Already An Active Schedualed Test !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                    if(clsTests.Find(CurrentSchedualedTest_ID).TestResult_IsPassed)
                    {
                        MessageBox.Show("The Vision Test is Already Passed Successfully, You Cannot Retake it AnyMore!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    NewSchedualeTest.ShowDialog();
                }
            }
            else
            {
                NewSchedualeTest.ShowDialog();
            }

            
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvListVisionTests.CurrentRow.Cells[0].Value;

            frmSchedualeTest SchedualeTest_Update = new frmSchedualeTest(TestAppointmentID,false);
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvListVisionTests.CurrentRow.Cells[0].Value;
            clsTestAppointments TestAppoint = clsTestAppointments.Find(TestAppointmentID);
            if (TestAppoint != null)
            {
                if (TestAppoint.IsLocked)
                {
                    MessageBox.Show("You can Not Take This Test it's Already Taken", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else
                {
                    frmTakeTest TakeTest = new frmTakeTest(TestAppointmentID);
                    TakeTest.__ReloadSchedualTestList += _ReLoadList;
                    TakeTest.ShowDialog();
                }
            }
        }
    }
}

