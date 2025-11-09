using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Send_DataByDelegate
{
    public partial class Form2: Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public delegate void SendBackDataEventHandler(object sender, int PersonID);

        public event SendBackDataEventHandler SendDataBack; 
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnSendBackData_Click(object sender, EventArgs e)
        {
            if(int.TryParse(textBox1.Text,out int PersonID))
            {
                SendDataBack?.Invoke(this, PersonID);
                this.Close();
            }
        }
    }
}
