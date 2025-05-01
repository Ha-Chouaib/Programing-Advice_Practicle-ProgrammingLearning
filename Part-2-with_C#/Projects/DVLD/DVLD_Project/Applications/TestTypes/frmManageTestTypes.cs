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

namespace DVLD_Project.Applications.TestTypes
{
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _LoadTestsList();
        }

        private void _LoadTestsList()
        {
            DataTable DT=clsTestTypes.ListAll();
            dgvListTestTypes.DataSource = DT;

            dgvListTestTypes.Columns["TestTypeID"].HeaderText = "ID";
            dgvListTestTypes.Columns["TestTypeTitle"].HeaderText = "Title";
            dgvListTestTypes.Columns["TestTypeDescription"].HeaderText = "Description";
            dgvListTestTypes.Columns["TestTypeFees"].HeaderText = "Fees";

            lblRecords.Text = dgvListTestTypes.RowCount.ToString();
        }

        private void _ReloadTestsList(object sender)
        {
            _LoadTestsList();
        }

        private void editTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte TestID =byte.Parse( dgvListTestTypes.CurrentRow.Cells[0].Value.ToString());
            frmEditTestType EditTest = new frmEditTestType(TestID);
            EditTest.ReloadContent += _ReloadTestsList;
            EditTest.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
