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
    public partial class frmAddNewLocalDrivingLicense : Form
    {

        private int _LDlAppID = -1;
        private int _PersonID = -1;


        public delegate void TriggerFunctionEventHandler(object sender);
        public event TriggerFunctionEventHandler __ReloadContent;
        public frmAddNewLocalDrivingLicense()
        {
            InitializeComponent();
        }
        public frmAddNewLocalDrivingLicense(int LDLAppID)
        {
            InitializeComponent();
            _LDlAppID = LDLAppID;
        }

        private void frmAddNewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrlFindPerson1.__ReturnPersonID += _GetPersonID;
            _LoadLicenseClasses();
            _UpLoadNewAppMainInfo();
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

      
        private void _AddNewApp()
        {   
            if(_PersonID == -1)
            {
                return;
            }
            clsPeople Person = clsPeople.Find(_PersonID);
            if(Person != null)
            {
                
                short LicenseClassID =(short) cmbLicenseClasses.SelectedValue;
                short PersonAge =(short)(DateTime.Now.Year - Person.DateOfBirth.Year);

                clsLicenseClasses LicenseClass = clsLicenseClasses.Find(LicenseClassID);

                if(PersonAge < LicenseClass.MinAllowedAge)
                {
                    MessageBox.Show("The Current Person Is Under The Allowed Age For This License Class", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (clsLocalDrivingLicense.IsAppHas_NewStatus(_PersonID,LicenseClassID))
                {
                    MessageBox.Show($"Not Able To Add A New App of This Class Is Already Exist At New State !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    if (MessageBox.Show("Sure To Add This App", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        clsMainApplication NewApp = new clsMainApplication();
                        NewApp.AppDate = DateTime.Now;
                        NewApp.AppStatus = 1;
                        NewApp.ApplicantPersonID = _PersonID;
                        NewApp.LastStatusDate = DateTime.Now;
                        NewApp.CreatedByUserID = clsGlobal.CurrentUserID;
                        NewApp.AppTypeID = 1;
                        NewApp.PaidFees = clsApplicationTypes.Find(1).AppFees;

                        if (NewApp.Save())
                        {

                            clsLocalDrivingLicense NewLocalLicense = new clsLocalDrivingLicense();
                            NewLocalLicense.MainApplicationID = NewApp.AppID;
                            NewLocalLicense.LicenseClassID =(byte) LicenseClassID;
                            if (NewLocalLicense.Save())
                            {
                                MessageBox.Show("Done Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                lblAppID.Text = NewApp.AppID.ToString();
                                __ReloadContent?.Invoke(this);
                            }
                            else
                            {
                                MessageBox.Show("The Operation Failed! Couldn't Save The New License | This Will Lead To Remove The New Saved Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                clsMainApplication.DeleteApp(NewApp.AppID);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Couldn't Save The Current Local Driving App !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        MessageBox.Show("The Operation Ignored Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                
            }else
            {
                MessageBox.Show($"No Person With ID << {_PersonID} >> is Exist !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbLicenseClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblAppFees.Text = clsLicenseClasses.Find((short)cmbLicenseClasses.SelectedValue).LicenseFees.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabApplicationInfo;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPersonalInfo;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _AddNewApp();
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
