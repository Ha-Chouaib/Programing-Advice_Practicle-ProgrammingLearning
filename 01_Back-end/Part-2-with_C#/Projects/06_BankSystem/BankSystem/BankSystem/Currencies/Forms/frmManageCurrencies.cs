using Bank_BusinessLayer;
using Bank_BusinessLayer.Reports.CustomerReports;
using BankSystem.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Currencies.Forms
{
    public partial class frmManageCurrencies : Form
    {
        public frmManageCurrencies()
        {
            InitializeComponent();
            LoadManageRecordsControl();
        }

        private ctrlManageRecords _RecordsManager => ctrlManageRecords1;
        public static class ContextMenuItems
        {
            public static (string valueMember, string displayMember) ShowCurrencyCard => ("ShowCurrencyCard", "show currency card");
            public static (string valueMember, string displayMember) UpdateCurrencyRate => ("UpdateCurrencyRate", "Update currency Rate");
        }

        public void LoadManageRecordsControl()
        {
            _RecordsManager.__UpdateBtn.Visible = false;
            _RecordsManager.__AddNewBtn.Visible = false;
            _RecordsManager.__CloseFormDelegate += () => Close();
            _RecordsManager.__HeaderImg.Image = Resources.currencies_6871665;

            _RecordsManager.__Initialize(_FilterBy_Options(), clsCurrencies.Filter, _ContextMenuPackage(), null);
            ctrlManageRecords1.__ContextMenuStrip.Opening += (s, e) =>
            {
                var user = clsGlobal_BL.LoggedInUser;

                ctrlManageRecords1.__ContextMenuStrip.Items[ContextMenuItems.UpdateCurrencyRate.valueMember].Visible =
                    user.HasPermission(clsRole.enRolePresets.Admin);
            };

            _ConfigureDataRecordsContainer();
        }
        private Dictionary<string, string> _FilterBy_Options()
        {
            return clsUtil_BL.MappingHelper.GetOptionsFromMapping(typeof(clsCurrencies.Filter_Mapping));

        }
        private List<((string valueMember, string displayMember) ContextMenuItem, Action<int, ToolStripMenuItem> ContextMenuAction)> _ContextMenuPackage()
        {
            var contextMenuItems = new List<((string valueMember, string displayMember), Action<int, ToolStripMenuItem>)>
            {
                (ContextMenuItems.ShowCurrencyCard, _ContextMenuViewCurrencyCard),
                (ContextMenuItems.UpdateCurrencyRate, _ContextMenuUpdateCurrencyRate),
            };

            return contextMenuItems;
        }

        void _ContextMenuViewCurrencyCard(int currencyId, ToolStripMenuItem menuItem)
        {
            frmFindCarrency currencyCard = new frmFindCarrency(currencyId);
            currencyCard.ShowDialog();
        }
        void _ContextMenuUpdateCurrencyRate(int currencyId, ToolStripMenuItem menuItem)
        {
            frmCurrencyUpdateRate editRate = new frmCurrencyUpdateRate(currencyId);
            editRate.ShowDialog();
        }
        private void _ConfigureDataRecordsContainer()
        {


            if (_RecordsManager.__RecordsContainer.RowCount == 0) return;

            _RecordsManager.__RecordsContainer.Columns["ID"].HeaderText = "Currency ID";
            _RecordsManager.__RecordsContainer.Columns["Country"].HeaderText = "Currency Entity";
            _RecordsManager.__RecordsContainer.Columns["Name"].HeaderText = "Currency Name";
            _RecordsManager.__RecordsContainer.Columns["Code"].HeaderText = "Currency Code";
            _RecordsManager.__RecordsContainer.Columns["Rate"].HeaderText = "Currency Rate";
          
        }
    }
}
