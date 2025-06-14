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

namespace DVLD_Project.License
{
    public partial class frmShowDriverLicensesHistory : Form
    {
        public frmShowDriverLicensesHistory()
        {
            InitializeComponent();
        }
        int _PersonID = -1;
        public frmShowDriverLicensesHistory(int PersonID)
        {
            InitializeComponent();
            this._PersonID = PersonID;
        }

        private void frmShowDriverLicensesHistory_Load(object sender, EventArgs e)
        {
            _DisplayDriverData();
        }

        private void _DisplayDriverData()
        {
            ctrlPersonDetails1.__DisplayPersonInfo(_PersonID);
            int DriverID = clsDrivers.FindByPersonID(_PersonID)._DriverID;
            ctrlDriverLicensesHistory1.__ListDriverLicenses_History(DriverID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
