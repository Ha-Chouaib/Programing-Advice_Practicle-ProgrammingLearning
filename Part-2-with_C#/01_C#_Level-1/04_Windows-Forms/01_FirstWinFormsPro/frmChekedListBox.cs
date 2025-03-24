using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_FirstWinFormsPro
{
    public partial class frmChekedListBox: Form
    {
        public frmChekedListBox()
        {
            InitializeComponent();
        }

        private void btnAddItems_Click(object sender, EventArgs e)
        {
            for(byte i=1; i<=5; i++)
            {
                checkedListBox1.Items.Add("Item" + i);
            }
        }

        private void btnSowSelectedItems_Click(object sender, EventArgs e)
        {
            for(byte i=0; i<checkedListBox1.CheckedItems.Count; i++)
            {
                MessageBox.Show(checkedListBox1.CheckedItems[i].ToString());
            }
        }

        private void btncheckAllItems_Click(object sender, EventArgs e)
        {
            for(byte i=0; i<checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);//true to Make the Item Checked
            }
        }

        private void btnUnCheckAll_Click(object sender, EventArgs e)
        {
            for (byte i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);// false to Make the Item UnChecked
            }
        }

        private void btnRemoveFirstItem_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.RemoveAt(0); //Remove Item By Index
        }
    }
}
