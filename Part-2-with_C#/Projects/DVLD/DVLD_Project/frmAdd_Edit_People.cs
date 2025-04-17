using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmAdd_Edit_People: Form
    {
        
        public frmAdd_Edit_People(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
        public frmAdd_Edit_People()
        {
            InitializeComponent();
            _PersonID = -1;
        }

        public delegate void TriggerFunction(object sender);
        public event TriggerFunction ReLoadPeopleList;
            

        private void frmAdd_Edit_People_Load(object sender, EventArgs e)
        {
            _PerformAdd_EditActions();
        }
        int _PersonID;
        enum enMode { eAddNew,eupdate}
        enMode _Mode;

        private void _PerformAdd_EditActions()
        {
            if (_PersonID == -1)
            {
                lblHeader.Text = "Add New Person";
                ctrlAdd_Edit_PersonIfo1.ReturnID += SetPersonIDToField;
                ctrlAdd_Edit_PersonIfo1.LeaveForm += LeaveTheForm;

            }
            else
            {
                lblHeader.Text = "Edit Person";
            }
            ReLoadPeopleList?.Invoke(this);
        }
        private void SetPersonIDToField(object sender,int PersonID)
        {
            if (int.TryParse(PersonID.ToString(), out int ID))
                lblPersonID.Text = ID.ToString();
        }
        private void LeaveTheForm(object sender)
        {
            this.Close();
        }
        

    }
}
