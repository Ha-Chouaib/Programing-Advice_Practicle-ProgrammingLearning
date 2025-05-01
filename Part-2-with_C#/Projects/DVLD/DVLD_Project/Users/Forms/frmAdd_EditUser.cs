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
    public partial class frmAdd_EditUser : Form
    {
        enum enMode { eAddNew,eUpdate}
        enMode _Mode;

        int _UserID;
        public frmAdd_EditUser()
        {
            InitializeComponent();
            _UserID = -1;
            _Mode = enMode.eAddNew;
        }
        public frmAdd_EditUser(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
            _Mode = enMode.eUpdate;
        }
        clsUsers User;
        public delegate void TriggerFunctionEventHandler(object sender);
        public event TriggerFunctionEventHandler RelaodContent;
        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.eUpdate)
            {
                User = clsUsers.Find(_UserID);
                ctrlAdd_EditUser1.UserID = _UserID;
                lblAddEdit_Header.Text = "Update User";
                ctrlAdd_EditUser1.__DisplayPersonalInfo(this, User.PersonID);
            }else
            {
                lblAddEdit_Header.Text = "Add New User";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Sure To Complete The Operation", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool IsUpdated=false;
                if (_Mode == enMode.eAddNew)
                {
                    if((_UserID = ctrlAdd_EditUser1.AddNewUser_GetID()) != -1)
                    {
                        lblAddEdit_Header.Text = "Update User";
                        _Mode = enMode.eUpdate;
                    }
                    
                }else
                {
                    User = ctrlAdd_EditUser1.UpdateUser_GetUpdatedInfo(_UserID);
                    IsUpdated =User.Save();
                }

                if (_UserID != -1 ||IsUpdated )
                {
                    RelaodContent?.Invoke(this);
                    MessageBox.Show("Done Succefully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                    MessageBox.Show("Unexpected Error! Operation Fialed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
                MessageBox.Show("Operation Ignored Succefully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Sure to Leave?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
