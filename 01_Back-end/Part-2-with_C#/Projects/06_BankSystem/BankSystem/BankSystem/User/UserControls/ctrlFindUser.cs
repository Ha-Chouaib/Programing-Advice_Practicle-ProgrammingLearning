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

namespace BankSystem.User.UserControls
{
    public partial class ctrlFindUser : UserControl
    {
        public ctrlFindUser()
        {
            InitializeComponent();
            _DefaultSettings();
        }

        public ctrlFind __FindControl { get; set; }
        public Action<clsUser> __ObjectFound;
        
        private void _DefaultSettings()
        {
            ctrlFind1.Enabled = true;
            Dictionary<string, string> FindByoptions = new Dictionary<string, string>
            {
                {"User ID","UserID" },
                {"Person ID","PersonID" },
                {"User Name","UserName" }
            };

            ctrlFind1.__Initializing(FindByoptions, clsUser.FindBy);
            ctrlFind1.__FindOptionsCombo.SelectedValueChanged += (s, e) =>
            {
                ctrlFind1.__txtSearchTerm.KeyPress -= null;

                StringBuilder SelectdColumn = new StringBuilder();
                SelectdColumn.Append(((KeyValuePair<string, string>)ctrlFind1.__FindOptionsCombo.SelectedItem).Value);

                if (SelectdColumn.ToString() != "UserName")
                    ctrlFind1.__txtSearchTerm.KeyPress += (s1, e1) => { e1.Handled = !char.IsControl(e1.KeyChar) && !char.IsDigit(e1.KeyChar); };
                else
                    ctrlFind1.__txtSearchTerm.KeyPress += (s1, e1) => { e1.Handled = false; };
            };
            ctrlFind1.__ObjectFound += (s, user) =>
            {
                ctrlUserCard1.__SetUserDataToCard((clsUser)user);
                __ObjectFound?.Invoke((clsUser)user);
            };

        }
        public void __ShowUserCard(clsUser user)
        {
            if (user == null)
            {
                MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ctrlFind1.__FindOptionsCombo.Text = "User ID";
            ctrlFind1.__txtSearchTerm.Text = user.UserID.ToString();
            ctrlFind1.Enabled = false;

            ctrlUserCard1.__SetUserDataToCard(user);

        }
    }
}
