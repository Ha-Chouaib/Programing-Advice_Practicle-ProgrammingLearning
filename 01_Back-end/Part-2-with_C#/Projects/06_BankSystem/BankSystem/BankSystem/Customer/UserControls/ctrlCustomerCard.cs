using Bank_BusinessLayer;
using BankSystem.Person.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Customer.UserControls
{
    public partial class ctrlCustomerCard : UserControl
    {
        public ctrlCustomerCard()
        {
            InitializeComponent();
        }
        clsPerson person = new clsPerson();
       
        public void __DisplayCustomerData(clsCustomer customer)
        {
            if (customer == null)
                return;
            person = clsPerson.Find(customer.PersonID);

            lblCustomerID.Text = $"Customer ID[{customer.CustomerID}]";
            txtNationalNo.Text = person.NationalNo;
            txtOccupation.Text = customer.Occupation ?? "No Occupation Added!";
            txtFirstName.Text = person.FirstName;
            txtLastName.Text = person.LastName;
            txtStatus.Text = customer.IsActive ? "Active" : "InActive";
            txtCreatedDate.Text = customer.CreatedDate.ToString("yyyy-MM-dd");
            switch (customer.CustomerType)
            {
                case clsCustomer.enCustomerType.enIndividual:
                    txtCustomerType.Text = "Individual";
                    break;
                case clsCustomer.enCustomerType.enBusiness:
                    txtCustomerType.Text = "Businees";
                    break;
                case clsCustomer.enCustomerType.enVIP:
                    txtCustomerType.Text = "(VIP)";
                    break;
            }
        }

        private void lnkDisplayPersonalInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (person != null)
            {
                frmShowPersonDetails viewPersonForm = new frmShowPersonDetails(person.PersonID);
                viewPersonForm.ShowDialog();
            }
        }
    }
}
