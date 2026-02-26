using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.SystemSettings.Controls
{
    public partial class ctrlCustomBtn : UserControl
    {
        public ctrlCustomBtn()
        {
            InitializeComponent();
        }

        public string __BtnText
        {
            get { return lblBtnTitle.Text; }
            set { lblBtnTitle.Text = value; }
        }
        public Image __BtnImage
        {
            get { return pbBtnImg.Image; }
            set { pbBtnImg.Image = value; }
        }
        public Color __BtnBackColor
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }
        public Color __BtnForeColor
        {
            get { return lblBtnTitle.ForeColor; }
            set { lblBtnTitle.ForeColor = value; }
        }
        public Action __BtnClickAction { get; set; }
        public Color __BtnBackColorColor { get; set; } = Color.FromArgb(19, 22, 29);
        public Color __BtnForeColorColor { get; set; } = Color.FromArgb(156, 163, 175);
        public Color __HoverBackColor { get; set; } = Color.FromArgb(47, 128, 237);
        public Color __HoverForColor { get; set; } = Color.FromArgb(86, 204, 242);
        

        private void pnlBtnContainer_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
             __BtnClickAction?.Invoke();
        }

        private void pnlBtnContainer_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = __HoverBackColor;
            lblBtnTitle.ForeColor = __HoverForColor;
        }

        private void pnlBtnContainer_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = __BtnBackColorColor;
            lblBtnTitle.ForeColor = __BtnForeColorColor;
        }
    }
}
