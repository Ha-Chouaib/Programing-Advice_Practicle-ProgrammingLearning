using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSCodeCommunity2022Clone
{
    public partial class frmAddNewProject: Form
    {
        public frmAddNewProject()
        {
            InitializeComponent();
        }

        private void frmAddNewProject_Load(object sender, EventArgs e)
        {
            cbLangs.SelectedIndex = 0;
            cbOSType.SelectedIndex = 0;
            cbAppType.SelectedIndex = 0;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void plSetRecentTmp_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
