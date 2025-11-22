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

namespace BankSystem.Person
{
    public partial class frmEditPerson : Form
    {
        public frmEditPerson()
        {
            InitializeComponent();
            _LoadFindControl();
        }
        public Action<clsPerson> __GetUpdatedPersonRecord;
        public frmEditPerson(clsPerson person)
        {
            InitializeComponent();
            _Person = person;

            _Initializing();

        }

        clsPerson _Person;

        private void _Initializing()
        {
            ctrlFind1.SearchBarContainer.Enabled = false;
            ctrlFind1.txtSearchTerm.Text = _Person.PersonID.ToString();
            ctrlFind1.FindOptions.Text = "Person ID";
            ctrlAddEditPerson1.OnOperationCanceled += _LeaveForm;
            _EditPerson( _Person );
        }
        private void _GetUpdatedRecord(object s,clsPerson person)
        {
            if (person != null)
            {
                _Person = person;
                __GetUpdatedPersonRecord?.Invoke( _Person );
                MessageBox.Show("Operation done Successfully");
                return;
            }
            MessageBox.Show("The System Can't Complete The Operation! Please Go To [Event Viewer] To See The Problem.");

        }
        private void _LeaveForm(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to Leave", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        
        private void _EditPerson(clsPerson person)
        {
            ctrlAddEditPerson1.UpdatePerson(person);
            ctrlAddEditPerson1.OnPersonAdded_Updated += _GetUpdatedRecord;
        }
        
        private void _GetRecordToUpdate(object s,object obj)
        {
            var p = obj as clsPerson;
           _EditPerson( p );
        }
        private Dictionary<string,string> _SetFindByOptions()
        {
            Dictionary<string,string> options = new Dictionary<string, string> 
            {
                {"Person ID","PersonID" },
                {"National No","NationalNo" }
            };
            return options;
        }        
        private void _LoadFindControl()
        {
            ctrlFind1.__Initializing(_SetFindByOptions(), clsPerson.FindBy);
            ctrlFind1.__ObjectFound += _GetRecordToUpdate;
            ctrlAddEditPerson1.__HeadingTitle.Text = "Edit Person Info";
            ctrlAddEditPerson1.OnOperationCanceled += _LeaveForm;
        }


    }
}
