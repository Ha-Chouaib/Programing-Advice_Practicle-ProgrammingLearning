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
    public partial class frmVsCodeMainForm: Form
    {
        public frmVsCodeMainForm()
        {
            InitializeComponent();
        }

        private Form frmAddNewProject = new frmAddNewProject();

        private void ChangeMenuStripBackForeColor(MenuStrip MenuSt, Color BackC, Color ForeC )
        {
            MenuSt.BackColor = BackC;
            MenuSt.ForeColor = ForeC;
            foreach(ToolStripMenuItem item in MenuSt.Items)
            {  
                 ChangeMenuStItemsColors(item, BackC, ForeC);

            }
        }
        private void ChangeMenuStItemsColors(ToolStripMenuItem menuItem, Color BackC, Color ForeC)
        {
            menuItem.BackColor = BackC;
            menuItem.ForeColor = ForeC;
            menuItem.Owner.BackColor = BackC;

            foreach(ToolStripItem SubItem in menuItem.DropDownItems)
            {
                if (SubItem is ToolStripMenuItem SubMenuItem)
                {
                    ChangeMenuStItemsColors(SubMenuItem, BackC, ForeC);
                }
                else if (SubItem is ToolStripSeparator SubSepItem)
                {
                    SubSepItem.ForeColor = Color.Transparent;

                }
               
                
               
            }
        }
       

        private void frmVsCodeMainForm_Load(object sender, EventArgs e)
        {
            ChangeMenuStripBackForeColor(msTopMenuBar1, Color.FromArgb(47,47,47), Color.Beige);
            //Must Handle the Render Colors  [ Render = The Generator of  UI Tools Like ToolStrip DropDown ...
            
            //Get Back To Change The Render Maring Issue withing a class !!!!!!

            
        }

        private void projectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddNewProject.ShowDialog();
           
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
