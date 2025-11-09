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

namespace DVLD_Project.Applications.User_Controls
{
    public partial class ctrlDisplayApplicationInfo : UserControl
    {
        public ctrlDisplayApplicationInfo()
        {
            InitializeComponent();
        }
        int _AppID = -1;
        clsMainApplication App;
        int _PersonID =-1;
        private void ctrlDisplayApplicationInfo_Load(object sender, EventArgs e)
        {
            
        }

        private void _ShowAppDetails()
        {
            if (_AppID != -1)
            {
                App = clsMainApplication.FindMainApplication(_AppID);
                
                lblAppID.Text = _AppID.ToString();
                
                switch(App.ApplicationStatus)
                {
                    case 1:
                        lblStatus.Text = "New";
                        break;
                    case 2:
                        lblStatus.Text = "Cancelled";
                        break;
                    case 3:
                        lblStatus.Text = "Completed";
                        break;
                    default:
                        lblStatus.Text = "???";
                        break;
                }
                lblFees.Text=App.PaidFees.ToString();
                lblDate.Text = App.ApplicationDate.ToShortDateString();
                lblStatusDate.Text=App.LastStatusDate.ToShortDateString();

                lblCreatedByUser.Text = clsUsers.Find(App.CreatedByUserID).UserName;

                lblAppType.Text = clsApplicationTypes.Find(App.ApplicationTypeID).AppTitle;

                clsPeople Person = clsPeople.Find(App.ApplicantPersonID);
                _PersonID = Person.PersonID;

                string FullName = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;
                lblApplicantName.Text = FullName;


            }
        }
        public void __DisplayApplicationInfo(int MainApplicationID)
        {
            _AppID = MainApplicationID;
            _ShowAppDetails();
        }

        private void lnkPersonDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_PersonID == -1)
            {
                MessageBox.Show($"No Person founded By ID << {_PersonID} >> !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmPersonDetails ShowPersonInf = new frmPersonDetails(_PersonID);
            ShowPersonInf.ShowDialog();
        }
    }
}
