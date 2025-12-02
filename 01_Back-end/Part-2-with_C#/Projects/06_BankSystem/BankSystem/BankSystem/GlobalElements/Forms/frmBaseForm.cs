using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class frmBaseForm : Form
    {
        public frmBaseForm()
        {
            InitializeComponent();
            if(!IsInDesignMode())
                Date_Clock();
        }
        private bool IsInDesignMode()
        {
            // safest design-mode check that also works in inheritance
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }
        protected void HeaderTitle(string Title)
        {
            lblHeaderTitle.Text = Title;
        }


        private void Date_Clock()
        {
            
                timer1.Tick += timer1_Tick;
                timer1.Start();

                _UpdateClock();
            
           
        }
        private void _UpdateClock()
        {
            lblClok.Text =$"{DateTime.Now.ToString("yyyy/MM/dd")} -- { DateTime.Now.ToString("hh:mm:ss tt")}" ;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _UpdateClock();
        }
        
        
    }
}
