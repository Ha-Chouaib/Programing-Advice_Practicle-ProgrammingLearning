using Bank_BusinessLayer;
using BankSystem.Person.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.User.UserControls
{
    public partial class ctrlUserCard : UserControl
    {
        public ctrlUserCard()
        {
            InitializeComponent();
        }
        clsUser _CurrentUser;
        public void __SetUserDataToCard(clsUser user)
        {
            _CurrentUser = user;
            if (user != null)
            {
                txtUserID.Text = user.UserID.ToString();
                txtUserName.Text = user.UserName;
                txtRole.Text = user.Role != null ? user.Role.RoleName : "N/A";
                txtCreatedDate.Text = user.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss");
                txtStatus.Text = user.IsActive ? "Active" : "Inactive";
                txtCreatedByUser.Text = clsUser.FindUserByID(user.CreatedByUserID)?.UserName ?? "N/A";

               _SetPersonalInfo(user.PersonalInfo);
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_CurrentUser != null)
            {
                frmShowPersonDetails PersonalDetails = new frmShowPersonDetails(_CurrentUser.PersonID);
                PersonalDetails.__PersonRecordChanged += _SetPersonalInfo;
                PersonalDetails.ShowDialog();
            }
        }
        private void _SetPersonalInfo(clsPerson Person)
        {
            if (Person == null)
                return;

            txtFullName.Text = Person.FullName;


           
            Image Profile;
            if (string.IsNullOrEmpty(Person.ImagePath))
                Profile = Person.Gender == 0 ? Properties.Resources.person_man : Properties.Resources.person_woman;
            else
                Profile = Image.FromFile(Person?.ImagePath);

            pictureBox1.Image = Profile;
        }
    }
}
