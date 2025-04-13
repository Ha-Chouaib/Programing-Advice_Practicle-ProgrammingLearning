using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_Project
{
    public partial class frmManagePeople: Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            LoadPeople();
        }

        private void LoadPeople()
        {
            DataTable dtPeople = clsPeople.ListAll();
            dgvLsitPeople.DataSource = dtPeople;
        }
    }
}
