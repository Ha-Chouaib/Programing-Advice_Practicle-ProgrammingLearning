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
    public partial class ctrlMenuBtn : UserControl
    {
        public ctrlMenuBtn()
        {
            InitializeComponent();
            HoverBackColor = Color.FromArgb(48, 150, 241);
            HoverForeColor = Color.White;
            //this.AutoSize = true;
            //this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //this.Dock = DockStyle.None; // Important for FlowLayoutPanel
            //this.Margin = new Padding(0, 5, 0, 0);
            //this.Padding = new Padding(0);

        }

        public string Title
        {
            get { return button1.Text; }
            set { button1.Text = value; }
        }

        public string Key { get; set; }
        public Image Icon { get { return pbIcon.Image; } set { pbIcon.Image = value; } }

        public Color BtnBackColor
        {
            get { return button1.BackColor; }
            set { button1.BackColor = value; }
        }
        public Color BtnForeColor
            { get { return button1.ForeColor; } set { button1.ForeColor = value; } }

        public Color HoverBackColor { get; set; }
        public Color HoverForeColor { get; set; }

        private Color _OriginalBackColor {  get; set; }
        private Color _OriginalForeColor {  get; set; }

        public event EventHandler<clsMenuBtnModel> MenuBtnClicked;

        public void UpdateStyle(Color btnBackColor, Color btnForeColor, Color HoverBackColor, Color HoverForeColor)
        {
            BtnBackColor = btnBackColor;
            BtnForeColor = btnForeColor;
            this.HoverBackColor = HoverBackColor;
            this.HoverForeColor = HoverForeColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuBtnClicked?.Invoke(this, new clsMenuBtnModel(Title, Key));
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            _OriginalBackColor = button1.BackColor;
            _OriginalForeColor = button1.ForeColor;

            button1.BackColor = HoverBackColor.IsEmpty ? Color.FromArgb(48, 150, 241) : HoverBackColor;

            button1.ForeColor = HoverForeColor.IsEmpty ? Color.White : HoverForeColor;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = _OriginalBackColor;
            button1.ForeColor= _OriginalForeColor;
        }
    }
}
