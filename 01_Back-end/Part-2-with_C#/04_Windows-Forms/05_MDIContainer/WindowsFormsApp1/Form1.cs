using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MDIParent: Form
    {
        public MDIParent()
        {
            InitializeComponent();
        }
        //private Form frmAddChild = new MDIChild();  //To Make Single Form
        private void button1_Click(object sender, EventArgs e)
        {
            Form frmAddChild = new MDIChild();// if You set this line here the btn will Creat Multiple Forms But If Want Just One You Can Take It Above.
            frmAddChild.MdiParent = this;//Important To Force The New Form To Be MDIChild so it will Be InSide  and UnderControl of its Parent.
            frmAddChild.Show();

        }
    }
}
