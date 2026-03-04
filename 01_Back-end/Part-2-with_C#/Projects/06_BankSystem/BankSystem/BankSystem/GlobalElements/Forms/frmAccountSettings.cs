using BankSystem.Person.Forms;
using BankSystem.User.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.GlobalElements.Forms
{
    public partial class frmAccountSettings : Form
    {
        public Action __OnLogout;
        public frmAccountSettings()
        {
            InitializeComponent();
        }


        frmHomePage _HomePage;
        public frmAccountSettings(object caller)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            if (caller is Control control)
            {
                Point screenPoint = control.PointToScreen(Point.Empty);
                _HomePage = control.FindForm() as frmHomePage;
                this.Location = new Point(
                    screenPoint.X + Math.Abs(control.Width - this.Width)/2,
                    screenPoint.Y + control.Height
                );
            }
        }
        private void personalInfo_Click(object sender, EventArgs e)
        {
            frmFindPerson personnal = new frmFindPerson(clsGlobal_BL.LoggedInUser.PersonalInfo);
            personnal.ShowDialog();
        }

        private void btnUserInfo_Click(object sender, EventArgs e)
        {
            frmFindUser userRecord = new frmFindUser(clsGlobal_BL.LoggedInUser);
            userRecord.ShowDialog();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword(clsGlobal_BL.LoggedInUser.UserID);
            changePassword.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {   
                this.Close();
                _HomePage.Close();
            }
        }

        private void frmAccountSettings_MouseLeave(object sender, EventArgs e)
        {
            CheckMouseOutside();
        }
        private void CheckMouseOutside()
        {
            Point mousePos = Cursor.Position;

            if (!this.Bounds.Contains(mousePos))
            {
                this.Close();
            }
        }
    }
}
