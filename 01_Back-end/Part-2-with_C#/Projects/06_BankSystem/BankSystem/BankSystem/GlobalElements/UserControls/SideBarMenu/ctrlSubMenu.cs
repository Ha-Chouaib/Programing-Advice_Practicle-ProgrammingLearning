using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.SideBarMenu
{
    public partial class ctrlSubMenu : UserControl
    {
        public ctrlSubMenu()
        {
            InitializeComponent();

            pnlSubContainer.Visible = false;
           

            HoverBackColor = Color.FromArgb(48, 150, 241);
            HoverForeColor = Color.White;

            pnlMainBtn.Dock = DockStyle.Top;
            pnlMainBtn.Height = 50;

            // --- Whole ctrlSubMenu
            this.AutoSize = false;
            this.Margin = Padding.Empty;
            this.Padding = Padding.Empty;
            this.BackColor = Color.Transparent;

            pnlSubContainer.Margin = Padding.Empty;
            pnlSubContainer.AutoScroll = false;
            pnlSubContainer.Padding = Padding.Empty;
        }


        public string GroupTitle
        {
            get { return btnMain.Text; }
            set { btnMain.Text = value; }
        }

        public string GroupKey { get; set; }
        public Image Icon { get { return pbIcon.Image; } set { pbIcon.Image = value; } }
        public Image ArrowIcon { get { return pbArrow.Image; } set { pbArrow.Image = value; } }
        public Color BtnBackColor
        {
            get { return pnlMainBtn.BackColor; }
            set { pnlMainBtn.BackColor = value; }
        }
        public Color BtnForeColor
        { get { return btnMain.ForeColor; } set { btnMain.ForeColor = value; } }

        public Color HoverBackColor { get; set; }
        public Color HoverForeColor { get; set; }

        private Color _OriginalBackColor { get; set; }
        private Color _OriginalForeColor { get; set; }

        public Panel SubContainer => pnlSubContainer;
        public Panel MainBtnContainer => pnlMainBtn;
        public void UpdateStyle(Color btnBackColor, Color btnForeColor, Color HoverBackColor, Color HoverForeColor)
        {
            BtnBackColor = btnBackColor;
            BtnForeColor = btnForeColor;
            this.HoverBackColor = HoverBackColor;
            this.HoverForeColor = HoverForeColor;
        }

        public event EventHandler<clsMenuBtnModel> SubMenuClicked;
        public event EventHandler<ctrlSubMenu> MainBtnClicked;
        public void AddSubItem(ctrlMenuBtn btn)
        {

            btn.MenuBtnClicked += (s, k) => SubMenuClicked?.Invoke(this, k);
            btn.Margin = new Padding(0, 1, 0, 1);

            pnlSubContainer.Controls.Add(btn);
            pnlSubContainer.Controls.SetChildIndex(btn, 0);
            if (pnlSubContainer.Visible)
            {
                this.Height = pnlMainBtn.Height + pnlSubContainer.PreferredSize.Height;
            }
        }

       
        private void btnMain_Click(object sender, EventArgs e)
        {
            MainBtnClicked?.Invoke(sender, this);

        }
       
        private void btnMain_MouseEnter(object sender, EventArgs e)
        {

            _OriginalBackColor = pnlMainBtn.BackColor;
            _OriginalForeColor = btnMain.ForeColor;

            btnMain.BackColor = HoverBackColor.IsEmpty ? Color.FromArgb(48, 150, 241) : HoverBackColor;

            btnMain.ForeColor = HoverForeColor.IsEmpty ? Color.White : HoverForeColor;
        }

        private void btnMain_MouseLeave(object sender, EventArgs e)
        {
            btnMain.BackColor = _OriginalBackColor;
            btnMain.ForeColor = _OriginalForeColor;
        }

        private void pbArrow_Click(object sender, EventArgs e)
        {
            btnMain_Click(sender, e);
        }

        private void ctrlSubMenu_Load(object sender, EventArgs e)
        {

        }
    }

}
