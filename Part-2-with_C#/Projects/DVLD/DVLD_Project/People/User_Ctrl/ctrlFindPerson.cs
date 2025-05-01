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
    public partial class ctrlFindPerson : UserControl
    {
        public ctrlFindPerson()
        {
            InitializeComponent();
        }

        public int __PersonID { get; set; }
        private void ctrlFindPerson_Load(object sender, EventArgs e)
        {
            ctrlFilterPeople1.__GetPersonID += __DisplayPersonalInfo;

        }

        public void __DisplayPersonalInfo(object sender, int PersonID)
        {
            ctrlPersonDetails1.__DisplayPersonInfo(PersonID);
            this.__PersonID = PersonID;
        }

    }
}
