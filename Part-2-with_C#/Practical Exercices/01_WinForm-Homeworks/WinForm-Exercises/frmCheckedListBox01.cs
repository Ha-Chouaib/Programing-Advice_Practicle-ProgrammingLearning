using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_Exercises
{
    public partial class frmTaskManager: Form
    {
        public frmTaskManager()
        {
            InitializeComponent();
        }
        private void ShowCompletedTasck()
        {
            string Tasks = "";
            foreach(object task in clbTasks.CheckedItems)
            {
                Tasks += task + Environment.NewLine;
            }
            lblCompletedTTasks.Text = Tasks;
        }
       
        private void UpdateTasksProgressPetcentage(CheckedListBox _CheckedListBox)
        {
            int TotalTasks = _CheckedListBox.Items.Count;
            int CompletedTasks = _CheckedListBox.CheckedItems.Count;
            if(TotalTasks == 0)
            {
                lblCompletedTTasks.Text = "No Task Available";
                pbTasksProgress.Value = 0;
                return;
            }

            int Perc = (CompletedTasks * 100) /TotalTasks ;
            lblProgresPrecentage.Text = $"{Perc}%";
            pbTasksProgress.Value = Perc;
            ShowCompletedTasck();
        }
        
        private void AddNewTask(string TaskName, CheckedListBox _CheckedListBox)
        {
            string TaskOrder=_CheckedListBox.Items.Count.ToString() + "-";
            _CheckedListBox.Items.Add(TaskOrder + TaskName);
            UpdateTasksProgressPetcentage(clbTasks);
        }
        private void DeleteTask(byte TaskIndex,CheckedListBox _CheckedListBox)
        {   
            if(TaskIndex > _CheckedListBox.Items.Count)
            {
                MessageBox.Show("The Value Is Out Of Range Please Set A valid One", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            {
                _CheckedListBox.Items.RemoveAt(TaskIndex - 1);
                UpdateTasksProgressPetcentage(clbTasks);
            }
        }
        
        private void UpdateTask(byte TaskIndex,CheckedListBox _CheckedListBox,string UpdatedName)
        {

            if (TaskIndex > _CheckedListBox.Items.Count)
            {
                MessageBox.Show("The Value Is Out Of Range Please Set A valid One", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                DeleteTask(TaskIndex, _CheckedListBox);
                _CheckedListBox.Items.Insert(TaskIndex - 1, UpdatedName);
            }
           
        }
        
        private void txtNewTaskName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtNewTaskName.Text))
            {
                e.Cancel= true;
                errorProvider1.SetError(txtNewTaskName, "This Field is Require");

            }
            else 
            {
                errorProvider1.SetError(txtNewTaskName, "");   
            }
        }

        private void tstxtUpdateTask_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tstxtUpdateTask.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tstxtUpdateTask, "This Field is Require");

            }
            else
            {
                errorProvider1.SetError(tstxtUpdateTask, "");
            }
        }

        private void btnAddNewTask_Click(object sender, EventArgs e)
        {

            AddNewTask(txtNewTaskName.Text, clbTasks);
            txtNewTaskName.Clear();
        }
        private void btnDeleteTask_Click_1(object sender, EventArgs e)
        {
            DeleteTask(Convert.ToByte(nudGetIndexToDelete.Value), clbTasks);
            nudGetIndexToDelete.Value = nudGetIndexToDelete.Minimum;
        }

        private void btnUpdateTask_Click_1(object sender, EventArgs e)
        {
            UpdateTask(Convert.ToByte(nudGetIndexToUpdate.Value), clbTasks, tstxtUpdateTask.Text);
            nudGetIndexToUpdate.Value= nudGetIndexToUpdate.Minimum;
            tstxtUpdateTask.Clear();
        }

        private void frmTaskManager_Load(object sender, EventArgs e)
        {
            UpdateTasksProgressPetcentage(clbTasks);
        }

        private void clbTasks_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate { UpdateTasksProgressPetcentage(clbTasks); });
        }
    }
}
