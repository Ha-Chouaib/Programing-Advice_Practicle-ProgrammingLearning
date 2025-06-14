using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp_Level2
{
    public partial class ctrlSimpleEvent : UserControl
    {
        public ctrlSimpleEvent()
        {
            InitializeComponent();
        }

        public event Action<string> OnbtnCliked;
        protected virtual void btnClicked(string MSG)
        {
            Action<string> Handler = OnbtnCliked;
            if (Handler != null) Handler(MSG);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (OnbtnCliked != null) btnClicked("The Event Triggered Successfully :)");
        }
    }
}
