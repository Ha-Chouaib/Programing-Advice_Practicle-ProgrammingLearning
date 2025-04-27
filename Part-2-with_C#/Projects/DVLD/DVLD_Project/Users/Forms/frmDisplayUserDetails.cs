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

namespace DVLD_Project.Users.Forms
{
    public partial class frmDisplayUserDetails : Form
    {

        int _UserID;
        public frmDisplayUserDetails()
        {
            InitializeComponent();
        }
        public frmDisplayUserDetails(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
        }

        private void frmDisplayUserDetails_Load(object sender, EventArgs e)
        {
            _LoadUserUnfo();
        }
        private void _LoadUserUnfo()
        {
            clsUsers User = clsUsers.Find(_UserID);
            if(User != null)
            {

                ctrlPersonDetails1.DisplayPersonInfo(User.PersonID);
                ctrlShowLoginInfo1.DisplayUserInfo(User.UserID);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
