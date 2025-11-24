using Bank_BusinessLayer;
using BankSystem.Person.Forms;
using BankSystem.Properties;
using DVLD_BusinessLayer;
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
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
            LoadManageRecordsControl();
        }

        public void LoadManageRecordsControl()
        {
            ctrlManageRecords1.__AddNewRecordDelegate += _AddNewPerson;
            ctrlManageRecords1.__UpdateRecordDelegate += _EditPerson;
            ctrlManageRecords1.__CloseFormDelegate += _EndSession;

            ctrlManageRecords1.__HeaderImg.Image = Resources.Team;

            ctrlManageRecords1.__HeaderTitle.Text = "Manage People";
            ctrlManageRecords1.__AddNewBtn.Text = "Add New Person";
            ctrlManageRecords1.__UpdateBtn.Text = "Edit Person";

            ctrlManageRecords1.__Initialize(clsPerson.ListPeopleRecords(), _FilterBy_Options(),clsPerson.FilterPeople ,_ContextMenuPackage(), _FilterByGroups());
            _ConfigureDataRecordsContainer();
        }
        private Dictionary<string,string> _FilterBy_Options()
        {
            Dictionary<string,string> Options = new Dictionary<string, string> 
            {
                {"All","All"},
                {"Person ID","PersonID" },
                {"National No","NationalNo"},
                {"Gender","Gender" },
                {"Full Name","FullName"},
                {"Email","Email" },
                {"Phone Number","Phone"}
            };

            return Options;
        }
        private List<(string ContextMenuKey, Action<int> ContextMenuAction)> _ContextMenuPackage()
        {
            List<(string ContextMenuKey, Action<int> ContextMenuAction)> ContextMenuItems = new List<(string ContextMenuKey, Action<int> ContextMenuAction)>
            {
                ("View Details", _ContextMenuViewPersonDetails),
                ("Edit Person", _ContextMenuEditPerson),
                ("Delete Person", _ContextMenuDeletePerson),                
                ("Send Email", _ContextMenuSendPersonEmail),
                ("Call Person", _ContextMenuCallPerson),
                ("--------------", null),
                ("Convert To User", _ContextMenuConvertToUser),
                ("Convert To Customer", _ContextMenuConvertToCustomer)

            };

            return ContextMenuItems;
        }
        private Dictionary<string, Dictionary<string, string>> _FilterByGroups()
        {
            Dictionary<string, Dictionary<string, string>> FilterOptions = new Dictionary<string, Dictionary<string, string>>
            {
                    {
                        "Gender", new Dictionary<string, string>
                        {
                            { "All", "All" },
                            { "Male", "0" },
                            { "Female", "1" }
                        }
                    } 
            };

            return FilterOptions;
        }
        
        void _ContextMenuViewPersonDetails(int personId)
        {
            frmShowPersonDetails DisplayPersonalInfo = new frmShowPersonDetails(personId);
            DisplayPersonalInfo.ShowDialog();
        }
        void _ContextMenuEditPerson(int personId)
        {
            clsPerson person = clsPerson.Find(personId);
            if(person != null)
            {
                frmEditPerson editPerson = new frmEditPerson( person);
                editPerson.__RefreshContent += ctrlManageRecords1.__RefreshRecordsList;
                editPerson.ShowDialog();
                return;
            }
           MessageBox.Show($"No record founded by id [{personId}] ","warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        void _ContextMenuDeletePerson(int personId)
        {
            if(MessageBox.Show("Sure To delete this record?!","Validation",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsPerson.Delete(personId))
                {
                    MessageBox.Show($"The Person's record With id [{personId}] was deleted successfully");
                    ctrlManageRecords1.__RefreshRecordsList(clsPerson.ListPeopleRecords());
                }
                else MessageBox.Show($"Can't Delete This Record!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void _ContextMenuSendPersonEmail(int personId)
        {
            MessageBox.Show($"Send Email To Person with id [{personId}] -> Not Implemented yet");
        }
        void _ContextMenuCallPerson(int personId)
        {
            MessageBox.Show($"call the  Person with id [{personId}] -> Not Implemented yet");
        }
        void _ContextMenuConvertToUser(int personId)
        {
            MessageBox.Show($"Convert Person with id [{personId}] To User -> Not Implemented yet");
        }
        void _ContextMenuConvertToCustomer(int personId)
        {
            MessageBox.Show($"Convert Person with id [{personId}] To Customer -> Not Implemented yet");
        }

        private void _EndSession()
        {
            this.Close();
        }
        private void _AddNewPerson()
        {
            frmAddNewPerson addNewPerson = new frmAddNewPerson();
            addNewPerson.__RefreshContent+= ctrlManageRecords1.__RefreshRecordsList;
            addNewPerson.ShowDialog();
        }
        private void _EditPerson()
        {
            frmEditPerson editPerson = new frmEditPerson();
            editPerson.__RefreshContent += ctrlManageRecords1.__RefreshRecordsList;
            editPerson.ShowDialog();
        }
        private void _ConfigureDataRecordsContainer()
        {
            ctrlManageRecords1.__RecordsContainer.Columns["PersonID"].HeaderText = "ID";
            ctrlManageRecords1.__RecordsContainer.Columns["NationalNo"].HeaderText = "National_No";
            ctrlManageRecords1.__RecordsContainer.Columns["FirstName"].HeaderText = "First Name";
            ctrlManageRecords1.__RecordsContainer.Columns["LastName"].HeaderText = "Last Name";
            ctrlManageRecords1.__RecordsContainer.Columns["DateOfBirth"].HeaderText = "Date Of Birth";
            ctrlManageRecords1.__RecordsContainer.Columns["CountryID"].HeaderText = "Country";
            ctrlManageRecords1.__RecordsContainer.Columns["ImagePath"].HeaderText = "Profile Image";


            ctrlManageRecords1.__RecordsContainer.CellFormatting += (s, e) =>
            {
                if (ctrlManageRecords1.__RecordsContainer.Columns[e.ColumnIndex].Name == "Gender" && e.Value is byte Gdr)
                {
                    e.Value = Gdr == 0 ? "Male" : "Female";
                    e.FormattingApplied = true;
                }
                if (ctrlManageRecords1.__RecordsContainer.Columns[e.ColumnIndex].Name == "CountryID" && e.Value is int id)
                {
                    e.Value = clsCountries.Find(id).CountryName;
                    e.FormattingApplied = true;
                }
            };
        }
    }
}
