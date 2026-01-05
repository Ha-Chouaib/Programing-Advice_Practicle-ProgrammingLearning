using Bank_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Person.Forms
{
    public partial class frmShowPersonDetails : Form
    {
        public frmShowPersonDetails()
        {
            InitializeComponent();
        }
        public frmShowPersonDetails(int PersonID)
        {
            InitializeComponent();

            person = clsPerson.Find(PersonID);
          if ( person != null)
            {
                ctrlDisplayPersonDetails1.__ShowPersonalInfo(person);
                ctrlDisplayPersonDetails1.__UpdatedPersonRecord += _GetUpdatedPersonRecord;
            }
        }
        clsPerson person {  get; set; }
        public Action<clsPerson> __PersonRecordChanged;
        
        private void _GetUpdatedPersonRecord(clsPerson updatedPerson)
        {
            person = updatedPerson;
            __PersonRecordChanged?.Invoke(updatedPerson);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
