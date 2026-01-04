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
    public partial class frmFindPerson : Form
    {
        public frmFindPerson()
        {
            InitializeComponent();
            Find_Display();
        }

        private void Find_Display()
        {
            ctrlFind1.__Initializing(_SetFindByOptions(),clsPerson.FindBy);
            ctrlFind1.__FindOptionsCombo.SelectedValueChanged += (s, e) =>
            {
                ctrlFind1.__txtSearchTerm.KeyPress -= null;
                if (((KeyValuePair<int, string>)ctrlFind1.__FindOptionsCombo.SelectedItem).Value == "PersonID")
                    ctrlFind1.__txtSearchTerm.KeyPress += (s1, e1) => { e1.Handled = !char.IsControl(e1.KeyChar) && !char.IsDigit(e1.KeyChar); };
                else
                    ctrlFind1.__txtSearchTerm.KeyPress += (s1, e1) => { e1.Handled = false; };
            };
            ctrlFind1.__ObjectFound+= DisplayPersonInfo;

        }
        private void DisplayPersonInfo(object s,object obj)
        {
            ctrlDisplayPersonDetails1.__ShowPersonalInfo(obj as clsPerson);
        }
        private Dictionary<string, string> _SetFindByOptions()
        {
            Dictionary<string, string> options = new Dictionary<string, string>
            {
                {"Person ID","PersonID" },
                {"National No","NationalNo" }
            };
            return options;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
