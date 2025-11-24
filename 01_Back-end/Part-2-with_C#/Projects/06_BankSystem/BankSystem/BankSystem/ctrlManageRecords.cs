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
        private Func<string,string,DataTable> _FilterRecordsDelegate;

        public DataGridView __RecordsContainer => dgvListRecords;
        public PictureBox __HeaderImg => pbRecordsProfile;
        public Label __HeaderTitle => lblTitle;
        public Button __AddNewBtn => btnAddNew;
        public Button __UpdateBtn => btnUpdate;

        private Dictionary<string, Dictionary<string, string>> _FilterByGroups { get; set; }
        public void __Initialize(DataTable RecordsList,Dictionary<string,string> FilterByOptions,Func<string,string,DataTable> FilterDelegate,
            List<(string ContextMenuKey,Action<int> ContextMenuAction)> ContextMenuPackage,Dictionary<string,Dictionary<string,string>> FilterByGroups = null )
        {
            __RefreshRecordsList(RecordsList);

            cmbFilterOptions.DataSource = new BindingSource(FilterByOptions, null);
            cmbFilterOptions.ValueMember = "value";
            cmbFilterOptions.DisplayMember = "key";
            cmbFilterOptions.SelectedIndex = 0;

            _FilterByGroups = FilterByGroups;
            _FilterRecordsDelegate = FilterDelegate;

            _LoadContextMenu(ContextMenuPackage);
            pbSearchClick.Enabled = false;
        }
        private void _LoadContextMenu(List<(string ContextMenuKey, Action<int> ContextMenuAction)> ContextMenuPackage)
        {
            contextMenuStrip1.Items.Clear();
            foreach (var action in ContextMenuPackage)
            {
                var item = new ToolStripMenuItem(action.ContextMenuKey);
                item.Click += (s, e) =>
                {
                    if(int.TryParse(dgvListRecords.CurrentRow.Cells[0].Value.ToString(), out int SelectedRecordID))
                        action.ContextMenuAction?.Invoke(SelectedRecordID);
                };

                contextMenuStrip1.Items.Add(item);
            }
        }

        private void pbSearchClick_Click(object sender, EventArgs e)
        {
            
            if (txtSearchTerm.Text == string.Empty) return;

            var result = _FilterRecordsDelegate?.Invoke(cmbFilterOptions.SelectedValue.ToString(), txtSearchTerm.Text.Trim());
            __RefreshRecordsList(result);

        }
        public void __RefreshRecordsList(DataTable NewList)
        {
            dgvListRecords.DataSource = NewList;
            lblRecordsCount.Text = $"Records: [ {dgvListRecords.RowCount} ]";
        }
        public void __RefreshRecordsList()
        {
            __RefreshRecordsList(_FilterRecordsDelegate?.Invoke("All", "All"));
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
                __RefreshRecordsList(_FilterRecordsDelegate?.Invoke("All", "All"));
                return;
            }
            
            cmbFilterByGroups.Visible = false;
            txtSearchTerm.Visible = true;
            pbSearchClick.Visible = true;
            if(cmbFilterOptions.SelectedValue.ToString() == "All")
            {
                pbSearchClick.Enabled = false;
                __RefreshRecordsList(_FilterRecordsDelegate?.Invoke("All", "All"));
                return;
            }
            pbSearchClick.Enabled = true;
            txtSearchTerm.Text = string.Empty;
            txtSearchTerm.Focus();
        }

        private void cmbFilterByGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            var FilteredList = _FilterRecordsDelegate?.Invoke(cmbFilterOptions.SelectedValue.ToString(), cmbFilterByGroups.SelectedValue.ToString());
            __RefreshRecordsList(FilteredList);
        }

       
    }
}
