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
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
            LoadManageRecordsControl();
        }

        public void LoadManageRecordsControl()
        {
            ctrlManageRecords1.__Initialize(clsPerson.ListPeopleRecords(), _FilterBy_Options(),clsPerson.FilterPeople ,_ContextMenuPackage(), _FilterByGroups());
        }
        private Dictionary<string,string> _FilterBy_Options()
        {
            Dictionary<string,string> Options = new Dictionary<string, string> 
            {
                {"All","All"},
                {"Person ID","PersonID" },
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
                ("-", null),
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
            // TODO: Implement viewing full person details
        }

        void EditPerson(int personId)
        {
            // TODO: Implement edit person form opening
        }

        void DeletePerson(int personId)
        {
            // TODO: Implement delete logic + confirmation
        }
        void SendPersonEmail(int personId)
        {
            // TODO: Implement email sending dialog
        }
        void CallPerson(int personId)
        {
            
        }
        void ConvertToUser(int personId)
        {

        }
        void ConvertToCustomer(int personId)
        {

        }


    }
}
