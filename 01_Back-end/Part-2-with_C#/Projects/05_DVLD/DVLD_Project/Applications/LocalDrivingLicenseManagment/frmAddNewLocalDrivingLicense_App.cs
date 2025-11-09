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

namespace DVLD_Project.Applications.LDLApps
{
    public partial class frmAddNewLocalDrivingLicense_App : Form
    {

        private int _PersonID = -1;


        public delegate void TriggerFunctionEventHandler(object sender);
        public event TriggerFunctionEventHandler __ReloadContent;
        public frmAddNewLocalDrivingLicense_App()
        {
            InitializeComponent();
        }
        public frmAddNewLocalDrivingLicense_App(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void frmAddNewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrlFindPerson1.__ReturnPersonID += _GetPersonID;
            _LoadLicenseClasses();
            _UpLoadNewAppMainInfo();
            if (clsPeople.IsExist(_PersonID))
            {
                ctrlFindPerson1.__EnableFilter = false;
                ctrlFindPerson1.__DisplayPersonalInfo(_PersonID);

            }
        }

      
        private void _LoadLicenseClasses()
        {
            cmbLicenseClasses.SelectedIndexChanged -= cmbLicenseClasses_SelectedIndexChanged;

            Dictionary<short, string> LicenseClasses = new Dictionary<short, string>();

            DataTable DT = clsLicenseClasses.LicenseClassesList();
            foreach(DataRow row in DT.Rows )
            {
                LicenseClasses.Add(Convert.ToInt16( row["LicenseClassID"] ),row["ClassName"].ToString());
            }
            cmbLicenseClasses.DataSource =new BindingSource(LicenseClasses, null);
            cmbLicenseClasses.DisplayMember = "Value";
            cmbLicenseClasses.ValueMember = "Key";
            cmbLicenseClasses.SelectedIndex = 2;

            cmbLicenseClasses.SelectedIndexChanged += cmbLicenseClasses_SelectedIndexChanged;

        }
        private void _GetPersonID(object sender,int PersonID)
        {
            _PersonID = PersonID;
            if(clsPeople.IsExist(_PersonID))
            {
                ctrlFindPerson1.__DisplayPersonalInfo(_PersonID);
            }
            else
            {
                MessageBox.Show("Cannot Found This Person", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void _UpLoadNewAppMainInfo()
        {
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblAppFees.Text = clsLicenseClasses.Find((short)cmbLicenseClasses.SelectedValue).LicenseFees.ToString();
            lblCreatedByUser.Text = clsUsers.Find(clsGlobal.CurrentUserID).UserName;
        }

      
        private void _AddNewLocalDrivingLicenseApplication()
        {   
            clsPeople Person = clsPeople.Find(_PersonID);
            if (Person == null)
            {
                MessageBox.Show($"No Person With ID << {_PersonID} >> is Exist !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            short LicenseClassID =(short) cmbLicenseClasses.SelectedValue;
            short PersonAge =(short)(DateTime.Now.Year - Person.DateOfBirth.Year);

            clsLicenseClasses LicenseClass = clsLicenseClasses.Find(LicenseClassID);

            if(PersonAge < LicenseClass.MinAllowedAge)
            {
                MessageBox.Show("The Current Person Is Under The Allowed Age For This License Class", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clsMainApplication.CheckApplicationStatus(Person.PersonID,LicenseClassID,(byte)clsMainApplication.enApplicationStatus.New))
            {
                MessageBox.Show($"Not Able To Add A New App of This Class Is Already Exist At New State !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsDrivers.ExistByPersonID(Person.PersonID) && clsDrivers.FindByPersonID(Person.PersonID).HasActiveLicenseClass(LicenseClassID))
            {
                MessageBox.Show($"This Driver Already Has An Active License With This LicenseClass !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Sure To Add This App", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                MessageBox.Show("The Operation Ignored Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            clsLocalDrivingLicenseApplication NewLocalLicense_Application = new clsLocalDrivingLicenseApplication();
            NewLocalLicense_Application.ApplicationDate = DateTime.Now;
            NewLocalLicense_Application.ApplicationStatus =(byte) clsMainApplication.enApplicationStatus.New;
            NewLocalLicense_Application.ApplicantPersonID = _PersonID;
            NewLocalLicense_Application.LastStatusDate = DateTime.Now;
            NewLocalLicense_Application.CreatedByUserID = clsGlobal.CurrentUserID;
            NewLocalLicense_Application.ApplicationTypeID = (int)clsMainApplication.enApplicationTypes_IDs.NewLocalDrivingLicenseService;
            NewLocalLicense_Application.PaidFees = clsApplicationTypes.Find(NewLocalLicense_Application.ApplicationTypeID).AppFees;
            NewLocalLicense_Application.MainApplicationID = NewLocalLicense_Application.MainApplicationID;
            NewLocalLicense_Application.LicenseClassID = (byte)LicenseClassID;

            if (!NewLocalLicense_Application.Save())
            {                            
                MessageBox.Show("Couldn't Save The Current Local Driving App !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            MessageBox.Show("Done Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblAppID.Text = NewLocalLicense_Application.MainApplicationID.ToString();
            __ReloadContent?.Invoke(this);


        }
        
        private void cmbLicenseClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblAppFees.Text = clsLicenseClasses.Find((short)cmbLicenseClasses.SelectedValue).LicenseFees.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnNext.Enabled = clsPeople.IsExist(_PersonID);
            tabControl1.SelectedTab = tabApplicationInfo;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           
            tabControl1.SelectedTab = tabPersonalInfo;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _AddNewLocalDrivingLicenseApplication();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Sure To Leave ?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    
    
    }
}
