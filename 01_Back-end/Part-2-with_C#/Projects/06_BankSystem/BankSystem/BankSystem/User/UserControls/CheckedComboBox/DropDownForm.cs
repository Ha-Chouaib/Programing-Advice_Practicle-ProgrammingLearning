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
    public partial class DropDownForm : Form
    {
        public DropDownForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;

            Deactivate += (s, e) => Hide();
        }

        public Action<ulong> __OnPermissionChanged;
        public void __PerformDropDown(Dictionary<string, ulong> permissions, ulong UserPermissions)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var permission in permissions)
            {
                CheckBox check = new CheckBox
                {
                    Text = permission.Key.Replace("-", " "),
                    Tag = permission.Value,
                    Checked = (UserPermissions & permission.Value) == permission.Value,
                    ForeColor = Color.White,
                    AutoSize = true

                };
                check.CheckedChanged += (s, e) => 
                {
                    if(check.Checked)
                        __OnPermissionChanged.Invoke(UserPermissions |= (ulong)check.Tag);
                    else
                        __OnPermissionChanged.Invoke(UserPermissions &= ~(ulong)check.Tag);
                };
                flowLayoutPanel1.Controls.Add(check);
            }
        }
    }
}
