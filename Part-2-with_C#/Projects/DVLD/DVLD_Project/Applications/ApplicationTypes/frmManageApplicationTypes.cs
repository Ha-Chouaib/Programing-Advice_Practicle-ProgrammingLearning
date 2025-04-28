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

namespace DVLD_Project.Applications.ApplicationTypes
{
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadApplicationTypes();
        }

        private void _LoadApplicationTypes()
        {
            DataTable DT = clsApplicationTypes.ListAll();
            dgvListAppTypes.DataSource = DT;

            dgvListAppTypes.Columns["ApplicationTypeID"].HeaderText = "ID";
            dgvListAppTypes.Columns["ApplicationTypeTitle"].HeaderText = "Tilte";
            dgvListAppTypes.Columns["ApplicationFees"].HeaderText = "Fees";

            lblRecords.Text = dgvListAppTypes.RowCount.ToString();
        }
        private void _ReloadAppList(object sender)
        {
            _LoadApplicationTypes();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            short AppID = short.Parse(dgvListAppTypes.CurrentRow.Cells[0].Value.ToString());
            frmEditApplicationType EditApp = new frmEditApplicationType(AppID);
            EditApp.ReloadContent += _ReloadAppList;
            EditApp.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
