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

namespace DVLD_Project.Users.UserControls
{
    public partial class ctrlShowLoginInfo : UserControl
    {
        public ctrlShowLoginInfo()
        {
            InitializeComponent();
        }

        public void DisplayUserInfo(int UserID)
        {
            clsUsers User = clsUsers.Find(UserID);
            if(User != null)
            {
                lblUserID.Text =User.UserID.ToString();
                lblUserName.Text = User.UserName;
                if (User.IsActive == true)
                    lblIsActive.Text = "Yes";
                else
                    lblIsActive.Text = "No";
            }
        }
    }
}
