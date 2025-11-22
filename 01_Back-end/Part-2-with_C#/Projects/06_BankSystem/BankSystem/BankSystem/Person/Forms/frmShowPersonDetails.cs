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
                ctrlDisplayPersonDetails1.__ShowPersonalInfo(person);
        }
        clsPerson person {  get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
