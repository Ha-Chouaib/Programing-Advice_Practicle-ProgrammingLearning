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

        private clsPeople _Person;
        private int _PersonID = -1;

        public int __PersonID { get { return _PersonID; } set { _PersonID = value; } }
        public clsPeople __PersonRecord { get { return _Person; } }
        public bool __EnableFilter { get { return ctrlFilterPeople1.__EnableFilter; } set { ctrlFilterPeople1.__EnableFilter = value; } }

        public delegate void TriggerFunctionEventHandler(object sender, int PersonID);
        public event TriggerFunctionEventHandler __ReturnPersonID;
        private void ctrlFindPerson_Load(object sender, EventArgs e)
        {
            ctrlFilterPeople1.__GetPersonID += _GetPersonID;

        }
        private void _GetPersonID(object sender, int PersonID)
        {
            _PersonID=PersonID;
            _Person = ctrlFilterPeople1.__PersonInf;
            __ReturnPersonID?.Invoke(this, PersonID);
        }

        public void __DisplayPersonalInfo(int PersonID)
        {
            ctrlPersonDetails1.__DisplayPersonInfo(PersonID);
        }

    }
}
