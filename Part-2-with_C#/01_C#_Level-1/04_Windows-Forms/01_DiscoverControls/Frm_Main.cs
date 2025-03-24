using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_FirstWinFormsPro
{
    public partial class Frm_Main: Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {

        }

        private void btnShowPart1_Click(object sender, EventArgs e)
        {
            Form Frm1 = new Form1();
            Frm1.Show();
        }

        private void btn_ShowForm1AsDaialog_Click(object sender, EventArgs e)
        {
            Form Frm1 = new Form1();
            Frm1.ShowDialog();
        }

        private void btnMSG_BoxForm_Click(object sender, EventArgs e)
        {
            Form frmMSGBox = new MessageBoxForm();
            frmMSGBox.ShowDialog();
        }

        private void btnToRadio_Click(object sender, EventArgs e)
        {
            Form frmCheckBoxForm = new RadioBoxForm();
            frmCheckBoxForm.Show();
        }

        private void btnToMBForm_Click(object sender, EventArgs e)
        {
            Form frmMaskedTB = new MaskedBox_Form();
            frmMaskedTB.Show();
        }

        private void BtnToCombo_Click(object sender, EventArgs e)
        {
            Form frmCombo = new frmComboBox();
            frmCombo.Show();
        }

        private void btnToLinkLable_Click(object sender, EventArgs e)
        {
            Form frmLinkLbl = new frmLinkLabel();
            frmLinkLbl.Show();
        }

        private void btnToCheckkedListBox_Click(object sender, EventArgs e)
        {
            Form frmCheckedLst = new frmChekedListBox();
            frmCheckedLst.Show();
        }

        private void btnToDateTimepicker_Click(object sender, EventArgs e)
        {
            Form frmDateTimePicker = new frmDateTimePicker();
            frmDateTimePicker.Show();
        }

        private void btnToTimer_Click(object sender, EventArgs e)
        {
            Form frmTimer = new frmTimer();
            frmTimer.Show();
        }

        private void btnToNotifyIcon_Click(object sender, EventArgs e)
        {
            Form frmNotify = new frmNotifyIcon();
            frmNotify.Show();
        }

        private void btnToTreeView_Click(object sender, EventArgs e)
        {
            Form frmTreeV_ImgList = new frmTreeView_ImageList();
            frmTreeV_ImgList.Show();
        }

        private void btnToPb_Click(object sender, EventArgs e)
        {
            Form frmProgressBar = new frmProgressBar();
            frmProgressBar.Show();
        }

        private void brnToListView_Click(object sender, EventArgs e)
        {
            Form frmListView = new frmListView();
            frmListView.Show();
        }

        private void btnToErrorProvider_Click(object sender, EventArgs e)
        {
            Form frmErrorProv = new frmErrorProvider();
            frmErrorProv.Show();
        }

        private void btnToTrakBar_Click(object sender, EventArgs e)
        {
            Form frmTrackBar = new TrackBar();
            frmTrackBar.Show();
        }

        private void btnToNumUpDown_Click(object sender, EventArgs e)
        {
            Form frmNumUpDown = new frmNumiricUpDown();
            frmNumUpDown.Show();
        }

        private void btnToTabControl_Click(object sender, EventArgs e)
        {
            Form frmTabControl = new frmTabsControl();
            frmTabControl.Show();
        }

        private void btnToPanel_Click(object sender, EventArgs e)
        {
            Form frmPanel = new frmGroupBoxVSPanel();
            frmPanel.Show();
        }

        private void btnToDialogs_Click(object sender, EventArgs e)
        {
            Form frmDialogs = new frmDialogs();
            frmDialogs.Show();
        }
    }
}
