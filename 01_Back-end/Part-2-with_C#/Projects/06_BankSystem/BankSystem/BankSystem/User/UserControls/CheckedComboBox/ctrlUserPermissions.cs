using Bank_BusinessLayer;
using BankSystem.Properties;
using System;
using System.Collections;
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
    public partial class ctrlUserPermissions : UserControl
    {
        public ctrlUserPermissions()
        {
            InitializeComponent();
            _expandedHeight = flowLayoutPanel1.Height; 
            flowLayoutPanel1.Height = 0;

            this.Height = pnlMainBtn.Height;
        }

        private int _expandedHeight;
        public Action<ulong> __PermissionsChanged;
        public void LoadPermissions(Dictionary<string, ulong> Permissions,ulong userPermissions)
        {
           flowLayoutPanel1.Controls.Clear();

            foreach (var perm in Permissions)
           {
                CheckBox chk = new CheckBox
                {
                    Text = perm.Key.Replace("_"," "),
                    Tag = perm.Value,
                    AutoSize = true,
                    ForeColor = Color.White,
                    Checked = (userPermissions & perm.Value) == perm.Value

                    
                };
                chk.CheckedChanged += (s, e) =>
                {
                    if (chk.Checked)
                    {
                        
                        userPermissions |= (ulong)chk.Tag;
                        __PermissionsChanged?.Invoke(userPermissions);
                    }
                    else
                    {
                        
                        userPermissions &= ~(ulong)chk.Tag;
                        __PermissionsChanged?.Invoke(userPermissions);
                    }
                };
                flowLayoutPanel1.Controls.Add(chk);
           }

        }
       
        private void _Toggle()
        {
            if (flowLayoutPanel1.Height == 0)
            {
                // EXPAND
                flowLayoutPanel1.Height = _expandedHeight;
                pictureBox1.Image = Resources.up;
                this.Height = pnlMainBtn.Height + flowLayoutPanel1.Height;
            }
            else
            {
                // COLLAPSE
                flowLayoutPanel1.Height = 0;
                pictureBox1.Image = Resources.down;
                this.Height = pnlMainBtn.Height;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            _Toggle();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }


       
    }
}
