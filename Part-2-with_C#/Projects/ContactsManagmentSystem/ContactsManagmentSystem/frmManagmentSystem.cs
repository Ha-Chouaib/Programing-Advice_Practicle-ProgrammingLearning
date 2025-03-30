using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsManagmentSystem
{
    public partial class frmManagmentSystem: Form
    {
        public frmManagmentSystem()
        {
            InitializeComponent();
        }

        private void frmManagmentSystem_Load(object sender, EventArgs e)
        {
            _ListContacts();
        }

        private Button _CardBtnUniformStyle()
        {

            Button btnMain = new Button
            {

                AutoSize = true,
                BackColor = Color.FromArgb(103, 9, 219),
                ForeColor = Color.Bisque,
                Font = new Font("Comic Sans MS", 10),
            };
            return btnMain;
        }
        private Panel _GenerateContactCard()
        {
            byte CardWidth = (byte)(pnlListContainer.Width * 0.95);
            byte CardHeight = 50;

            Panel ContactCard = new Panel
            {
                Width = CardWidth,
                Height = CardHeight,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(40, 40, 40),
                Padding= new Padding(0,10,3,10),
                AutoSize =true,
            };

            Label lblName = new Label
            {
                Text = "FullName",
                AutoSize = true,
                ForeColor = Color.Bisque,

            };

            PictureBox ProfileImg = new PictureBox
            {
                Width = 30,
                Height = 30,
                BackColor = Color.Gray,
                SizeMode= PictureBoxSizeMode.Zoom,
            };


            Button btnSendEmail = _CardBtnUniformStyle();
            btnSendEmail.Text = "Send Email";
          
            Button btnSendSMS = _CardBtnUniformStyle();
            btnSendSMS.Text = "Send SMS";

            Button btnPhoneCall = _CardBtnUniformStyle();
            btnPhoneCall.Text = "Call";

            Button btnUpdate = _CardBtnUniformStyle();
            btnUpdate.Text = "Update";

            Button btnDelete = _CardBtnUniformStyle();
            btnDelete.Text = "Delete";


            FlowLayoutPanel HeadPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoSize = true,
                Location = new Point(2,5 ),
                Width = CardWidth - 10,
            };
            HeadPanel.Controls.Add(ProfileImg);
            HeadPanel.Controls.Add(lblName);

            FlowLayoutPanel Top3BtnsPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoSize = true,
                Location = new Point(10, 40),
                Width = CardWidth - 10,
            };
            Top3BtnsPanel.Controls.Add(btnSendEmail);
            Top3BtnsPanel.Controls.Add(btnSendSMS);
            Top3BtnsPanel.Controls.Add(btnPhoneCall);

            FlowLayoutPanel Bottom2BtnsPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoSize = true,
                Location = new Point(10, 60),
                Width = CardWidth - 10,
            };
            Bottom2BtnsPanel.Controls.Add(btnUpdate);
            Bottom2BtnsPanel.Controls.Add(btnDelete);

            ContactCard.Controls.Add(HeadPanel);
            ContactCard.Controls.Add(Top3BtnsPanel);
            ContactCard.Controls.Add(Bottom2BtnsPanel);

            return ContactCard;
        }
    
        private void _ListContacts()
        {
            FlowLayoutPanel Container = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(5),
                Dock = DockStyle.Fill,
                WrapContents =false,
            };
            pnlListContainer.Controls.Add(Container);
            
            for(int i=0;i<3;i++)
            {
                Container.Controls.Add(_GenerateContactCard());
            }
        }
    
    }
}
