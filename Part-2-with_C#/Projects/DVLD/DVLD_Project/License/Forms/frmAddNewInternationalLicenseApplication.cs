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
using DVLD_BusinessLayer.Licenses;

namespace DVLD_Project.License
{
    public partial class frmAddNewInternationalLicenseApplication : Form
    {
        public frmAddNewInternationalLicenseApplication()
        {
            InitializeComponent();
        }
        clsLicenses _License;
        clsInternationalLicenses InternationalLicense = new clsInternationalLicenses();
        clsMainApplication NewInternationalLic_Application = new clsMainApplication();
        private void frmAddNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            ctrlFindAndDisplayDriverLicense1.__GetLicenseRecord += _GetLicenseRecord;
            _DisplayBasicApplicationInfo();
        }

        private void _GetLicenseRecord(object sender, clsLicenses License)
        {
            _License = License;

            ctrlFindAndDisplayDriverLicense1.__DisplayLicenseRecord(_License.LicenseID);
            lblLocalLicenseID.Text = _License.LicenseID.ToString();
            lnkShowLicensesHist.Enabled = true;
        }

        private void  _DisplayBasicApplicationInfo()
        {
            lnkShowLicenseInfo.Enabled = false;
            lnkShowLicensesHist.Enabled = false;

                lblApplicationDate.Text=DateTime.Now.ToShortDateString();
                lblIssueDate.Text = DateTime.Now.ToShortDateString();
                lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
                lblCreatedByUser.Text = clsUsers.Find(clsGlobal.CurrentUserID).UserName;
                lblFees.Text = clsApplicationTypes.Find(6).AppFees.ToString();
            
        }

        private bool _AddNewInternationalLicense_Validation()
        {
            if (clsInternationalLicenses.Exist(_License.DriverID))
            {
                MessageBox.Show("This Driver Already Has An International License You Cannot Have Two Licenses!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InternationalLicense = clsInternationalLicenses.Find_DriverID(_License.DriverID);
                lnkShowLicenseInfo.Enabled = true;
                return false;
            }
            byte Class3_OrdinaryDrivingLicense_ID = 3;
            if (_License.LicenseClassID != Class3_OrdinaryDrivingLicense_ID)
            {
                MessageBox.Show("International Linked Only With Local License << Ordinary Driving License >>. Please Enter a Valide Local License !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!_License.IsActive)
            {
                MessageBox.Show("This Local License Is InActive ! [You Cannot Add International License To Inactive Local License]", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_License.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show("The Local License Expiration Date Is Done ! [Please Renew Your License] ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private bool _AddNewInternationalLicense()
        {
            

            if(_AddNewInternationalLicense_Validation())
            {
               
                NewInternationalLic_Application.AppDate = DateTime.Now;
                NewInternationalLic_Application.ApplicantPersonID = clsMainApplication.Find(_License.ApplicationID).ApplicantPersonID;
                NewInternationalLic_Application.AppStatus =(byte) clsGlobal.enApplicationStatus.Complete;
                NewInternationalLic_Application.AppTypeID = (int)clsGlobal.enApplicationTypes_IDs.NewInternationalLicense;
                NewInternationalLic_Application.LastStatusDate = DateTime.Now;
                NewInternationalLic_Application.CreatedByUserID = clsGlobal.CurrentUserID;
                NewInternationalLic_Application.PaidFees = clsApplicationTypes.Find(NewInternationalLic_Application.AppTypeID).AppFees;

                if(!NewInternationalLic_Application.Save())
                {
                    MessageBox.Show("Cannot Save The New Application !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }else
                {
                    InternationalLicense.IssuedUsingLocalLicenseID=_License.LicenseID;
                    InternationalLicense.IssueDate = DateTime.Now;
                    InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
                    InternationalLicense.DriverID = _License.DriverID;
                    InternationalLicense.CreatedByUserID = clsGlobal.CurrentUserID;
                    InternationalLicense.ApplicationID = NewInternationalLic_Application.AppID;
                    InternationalLicense.IsActive = true;
                    
                    if(!InternationalLicense.Save())
                    {

                        MessageBox.Show("Cannot Save The New International License Please Try Again Later !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        clsMainApplication.DeleteApp(NewInternationalLic_Application.AppID);
                        return false;
                    }
                }

                return true;
            }else
            {
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show("Sure To Complete The Operation ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_AddNewInternationalLicense())
                {
                    MessageBox.Show("Done Successfully");
                    lblInterNationalLicenseID.Text = "[ " + InternationalLicense.InternationalLicenseID.ToString() + " ]";
                    lblApplicationID.Text = "[ " + NewInternationalLic_Application.AppID.ToString() + " ]";
                    lnkShowLicenseInfo.Enabled = true;
                }

            }
            else
            {
                MessageBox.Show("The Operation Ignored successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lnkShowLicensesHist_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDriverLicensesHistory LicensesHistory = new frmShowDriverLicensesHistory(clsMainApplication.Find(_License.ApplicationID).ApplicantPersonID);

            LicensesHistory.ShowDialog();
        }

        private void lnkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDisplayInternationalLicenseInfo InternationalLicenseInfo = new frmDisplayInternationalLicenseInfo(InternationalLicense.InternationalLicenseID);

            if (!clsInternationalLicenses.Exist(_License.DriverID))
            {
                MessageBox.Show($"No License Exists With ID << {InternationalLicense.InternationalLicenseID} >> !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            InternationalLicenseInfo.ShowDialog();
        }
    }
}
