using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07_Menus
{
    public partial class MDIForm: Form
    {
        public MDIForm()
        {
            InitializeComponent();
        }

        private Form frmCM = new frmContexMenu();
        private void toContextMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCM.MdiParent = this;
            frmCM.Show();
        }
    }
}
