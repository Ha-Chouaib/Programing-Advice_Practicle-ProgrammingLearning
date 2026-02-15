using Bank_BusinessLayer;
using BankSystem.Customer.Forms;
using BankSystem.Person.Forms;
using BankSystem.Properties;
using BankSystem.User.Forms;
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

            ctrlManageRecords1.__AddNewBtn.Text = "Add New Person";
            ctrlManageRecords1.__UpdateBtn.Text = "Edit Person";

            ctrlManageRecords1.__Initialize(_FilterBy_Options(), clsPerson.FilterPeople, _ContextMenuPackage(), _FilterByGroups());
            _ConfigureDataRecordsContainer();
        }
        private Dictionary<string,string> _FilterBy_Options()
        {
            return clsUtil_BL.ManagerRcordsHelper.FilterBy_Options(typeof(clsPerson.Filter_Mapping));

        }
        private Dictionary<string, Dictionary<string, string>> _FilterByGroups()
        {
            return clsUtil_BL.ManagerRcordsHelper.FilterBy_Groups(typeof(clsPerson.Filter_ByGroupsMapping));
        }

        private List<(string ContextMenuKey, Action<int,ToolStripMenuItem> ContextMenuAction)> _ContextMenuPackage()
        {
            List<(string ContextMenuKey, Action<int, ToolStripMenuItem> ContextMenuAction)> ContextMenuItems = new List<(string ContextMenuKey, Action<int, ToolStripMenuItem> ContextMenuAction)>
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
        
        void _ContextMenuViewPersonDetails(int personId, ToolStripMenuItem menuItem)
        {
            frmShowPersonDetails DisplayPersonalInfo = new frmShowPersonDetails(personId);
            DisplayPersonalInfo.ShowDialog();
        }
        void _ContextMenuEditPerson(int personId, ToolStripMenuItem menuItem)
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
        void _ContextMenuDeletePerson(int personId, ToolStripMenuItem menuItem)
        {
            if(MessageBox.Show("Sure To delete this record?!","Validation",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsPerson.Delete(personId, clsUtil_PL.LoggedInUser.UserID))
                {
                    MessageBox.Show($"The Person's record With id [{personId}] was deleted successfully");
                    ctrlManageRecords1.__RefreshRecordsList();
                }
                else MessageBox.Show($"Can't Delete This Record!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void _ContextMenuSendPersonEmail(int personId, ToolStripMenuItem menuItem)
        {
            MessageBox.Show($"Send Email To Person with id [{personId}] -> Not Implemented yet");
        }
        void _ContextMenuCallPerson(int personId, ToolStripMenuItem menuItem)
        {
            MessageBox.Show($"call the  Person with id [{personId}] -> Not Implemented yet");
        }
        void _ContextMenuConvertToUser(int personId, ToolStripMenuItem menuItem)
        {
            if(clsUser.ExistByPersonID(personId))
            {
                MessageBox.Show("This Person Is Already Declared as a User!","warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                menuItem.Enabled = false;
                return;
            }
            menuItem.Enabled = true;
            frmAddNewUser toUser = new frmAddNewUser(personId);
            toUser.ShowDialog();
        }
        void _ContextMenuConvertToCustomer(int personId, ToolStripMenuItem menuItem)
        {
            if(clsCustomer.IsCustomerExistsByPersonID(personId))
            {
                MessageBox.Show("This Person Is Already Declared as a customer!", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                menuItem.Enabled = false;
                return;
            }
            menuItem.Enabled = true;

            frmAddNewCustomer convertToCustomer = new frmAddNewCustomer(personId);
            convertToCustomer.ShowDialog();

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
            if (ctrlManageRecords1.__RecordsContainer.RowCount == 0) return;
            ctrlManageRecords1.__RecordsContainer.Columns["NationalNo"].HeaderText = "National_No";
            ctrlManageRecords1.__RecordsContainer.Columns["FirstName"].HeaderText = "First Name";
            ctrlManageRecords1.__RecordsContainer.Columns["LastName"].HeaderText = "Last Name";
            ctrlManageRecords1.__RecordsContainer.Columns["DateOfBirth"].HeaderText = "Date Of Birth";
            ctrlManageRecords1.__RecordsContainer.Columns["CountryName"].HeaderText = "Country Name";
            ctrlManageRecords1.__RecordsContainer.Columns["ImagePath"].HeaderText = "Profile Image";


            ctrlManageRecords1.__RecordsContainer.CellFormatting += (s, e) =>
            {
                if (ctrlManageRecords1.__RecordsContainer.Columns[e.ColumnIndex].Name == "Gender" && e.Value is byte Gdr)
                {
                    e.Value = Gdr == 0 ? "Male" : "Female";
                    e.FormattingApplied = true;
                }

            };
        }

        
    }
}
