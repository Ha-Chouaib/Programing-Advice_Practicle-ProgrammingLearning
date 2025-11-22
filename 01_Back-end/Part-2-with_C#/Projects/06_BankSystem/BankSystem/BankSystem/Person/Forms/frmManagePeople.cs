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
            ctrlManageRecords1.__CloseFormDelegate += _EndSession;
            ctrlManageRecords1.__Initialize(clsPerson.ListPeopleRecords(), _FilterBy_Options(),clsPerson.FilterPeople ,_ContextMenuPackage(), _FilterByGroups());
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
                ("View Details", ViewPersonDetails),
                ("Edit Person", EditPerson),
                ("Delete Person", DeletePerson),                
                ("Send Email", SendPersonEmail),
                ("Call Person", CallPerson),
                ("--------------", null),
                ("Convert To User", ConvertToUser),
                ("Convert To Customer", ConvertToCustomer)

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
        
        void ViewPersonDetails(int personId)
        {
            frmShowPersonDetails DisplayPersonalInfo = new frmShowPersonDetails(personId);
            DisplayPersonalInfo.ShowDialog();
        }

        void EditPerson(int personId)
        {
            clsPerson person = clsPerson.Find(personId);
            if(person != null)
            {
                frmEditPerson editPerson = new frmEditPerson( person);
                editPerson.ShowDialog();
                return;
            }
           MessageBox.Show($"No record founded by id [{personId}] ","warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        void DeletePerson(int personId)
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
        void SendPersonEmail(int personId)
        {
            MessageBox.Show($"Send Email To Person with id [{personId}] -> Not Implemented yet");
        }
        void CallPerson(int personId)
        {
            MessageBox.Show($"call the  Person with id [{personId}] -> Not Implemented yet");
        }
        void ConvertToUser(int personId)
        {
            MessageBox.Show($"Convert Person with id [{personId}] To User -> Not Implemented yet");
        }
        void ConvertToCustomer(int personId)
        {
            MessageBox.Show($"Convert Person with id [{personId}] To Customer -> Not Implemented yet");
        }

        private void _EndSession()
        {
            this.Close();
        }

    }
}
