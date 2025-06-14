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
    public partial class frmLicenseClassDetails : Form
    {
        public frmLicenseClassDetails()
        {
            InitializeComponent();
        }

        int _LicenseClassID = -1;
        public frmLicenseClassDetails(int LicenseClassID)
        {
            InitializeComponent();
            _LicenseClassID = LicenseClassID;
        }

        private void frmLicenseClassDetails_Load(object sender, EventArgs e)
        {
            _DisplayLicenseClassInfo();
        }

        private void _DisplayLicenseClassInfo()
        {
            clsLicenseClasses Lic_Class = clsLicenseClasses.Find(_LicenseClassID);
            if (Lic_Class != null)
            {
                lblClassName.Text = Lic_Class.LicenseClassName;
                lblClassID.Text = Lic_Class.LicenseClassID.ToString();
                lblClassFees.Text = Lic_Class.LicenseFees.ToString();
                lblMinAllowedAge.Text = Lic_Class.MinAllowedAge.ToString();
                lblValidityLength.Text = Lic_Class.DefaultValidityLength.ToString();
                txtDescription.Text = Lic_Class.LicenseDescription;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
