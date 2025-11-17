using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.SideBarMenu
{
    public class clsMenuBtnModel
    {

        public clsMenuBtnModel() { }
        public clsMenuBtnModel(string title, string key)
        {
            Title = title;
            Key = key;
        }

        public string Title
        {
            get; set;
        }
        public string Key { get; set; }
        public Image Icon { get; set; }
        public Color BtnBackColor
        {
            get; set;
        }
        public Color BtnForeColor
        { get; set; }

        public Color HoverBackColor { get; set; }
        public Color HoverForeColor { get; set; }

        public List<clsMenuBtnModel> SubItems = new List<clsMenuBtnModel>();
        public bool IsGroup => SubItems.Count > 0;

        public void UpdateStyle(Color btnBackColor, Color btnForeColor,Color HoverBackColor, Color HoverForeColor)
        {
            BtnBackColor= btnBackColor;
            BtnForeColor= btnForeColor;
            this.HoverBackColor = HoverBackColor;
            this.HoverForeColor = HoverForeColor;
        }
    }
}