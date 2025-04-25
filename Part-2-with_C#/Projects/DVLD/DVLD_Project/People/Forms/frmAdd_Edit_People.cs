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
        int _PersonID;
        enum enMode { eAddNew, eupdate }
        enMode _Mode;
        public frmAdd_Edit_People(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _Mode = enMode.eupdate;
        }
        public frmAdd_Edit_People()
        {
            InitializeComponent();
            _PersonID = -1;
            _Mode = enMode.eAddNew;
        }

        public delegate void TriggerFunction(object sender);
        public event TriggerFunction ReLoadData;

        public delegate void SendPersonID(object sender, int PersonID);
        public event SendPersonID ReturnPersonID;

        private void frmAdd_Edit_People_Load(object sender, EventArgs e)
        {
            _PerformAdd_EditActions();
        }
       

        private void _PerformAdd_EditActions()
        {
            if (_Mode==enMode.eAddNew)
            {
                lblHeader.Text = "Add New Person";
                ctrlAdd_Edit_PersonIfo1.ApplyMode(-1);
                ctrlAdd_Edit_PersonIfo1.ReturnID += SetPersonIDToField;


            }
            else
            {
                lblHeader.Text = "Edit Person";
                ctrlAdd_Edit_PersonIfo1.ApplyMode(_PersonID);
                lblPersonID.Text = _PersonID.ToString();

            }
            ctrlAdd_Edit_PersonIfo1.LeaveForm += LeaveTheForm;
        }
        private void SetPersonIDToField(object sender,int PersonID)
        {
            if (int.TryParse(PersonID.ToString(), out int ID))
            {
                _PersonID = ID;
                ReturnPersonID?.Invoke(this, _PersonID);
                lblPersonID.Text = _PersonID.ToString();

            }
        }
        private void LeaveTheForm(object sender)
        {
            ReLoadData?.Invoke(this);
            this.Close();
        }
        

    }
}
