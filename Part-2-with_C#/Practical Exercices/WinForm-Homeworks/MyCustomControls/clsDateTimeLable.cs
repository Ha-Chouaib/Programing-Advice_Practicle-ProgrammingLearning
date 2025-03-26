using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MyCustomControls
{
    public class clsDateTimeLable : Label
    {
        private DateTime _SlectedDate = new DateTime();
        public DateTime SelectedDate
        {
            get { return _SlectedDate; }
            set { _SlectedDate = value;
                this.Text = _SlectedDate.ToShortDateString();       
                }
        }

        public clsDateTimeLable()
        {
            this.Text = "Click To Select a Date";
            this.AutoSize = true;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;

            this.Click += ClsDateTimeLable_Click;
        }

        private void ClsDateTimeLable_Click(object sender, EventArgs e)
        {
            using (DateTimePicker dtp = new DateTimePicker()) 
            using (Form pickerForm = new Form()) 
            using (Button btnOk= new Button())
            using (Button btnCancel = new Button())
            {
                // set up The Form
                pickerForm.Text = "Select a Date";
                pickerForm.Size = new Size(250, 150);
                pickerForm.StartPosition = FormStartPosition.CenterScreen;
                pickerForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                pickerForm.MaximizeBox = false;
                pickerForm.MinimizeBox = false;
                pickerForm.AcceptButton = btnOk;
                pickerForm.CancelButton = btnCancel;

                dtp.Format = DateTimePickerFormat.Short;
                dtp.Location = new Point(20, 20);

                btnOk.Text = "Ok";
                btnOk.DialogResult = DialogResult.OK;
                btnOk.Location = new Point(20, 60);

                btnCancel.Text = "Cancel";
                btnCancel.DialogResult = DialogResult.Cancel;
                btnCancel.Location = new Point(120, 60);

                pickerForm.Controls.Add(dtp);
                pickerForm.Controls.Add(btnOk);
                pickerForm.Controls.Add(btnCancel);

                if(pickerForm.ShowDialog() == DialogResult.OK)
                {
                    this.SelectedDate = dtp.Value;
                }
                    
            }
        }


       
    }
}
