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
    public partial class ctrlFind : UserControl
    {
        public ctrlFind()
        {
            InitializeComponent();
        }

        public TextBox txtSearchTerm => txtSearch;
        public Panel SearchBarContainer => panel1;
        public ComboBox FindOptions => cmbFindOptions;

        public void __Initializing(Dictionary<string, string> Options, FindDelegate FindHandler)
        {
            _FindByOptions = Options;
            _FindHandler = FindHandler;

            _FillSearchOptions();

            txtSearch.Focus();
        }
        public delegate object FindDelegate(string columnName, string value);
        public event EventHandler<object> __ObjectFound;

        private Dictionary<string,string> _FindByOptions;
        private FindDelegate _FindHandler;

        private void pbSearch_Click(object sender, EventArgs e)
        {
            string ColumnName = ((KeyValuePair<string,string>)cmbFindOptions.SelectedItem).Value;
            string searchTerm = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm))
            {
                txtSearch.Focus();
                return;
            }

            object Target = _FindHandler(ColumnName, searchTerm);

            if (Target != null)
                __ObjectFound?.Invoke(null, Target);
            else
                MessageBox.Show("No record found!");

        }
        private void _FillSearchOptions()
        {
            cmbFindOptions.DataSource = new BindingSource(_FindByOptions, null);
            cmbFindOptions.DisplayMember = "key";
            cmbFindOptions.ValueMember = "value";
            cmbFindOptions.SelectedIndex = 0;
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
           

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                pbSearch_Click(null, null);
               
            }
            if (cmbFindOptions.SelectedValue.ToString() == "PersonID")
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void cmbFindOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            txtSearch.Focus();                
        }
    }
}
