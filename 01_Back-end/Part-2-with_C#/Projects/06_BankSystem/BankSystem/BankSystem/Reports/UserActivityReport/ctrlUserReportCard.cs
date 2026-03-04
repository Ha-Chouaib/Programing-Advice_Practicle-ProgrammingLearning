using Bank_BusinessLayer;
using Bank_BusinessLayer.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace BankSystem.Reports.UserActivityReport
{
    public partial class ctrlUserReportCard : UserControl
    {
        public ctrlUserReportCard()
        {
            InitializeComponent();
        }
        string Before;
        string After;
        public void __ShowCard(clsAuditUserActions report)
        {
            if (report == null)
            {
                MessageBox.Show("No data to display", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsAuditUserActions.AuditContext context = report.GetAuditContext();
            if (context == null) 
            {
                MessageBox.Show("Failed to retrieve report context", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtReportID.Text = report.ReportId.ToString();
            txtUserID.Text = report.UserId.ToString();
            txtUserName.Text = context.PerformedBy.UserName;
            txtRole.Text = context.PerformedBy.Role;
            txtReportDate.Text = report.ReportDate.ToString("g");
            txtMachine.Text = context.MachineInfo.MachineName;
            txtSectionKey.Text = context.Action.ActionKey;
            txtActionDescription.Text = context.Action.Description;
            txtSuccess.Text = context.Result.Success ? "Yes" : $"No: {context.Result.ErrorMessage}";
            txtSession.Text = context.MachineInfo.SessionID;
            txtEntityID.Text = report.EntityId?.ToString() ?? "N/A";

            bool hasChanges = context.Changes != null;
            
            if (lnkChanges.Enabled = hasChanges)
            {
                Before = JsonConvert.SerializeObject(context.Changes.Before, Formatting.Indented);
                After = JsonConvert.SerializeObject(context.Changes.After, Formatting.Indented);


            }
        }

        private void lnkChanges_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmUserReport_EntityChanges changesForm = new frmUserReport_EntityChanges(Before, After);
        }
    }
}
