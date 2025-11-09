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
    public partial class frmContexMenu: Form
    {
        public frmContexMenu()
        {
            InitializeComponent();
        }

        private void tsmFont_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowApply = true;
            fontDialog1.ShowEffects = true;
            fontDialog1.ShowColor = true;
           
          

            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {   
                if(sender is ToolStripMenuItem menuItem)//Ensure the sender is a ToolstripMenuItem
                {   //ToolStipeMenuItem = the Menu Item Was Clecked
                    if(menuItem.Owner is ContextMenuStrip contextMenu)//Checks if the ToolStripMenuItem Inside a ContextMenuStrip. (Owner = The Menu the Container Of Items)
                    {
                        Control TargetControl = contextMenu.SourceControl;//Get the Control taht ContextMenu Was Used On.
                                                                          //(SourceControl= The Control That Opened The Menu(Owner)
                        // Here Ican Do Anything Whith TargetControl. But If I Wont More Spesification see Bellow
                        if(TargetControl is TextBox txtBox)
                        {
                            txtBox.Font = fontDialog1.Font;
                            txtBox.ForeColor = fontDialog1.Color;

                        }
                    }
                }
               
            }
        }
        private void fontDialog1_Apply(object sender, EventArgs e)
        {
           if(sender is ToolStripMenuItem menuItem && menuItem.Owner is ContextMenuStrip contextMenu && contextMenu.SourceControl is TextBox txtBox)
            {
                txtBox.Font = fontDialog1.Font;
                txtBox.ForeColor = fontDialog1.Color;
            }
        }

        private void tsmForeColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if(sender is ToolStripMenuItem menuItem && menuItem.Owner is ContextMenuStrip CMS && CMS.SourceControl is TextBox txtBox)
                {
                    txtBox.ForeColor = colorDialog1.Color;
                }
            }
        }

        private void tsmBackColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK && sender is ToolStripMenuItem menuItem && menuItem.Owner is ContextMenuStrip CMS && CMS.SourceControl is TextBox txtBox)
            {
                txtBox.BackColor = colorDialog1.Color;
            }
               
        }

        private void tsmClear_Click(object sender, EventArgs e)
        {
           if(sender is ToolStripMenuItem MenuItem && MenuItem.Owner is ContextMenuStrip CMS && CMS.SourceControl is TextBox txtBox)
            {
                txtBox.Clear();
            }
        }
    }
}
