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

        public Action __AddNewRecordDeleg;
        public Action __UpdateRecordDeleg;
        public Action __CloseFormDeleg;
        private Func<string,string,DataTable> _SearchRecordsDeleg;

        public Image __HeaderImg => pbRecordsProfile.Image;
        public Label __HeaderTitle => lblTitle;

        public void Initialize(DataTable RecordsList,Dictionary<string,string> FilterByOptions,Func<string,string,DataTable> FilterDelegate,
            List<(string ContextMenuKey,Action<int> ContextMenuAction)> ContextMenuPackage)
        {
            __RefreshRecordsList(RecordsList);

            cmbFilterOptions.DataSource = new BindingSource(FilterByOptions, null);
            cmbFilterOptions.ValueMember = "value";
            cmbFilterOptions.DisplayMember = "key";
            cmbFilterOptions.SelectedIndex = 0;

            _SearchRecordsDeleg = FilterDelegate;
            _LoadContextMenu(ContextMenuPackage);
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
            if(txtSearchTerm.Text == string.Empty) return;

            string FilterColumn = cmbFilterOptions.SelectedValue.ToString();
            string FilterTerm = txtSearchTerm.Text.Trim();
            var result = _SearchRecordsDeleg?.Invoke(FilterColumn,FilterTerm);
            __RefreshRecordsList(result);

        }
        public void __RefreshRecordsList(DataTable NewList)
        {
            dgvListRecords.DataSource = NewList;
            lblRecordsCount.Text = $"Records: [ {dgvListRecords.RowCount} ]";
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            __AddNewRecordDeleg?.Invoke();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            __UpdateRecordDeleg?.Invoke();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            __CloseFormDeleg?.Invoke();
        }

        private void cmbFilterOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchTerm.Text = string.Empty;
            txtSearchTerm.Focus();
        }
    }
}
