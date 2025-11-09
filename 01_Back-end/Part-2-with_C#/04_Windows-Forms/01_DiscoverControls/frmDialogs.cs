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
    public partial class frmDialogs: Form
    {
        public frmDialogs()
        {
            InitializeComponent();
        }

        private void btnChangeBackColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                txtChangeMyFont.BackColor = colorDialog1.Color;
        }

        private void btnChangeForeColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                txtChangeMyFont.ForeColor = colorDialog1.Color;
        }

        private void btnChageFont_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowApply= true;
            fontDialog1.ShowColor = true;
            fontDialog1.ShowEffects = true;

            fontDialog1.Font = txtChangeMyFont.Font;//To Set or Custem The Default Font
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                txtChangeMyFont.Font = fontDialog1.Font;
                txtChangeMyFont.ForeColor = fontDialog1.Color;
            }
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            txtChangeMyFont.Font = fontDialog1.Font;
            txtChangeMyFont.ForeColor = fontDialog1.Color;
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = @"C:\";//to custum the default Directory will be shown first while the dialog start [ @"C:\" ] Means C drive . You Can Choose Any
            saveFileDialog1.Title = "Set Dialog Title";
            saveFileDialog1.DefaultExt = ".txt"; // the default file extenction will be  .txt and you can Choose any Other Format .jpeg .css ...
            saveFileDialog1.Filter = "txt File (*.txt) = <Title you Can Choose Any> |*.txt|All Files(*.*) =<Other Option Title>|*.*";
            saveFileDialog1.FilterIndex = 1;//the Default Filtring Format .txt or *.* ...

            if(saveFileDialog1.ShowDialog() ==DialogResult.OK)
            {
                MessageBox.Show(saveFileDialog1.FileName);
            }
        }

        private void btnOpenFileDialog_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";//Default Directotory Must Display First.
            openFileDialog1.Title = "Set a Title";
            openFileDialog1.DefaultExt = ".txt";//the Default Files Format Will Be Shown To You
            openFileDialog1.Filter = "Just Txt Files (*.txt)| *.txt|See All File Types(*.*)|*.*";//To Change The Default Format To Your Option. You Can Add Any Other Format
            openFileDialog1.FilterIndex = 2;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                MessageBox.Show(openFileDialog1.FileName);//will SHow the File Path Then You Can Do What You Want With it.
        }

        private void btnOpenFileMultiSelect_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;// Select More than File
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                foreach(String file in openFileDialog1.FileNames)
                {
                    MessageBox.Show(file);
                }
            }

        }

        private void btnFoldrBrowser_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = true;//    Allows You To Make New Folder
            if(folderBrowserDialog1.ShowDialog()== DialogResult.OK)
            {
                MessageBox.Show(folderBrowserDialog1.SelectedPath);
            }
        }
    }
}
