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

namespace DVLD_Project.People.User_Ctrl
{
    public partial class ctrlFindAndDisplayPersonDetails : UserControl
    {
        public ctrlFindAndDisplayPersonDetails()
        {
            InitializeComponent();
        }

        private int _PersonID { get; set; }
        public delegate void TriggerFunctionEventHandler(object sender, int PersonID);
        public event TriggerFunctionEventHandler __ReturnPersonID;
        private void ctrlFindPerson_Load(object sender, EventArgs e)
        {
            ctrlFilterPeople1.__GetPersonID += _GetPersonID;

        }
        private void _GetPersonID(object sender, int PersonID)
        {
            _PersonID=PersonID;
            __ReturnPersonID?.Invoke(this, PersonID);
        }

        public void __DisplayPersonalInfo(int PersonID,bool EnabledFilterControl= true)
        {
            ctrlPersonDetails1.__DisplayPersonInfo(PersonID);
            ctrlFilterPeople1.__EnabledFilterControl(EnabledFilterControl);
        }

    }
}
