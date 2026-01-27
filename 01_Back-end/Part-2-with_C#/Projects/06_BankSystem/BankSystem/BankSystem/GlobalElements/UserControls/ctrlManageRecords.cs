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
    public partial class ctrlManageRecords : UserControl
    {
        public ctrlManageRecords()
        {
            InitializeComponent();
        }

        public Action __AddNewRecordDelegate;
        public Action __UpdateRecordDelegate;
        public Action __CloseFormDelegate;
        public delegate DataTable FilterRecordsDelegate(string Column,string Term,byte PageNumber,byte PageSize,out short availablePages);
        private FilterRecordsDelegate _FilterRecordsDelegate;
        public DataGridView __RecordsContainer => dgvListRecords;
        public PictureBox __HeaderImg => pbRecordsProfile;
        public Label __HeaderTitle => lblTitle;
        public Button __AddNewBtn => btnAddNew;
        public Button __UpdateBtn => btnUpdate;

        public byte __PageNumber { get; set; }= 1;
        public byte __PageSize { get; set; } = 50;
        public short __AvailablePages { get; set; } = 0;

        StringBuilder _Column = new StringBuilder();
        StringBuilder _Term = new StringBuilder();

        private Dictionary<string, Dictionary<string, string>> _FilterByGroups { get; set; }
        public void __Initialize(Dictionary<string,string> FilterByOptions, FilterRecordsDelegate FilterDelegate,
            List<(string ContextMenuKey,Action<int, ToolStripMenuItem> ContextMenuAction)> ContextMenuPackage,Dictionary<string,Dictionary<string,string>> FilterByGroups = null )
        {
            __RefreshRecordsList();

            cmbFilterOptions.DataSource = new BindingSource(FilterByOptions, null);
            cmbFilterOptions.ValueMember = "value";
            cmbFilterOptions.DisplayMember = "key";
            cmbFilterOptions.SelectedIndex = 0;

            _FilterByGroups = FilterByGroups;
            _FilterRecordsDelegate = FilterDelegate;

            _LoadContextMenu(ContextMenuPackage);
            pbSearchClick.Enabled = false;
        }
        private void _LoadContextMenu(List<(string ContextMenuKey, Action<int,ToolStripMenuItem> ContextMenuAction)> ContextMenuPackage)
        {
            contextMenuStrip1.Items.Clear();
            foreach (var action in ContextMenuPackage)
            {
                var item = new ToolStripMenuItem(action.ContextMenuKey);
                item.Click += (s, e) =>
                {
                    if(int.TryParse(dgvListRecords.CurrentRow.Cells[0].Value.ToString(), out int SelectedRecordID))
                        action.ContextMenuAction?.Invoke(SelectedRecordID,item);
                };

                contextMenuStrip1.Items.Add(item);
            }
        }

        private void pbSearchClick_Click(object sender, EventArgs e)
        {
            if (txtSearchTerm.Text == string.Empty) return;
            _Column.Clear();
            _Term.Clear();

            _Column.Append(cmbFilterOptions.SelectedValue.ToString());
            _Term.Append(txtSearchTerm.Text.Trim());
            __RefreshRecordsList();

        }
        public void __RefreshRecordsList()
        {
           
            short AvailablePages = 0;

          
            dgvListRecords.DataSource = _FilterRecordsDelegate?.Invoke(_Column.ToString(), _Term.ToString(), __PageNumber, __PageSize, out AvailablePages);
            __AvailablePages = AvailablePages;
            lblAvaibalbePages.Text = $"[ {__PageNumber}/{__AvailablePages} ]";
            lblRecordsCount.Text = $"Records: [ {dgvListRecords.RowCount} ]";
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            __AddNewRecordDelegate?.Invoke();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            __UpdateRecordDelegate?.Invoke();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            __CloseFormDelegate?.Invoke();
        }

        private void cmbFilterOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (_FilterByGroups != null && _FilterByGroups.ContainsKey(cmbFilterOptions.SelectedValue.ToString()))
            {
                txtSearchTerm.Visible = false;
                pbSearchClick.Visible = false;

                cmbFilterByGroups.DataSource = new BindingSource(_FilterByGroups[cmbFilterOptions.SelectedValue.ToString()], null);
                cmbFilterByGroups.ValueMember = "value";
                cmbFilterByGroups.DisplayMember = "key";

                cmbFilterByGroups.SelectedIndex = 0;
                cmbFilterByGroups.Visible = true;
                __RefreshRecordsList();
                return;
            }
            
            cmbFilterByGroups.Visible = false;
            txtSearchTerm.Visible = true;
            pbSearchClick.Visible = true;
            if(cmbFilterOptions.SelectedValue.ToString() == "All")
            {
                pbSearchClick.Enabled = false;
                __RefreshRecordsList();
                return;
            }
            pbSearchClick.Enabled = true;
            txtSearchTerm.Text = string.Empty;
            txtSearchTerm.Focus();
        }

        private void cmbFilterByGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Column.Clear();
            _Term.Clear();

            _Column.Append(cmbFilterOptions.SelectedValue);
            _Term.Append(cmbFilterByGroups.SelectedValue);

            __RefreshRecordsList();
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            if(__PageNumber < __AvailablePages)
            {
                __PageNumber++;
                __RefreshRecordsList();
            }
        }

        private void pbPrevious_Click(object sender, EventArgs e)
        {
            if(__PageNumber > 1)
            {
                __PageNumber--;
                __RefreshRecordsList();
            }
        }
    }
}
