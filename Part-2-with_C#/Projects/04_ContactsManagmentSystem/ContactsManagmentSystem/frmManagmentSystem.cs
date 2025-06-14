using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ContactsBusinessLayer;

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
            _ListAllContacts();
            _LoadCountriesNameToComboBox();

        }

        enum enActions { eShowDetails=1,eAddNew=2,eUpdate=3}
        enActions Action= enActions.eAddNew;

        private void _ResetDisplayInfoFields()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            dtDateOfBirth.Value = DateTime.Now;

            cmbCountries.SelectedIndex =0;
          

        }
        
        ErrorProvider errProv = new ErrorProvider();
        private void _SetTextBoxRequired(TextBox txtB)
        {
            if (txtB.Text == string.Empty)
                errProv.SetError(txtB, "The Field Is required");
            else
                errProv.SetError(txtB, "");

        }
        private void _RemoveErrorProvFromContactFields()
        {
            errProv.SetError(txtFirstName, "");
            errProv.SetError(txtLastName, "");
            errProv.SetError(txtEmail, "");
            errProv.SetError(txtPhone, "");
            errProv.SetError(txtAddress, "");
        }
        private bool _RequiredContactFields()
        {
            _SetTextBoxRequired(txtFirstName);
            _SetTextBoxRequired(txtLastName);
            _SetTextBoxRequired(txtEmail);
            _SetTextBoxRequired(txtAddress);
            _SetTextBoxRequired(txtPhone);
            return (txtFirstName.Text != "" && txtLastName.Text != "" && txtEmail.Text != "" && txtAddress.Text != "" && txtPhone.Text != "");
        }
        private void _LoadCountriesNameToComboBox()
        {
            DataTable DT = clsCountries.GetAllCountries();
            foreach(DataRow row in DT.Rows)
            {
                cmbCountries.Items.Add(row["CountryName"]);
            }
            cmbCountries.SelectedIndex = 1;

        }
        private void _DisplayContactInfo(int ContactID)
        {
            if(clsContacts.ISExist(ContactID))
            {
                clsContacts contact = clsContacts.Find(ContactID);
                txtFirstName.Text = contact.FirstName;
                txtLastName.Text = contact.LastName;
                txtEmail.Text = contact.Email;
                txtPhone.Text = contact.Phone;
                txtAddress.Text = contact.Address;
                dtDateOfBirth.Value = contact.DateOfbirth;

                clsCountries Country = clsCountries.Find(contact.CountryID);
                cmbCountries.SelectedIndex = cmbCountries.FindString(Country.CountryName);
                
            }else
            {
                MessageBox.Show("The Contact doesn't Exists");
            }
        }
        private void DisableEnableShowInfoFields(bool isEnable=true)
        {
            txtFirstName.Enabled = isEnable;
            txtLastName.Enabled = isEnable;
            txtEmail.Enabled = isEnable;
            txtPhone.Enabled = isEnable;
            txtAddress.Enabled = isEnable;
            cmbCountries.Enabled = isEnable;


        }

        private void _ShowDetails(int ContactID)
        {
            Action = enActions.eShowDetails;
            _DisplayContactInfo(ContactID);
            btnPerformActions.Text = "Return To Add New Mode";
            DisableEnableShowInfoFields(false);
        }
        private void _LoadContactToUpdate(int ContactID)
        {
            Action = enActions.eUpdate;
            DisableEnableShowInfoFields();
            _DisplayContactInfo(ContactID);
            btnPerformActions.Text = "Update";
            btnPerformActions.Tag = ContactID;
        }
        private void _SaveUpdates()
        {   
            if (_RequiredContactFields() && MessageBox.Show("The Contact Will Be Updated Once You Click OK","Confirmation",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)== DialogResult.OK)
            {
                int ID = (int)btnPerformActions.Tag;
                clsContacts contact = clsContacts.Find(ID);
                if (contact != null)
                {
                    contact.FirstName = txtFirstName.Text;
                    contact.LastName = txtLastName.Text;
                    contact.Email = txtEmail.Text;
                    contact.Phone = txtPhone.Text;
                    contact.Address = txtAddress.Text;
                    contact.DateOfbirth = dtDateOfBirth.Value;

                    clsCountries country = clsCountries.Find(cmbCountries.Text);
                    contact.CountryID = country.CountryID;
                   
                    if(contact.Save())
                    {
                        MessageBox.Show("The Contact Updated Successfully");
                        _ResetDisplayInfoFields();
                        _RemoveContactsCards();
                        _ListAllContacts();
                        btnPerformActions.Text = "Add New Contact";
                        Action = enActions.eAddNew;
                    }
                    else
                    {
                        MessageBox.Show("The Contact Can't be Updated Correctly Please ReUpdate Again !");

                    }
                }
                else
                {
                    MessageBox.Show("The Contact Was Removed");
                }
            }
            else
            {
                MessageBox.Show("The Operation Ignored Successfully");
            }

            


        }
        private void _AddNewContact()
        {
            
            if (_RequiredContactFields() && MessageBox.Show("The New Contact Will Be Added Once You Click OK", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                clsContacts NewContact = new clsContacts();
                NewContact.FirstName = txtFirstName.Text;
                NewContact.LastName = txtLastName.Text;
                NewContact.Email = txtEmail.Text;
                NewContact.Phone = txtPhone.Text;
                NewContact.Address = txtAddress.Text;
                NewContact.DateOfbirth = dtDateOfBirth.Value;

                clsCountries country = clsCountries.Find(cmbCountries.SelectedItem.ToString());
                NewContact.CountryID = country.CountryID;
               
                if(NewContact.Save() )
                {
                    MessageBox.Show("The Contact Added Successfully");
                    _ResetDisplayInfoFields();
                    _RemoveContactsCards();
                    _ListAllContacts();
                }else
                {
                    MessageBox.Show("The Contact Connot Be Added Correctly");
                    
                }
            }
            else
            {

                MessageBox.Show("The Operation Ignored Successfully");
            }


        }
        private void _PerformActions()
        {
            switch(Action)
            {
                case enActions.eShowDetails:
                    _ResetDisplayInfoFields();
                    DisableEnableShowInfoFields();
                    btnPerformActions.Text = "Add New Contact";
                    Action = enActions.eAddNew;
                    break;

                case enActions.eUpdate:
                    _SaveUpdates();

                    break;
                case enActions.eAddNew:
                    _AddNewContact();
                    break;
            }
            
        }
        
        private void _ShowDetails_Click(object sender, EventArgs e)
        {
            _RemoveErrorProvFromContactFields();
            if(sender is Button btn)
            {
                int ID = (int)btn.Tag;
                _ShowDetails(ID);
            }

        }
        private void _SendEmail_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            int ID = (int)btn.Tag;
            clsContacts contact = clsContacts.Find(ID);
            if (contact != null)
            {
                MessageBox.Show($"Send Email To: {contact.Email}");

            }
        }
        private void _SendSMS_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int ID= (int)btn.Tag;
            clsContacts contact = clsContacts.Find(ID);
            if(contact != null)
            {
                MessageBox.Show($"Send Message To: {contact.Phone}");

            }
        }
        private void Call_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            int ID = (int)btn.Tag;
            clsContacts contact = clsContacts.Find(ID);
            if (contact != null)
            {
                MessageBox.Show($"Call The Phone Number: {contact.Phone}");

            }
        }
        private void _Update_Click(object sender, EventArgs e)
        {
            _RemoveErrorProvFromContactFields();
            Button btn = (Button)sender;
            int ID = (int)btn.Tag;
            _LoadContactToUpdate(ID);
        }
        private void _Delete_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            int ID = (int)btn.Tag;
           
            if (clsContacts.ISExist(ID))
            {
               
                if (MessageBox.Show("Sure To Delete The Contact?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if(clsContacts.DeleteContact(ID))
                    {
                        MessageBox.Show("The contact Deleted successfuly");
                        _RemoveContactsCards();
                        _ListAllContacts();
                    }
                    else
                    {
                        MessageBox.Show("Cannot Delete The Contact");

                    }
                }
                else
                {
                    MessageBox.Show("The Operation Ignored successfuly");
                }
            }
            else
            {
                MessageBox.Show("The Contact Doesn't Exist");

            }


        }

        private Button _MainBtn(string text,int ID ,Color backColr, Color ForeColr)
        {
            return new Button
            {   
                Tag=ID,
                Text = text,
                BackColor =backColr,
                ForeColor=ForeColr,
                AutoSize = true,
                Font= new Font("MV Boli",12,FontStyle.Bold),
                FlatStyle = FlatStyle.Popup,
                
            };
        }
        private void _GenerateContactsCards(DataTable dtContactsInf)
        {
                int Y = 10;
            int CardWidth = 990;
            int CardHeight = 100;
            FlowLayoutPanel CardsContainer = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                Dock = DockStyle.Fill,
                AutoScroll =true,
            };
            pnlListContainer.Controls.Add(CardsContainer);

            foreach (DataRow row in dtContactsInf.Rows)
            {
                
                Panel ContactCard = new Panel
                {
                    Width = CardWidth,
                    Height = CardHeight,
                    Padding = new Padding(10),
                    Location = new Point(10, Y),
                    BackColor = Color.FromArgb(30, 30, 30),
                };

                TableLayoutPanel CardLayout = new TableLayoutPanel
                {
                    RowCount = 1,
                    ColumnCount = 3,
                    Dock = DockStyle.Fill,
                    
                    CellBorderStyle=TableLayoutPanelCellBorderStyle.None,
                };

                CardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,20));
                CardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,40));
                CardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,40));

                CardLayout.RowStyles.Add(new RowStyle(SizeType.Percent,100));

                string ImagePath = "";
                if (row["ImagePath"]== DBNull.Value )
                {
                    ImagePath = @"C:\ProfileImg.jpg";
                        
                }else
                {
                    ImagePath = (string)row["ImagePath"];
                }
                    PictureBox ProfilePic = new PictureBox
                    {
                        BackColor = Color.Black,
                        Width = 50,
                        Height = 50,
                        SizeMode = PictureBoxSizeMode.Zoom,

                        Image = Image.FromFile(ImagePath)

                    };

                Label lblName = new Label 
                {
                    Text =  $"{row["FirstName"]} {row["LastName"]}",
                    Font= new Font("MV Boli",12,FontStyle.Bold),
                    ForeColor= Color.Bisque,
                    AutoSize=true,
                };
                int ContactID =(int)row["ContactID"];

                FlowLayoutPanel ProfilePnl = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.TopDown,
                    Dock = DockStyle.Fill,
                };
                ProfilePnl.Controls.Add(ProfilePic);
                ProfilePnl.Controls.Add(lblName);

                CardLayout.Controls.Add(ProfilePnl, 0, 0);

                FlowLayoutPanel MidBtns = new FlowLayoutPanel
                {
                    FlowDirection= FlowDirection.LeftToRight,
                    Dock=DockStyle.Fill,
                };

                Color BtnsSharedBackcolor = Color.FromArgb(103, 9, 219);

                Button btnSendEmail = _MainBtn("Send Email",ContactID, BtnsSharedBackcolor, Color.Bisque);
                Button btnSendSMS = _MainBtn("Send SMS",ContactID, BtnsSharedBackcolor, Color.Bisque);
                Button btnCall = _MainBtn("Call",ContactID, BtnsSharedBackcolor, Color.Bisque);

                btnSendEmail.Click += _SendEmail_Click;
                btnSendSMS.Click += _SendSMS_Click;
                btnCall.Click += Call_Click;

                MidBtns.Controls.Add(btnSendEmail);
                MidBtns.Controls.Add(btnSendSMS);
                MidBtns.Controls.Add(btnCall);

                CardLayout.Controls.Add(MidBtns, 1, 0);

                FlowLayoutPanel EndBtns = new FlowLayoutPanel
                {
                    FlowDirection= FlowDirection.LeftToRight,
                    Dock=DockStyle.Fill,
                };

                Button btnUpdate = _MainBtn("Update",ContactID, Color.FromArgb(0,192, 0), Color.Bisque);
                Button btnDelete = _MainBtn("Delete",ContactID, Color.FromArgb(192,0, 0), Color.Bisque);
                Button btnDetails = _MainBtn("Details", ContactID, Color.FromArgb(00, 00, 00), Color.Bisque);

                btnUpdate.Click += _Update_Click;
                btnDelete.Click += _Delete_Click;
                btnDetails.Click += _ShowDetails_Click;

                EndBtns.Controls.Add(btnUpdate);
                EndBtns.Controls.Add(btnDelete);
                EndBtns.Controls.Add(btnDetails);
                CardLayout.Controls.Add(EndBtns, 2, 0);


                ContactCard.Controls.Add(CardLayout);
                CardsContainer.Controls.Add(ContactCard);
                Y += CardHeight + 10;
            }
        }
        private void _RemoveContactsCards()
        {
            foreach(Control ctrl in pnlListContainer.Controls.OfType<Panel>().ToList())
            {
                pnlListContainer.Controls.Remove(ctrl);
                ctrl.Dispose();
            }
        }
        private void _ListAllContacts()
        {
            DataTable dtContactsInf = clsContacts.GetAllContacts();
            _GenerateContactsCards(dtContactsInf);
        }
        private void btnPerformActions_Click(object sender, EventArgs e)
        {
            _PerformActions();
        }
       
        private void btnListAll_Click(object sender, EventArgs e)
        {
            _RemoveContactsCards();
            _ListAllContacts();
        }
       
        private void btnRestAll_Click(object sender, EventArgs e)
        {
            _ResetDisplayInfoFields();
            _RemoveErrorProvFromContactFields();
            
        }

        private void btnBackToAddNewMode_Click(object sender, EventArgs e)
        {
            Action = enActions.eAddNew;
            btnPerformActions.Text = "Add New Contact";
            DisableEnableShowInfoFields();
            _ResetDisplayInfoFields();
            
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {

            DataTable ListFiltredContacts = new DataTable();
            string srh = txtSearch.Text;
            if (srh != string.Empty)
            {

                ListFiltredContacts = clsContacts.ListContactsByFirstLast_Name(srh);

                _RemoveContactsCards();

            }
            _GenerateContactsCards(ListFiltredContacts);
            txtSearch.Text = string.Empty;
        }
    }
}
