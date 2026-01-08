using BankSystem.Properties;
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
    public partial class ctrlSideBarMenu : UserControl
    {
        public ctrlSideBarMenu()
        {
            InitializeComponent();

            fpnlSideBarContainer.AutoSize = false;
            fpnlSideBarContainer.WrapContents = false;
            fpnlSideBarContainer.Padding = new Padding(10,5,0,0);
            fpnlSideBarContainer.Margin = new Padding(0);
            fpnlSideBarContainer.FlowDirection = FlowDirection.TopDown;
            fpnlSideBarContainer.Dock = DockStyle.Fill;
            fpnlSideBarContainer.Left = (this.ClientSize.Width - fpnlSideBarContainer.Width) / 2;

            fpnlSideBarContainer.BackColor = Color.FromArgb(15, 23, 42); 

        }

        public event EventHandler<clsMenuBtnModel> SideBarItemClicked;
        private ctrlSubMenu ClickedSubMenu;

        public Color MenuBackColor { get { return this.BackColor; } set { this.BackColor = value; } }
        public void BuildSideBarMenu(List<clsMenuBtnModel> menu)
        {
            fpnlSideBarContainer.Controls.Clear();          
            BuildMenuRecursive(fpnlSideBarContainer, menu);
        }
        private void BuildMenuRecursive(Control parent, List<clsMenuBtnModel> items)
        {
            foreach (var item in items)
            {
                if (item.IsGroup)
                {
                    var group = new ctrlSubMenu
                    {
                        GroupTitle = item.Title,
                        Icon = item.Icon,

                    };
                   
                    group.MainBtnClicked += _ToggleSubMenu;

                    group.UpdateStyle(
                        item.BtnBackColor.IsEmpty ? Color.FromArgb(30, 41, 59) : item.BtnBackColor,        
                        item.BtnForeColor.IsEmpty ? Color.FromArgb(226, 232, 240) : item.BtnForeColor,    
                        item.HoverBackColor.IsEmpty ? Color.FromArgb(37, 99, 235) : item.HoverBackColor,  
                        item.HoverForeColor.IsEmpty ? Color.White : item.HoverForeColor
                    );


                    if (item.SubItems != null && item.SubItems.Any())
                        BuildMenuRecursive(group.SubContainer, item.SubItems);

                    group.Margin = new Padding(5,0,0,10);
                    parent.Controls.Add(group);
                   
                }
                else
                {
                    var btn = new ctrlMenuBtn
                    {
                        Title = item.Title,
                        Key = item.Key,
                        Icon = item.Icon,
                        AutoSize = true,
                        AutoSizeMode = AutoSizeMode.GrowAndShrink,
                        Margin = Padding.Empty   ,
                        Height = 35,
                        Width = fpnlSideBarContainer.Width,

                    };

                    if (parent is ctrlSubMenu subMenu)
                    {
                        btn.UpdateStyle(
                            item.BtnBackColor.IsEmpty ? Color.FromArgb(51, 65, 85) : item.BtnBackColor,       
                            item.BtnForeColor.IsEmpty ? Color.FromArgb(226, 232, 240) : item.BtnForeColor,  
                            item.HoverBackColor.IsEmpty ? Color.FromArgb(71, 85, 105) : item.HoverBackColor, 
                            item.HoverForeColor.IsEmpty ? Color.White : item.HoverForeColor
                        );

                        subMenu.SubContainer.BackColor = Color.FromArgb(30, 41, 59); 
                    }
                    else
                    {
                        btn.UpdateStyle(
                            item.BtnBackColor.IsEmpty ? Color.FromArgb(30, 41, 59) : item.BtnBackColor,      
                            item.BtnForeColor.IsEmpty ? Color.FromArgb(226, 232, 240) : item.BtnForeColor,   
                            item.HoverBackColor.IsEmpty ? Color.FromArgb(37, 99, 235) : item.HoverBackColor, 
                            item.HoverForeColor.IsEmpty ? Color.White : item.HoverForeColor
                        );
                    }

                    btn.MenuBtnClicked += (s, k) => SideBarItemClicked?.Invoke(s, k);
                    parent.Controls.Add(btn);
                }
            }
        }

        private void _ToggleSubMenu(object s, ctrlSubMenu CurrentSubMenu)
        {
            if (ClickedSubMenu == null)
            {
                ClickedSubMenu = CurrentSubMenu;
            }
            if (ClickedSubMenu == CurrentSubMenu)
            {
                CurrentSubMenu.SubContainer.Visible = !CurrentSubMenu.SubContainer.Visible;

                if (CurrentSubMenu.SubContainer.Visible)
                {
                    ClickedSubMenu.ArrowIcon = Resources.up;
                    CurrentSubMenu.Height = CurrentSubMenu.MainBtnContainer.Height + CurrentSubMenu.SubContainer.PreferredSize.Height;
                }
                else
                {
                    ClickedSubMenu.ArrowIcon = Resources.down;
                    CurrentSubMenu.Height = CurrentSubMenu.MainBtnContainer.Height;
                }
            }
            if (ClickedSubMenu != CurrentSubMenu)
            {
                ClickedSubMenu.Height = ClickedSubMenu.MainBtnContainer.Height;
                ClickedSubMenu.SubContainer.Visible = false;

                CurrentSubMenu.SubContainer.Visible = true;
                CurrentSubMenu.ArrowIcon = Resources.up;
                CurrentSubMenu.Height = CurrentSubMenu.MainBtnContainer.Height + CurrentSubMenu.SubContainer.PreferredSize.Height;

                ClickedSubMenu = CurrentSubMenu;
            }

        }


    }
}
