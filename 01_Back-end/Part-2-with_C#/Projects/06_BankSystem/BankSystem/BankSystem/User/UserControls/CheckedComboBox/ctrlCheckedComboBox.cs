using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace BankSystem.User.UserControls.CheckedComboBox
{
    public partial class ctrlCheckedComboBox : UserControl
    {
        private DropDownForm _dropDown;
        public Action<ulong> __OnValueChanged;
        bool DisplayCombo;
        public ctrlCheckedComboBox()
        {
            InitializeComponent();
            _dropDown = new DropDownForm();
            _dropDown.FormBorderStyle = FormBorderStyle.None;
            _dropDown.TopMost = true;
            _dropDown.ShowInTaskbar = false;

            _dropDown.__OnPermissionChanged += _GetCurrentPermissionValue;

            DisplayCombo = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DisplayCombo = !DisplayCombo;
            if (DisplayCombo)
            {
                var position = this.PointToScreen(new Point(0, this.Height));
                _dropDown.StartPosition = FormStartPosition.Manual;
                _dropDown.Location = position;
                _dropDown.Width = this.Width;
                _dropDown.Show();
                _dropDown.BringToFront();
            }
            else
            {
                _dropDown.Hide();
            }
        }

        public void __LoadPermissions(Dictionary<string, ulong> permissionsList,ulong UserPermission)
        {
           
            _dropDown.__PerformDropDown(permissionsList, UserPermission);

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }
        private void _GetCurrentPermissionValue(ulong permission)
        {
            __OnValueChanged?.Invoke(permission);
        }
    }
}
