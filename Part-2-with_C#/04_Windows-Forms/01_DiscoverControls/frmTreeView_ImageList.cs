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
    public partial class frmTreeView_ImageList: Form
    {
        public frmTreeView_ImageList()
        {
            InitializeComponent();
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(treeView1.SelectedNode.Text);
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckTreeViewNode(e.Node, e.Node.Checked);
        }
        private void CheckTreeViewNode(TreeNode node, Boolean isCheCked)
        {
            //To Check Or Uncheck the Nodes Children 
            foreach(TreeNode Item in node.Nodes)
            {
                Item.Checked = isCheCked;
                if(Item.Nodes.Count > 0)
                {
                    this.CheckTreeViewNode(Item,isCheCked);
                }
            }
        }

        private void frmTreeView_ImageList_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Add("ckoko");
        }
    }
}
