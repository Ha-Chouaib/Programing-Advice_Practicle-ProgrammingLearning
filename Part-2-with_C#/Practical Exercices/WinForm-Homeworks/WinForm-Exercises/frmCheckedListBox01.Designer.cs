namespace WinForm_Exercises
{
    partial class frmTaskManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.clbTasks = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddNewTask = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.btnUpdateTask = new System.Windows.Forms.Button();
            this.txtNewTaskName = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.nudGetIndexToDelete = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tstxtUpdateTask = new System.Windows.Forms.TextBox();
            this.nudGetIndexToUpdate = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lblProgresPrecentage = new System.Windows.Forms.Label();
            this.pbTasksProgress = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCompletedTTasks = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGetIndexToDelete)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGetIndexToUpdate)).BeginInit();
            this.SuspendLayout();
            // 
            // clbTasks
            // 
            this.clbTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.clbTasks.Font = new System.Drawing.Font("Gabriola", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbTasks.ForeColor = System.Drawing.SystemColors.Info;
            this.clbTasks.FormattingEnabled = true;
            this.clbTasks.Items.AddRange(new object[] {
            "Read Quran",
            "Sport",
            "BMH",
            "Programming",
            "Networking",
            "Russian",
            "Operating System"});
            this.clbTasks.Location = new System.Drawing.Point(12, 67);
            this.clbTasks.Name = "clbTasks";
            this.clbTasks.Size = new System.Drawing.Size(236, 389);
            this.clbTasks.TabIndex = 0;
            this.clbTasks.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbTasks_ItemCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(24)))), ((int)(((byte)(211)))));
            this.label1.Font = new System.Drawing.Font("Gabriola", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.label1.Location = new System.Drawing.Point(55, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "My  Daily Tasks";
            // 
            // btnAddNewTask
            // 
            this.btnAddNewTask.BackColor = System.Drawing.Color.Black;
            this.btnAddNewTask.Font = new System.Drawing.Font("MV Boli", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewTask.ForeColor = System.Drawing.Color.Aqua;
            this.btnAddNewTask.Location = new System.Drawing.Point(51, 496);
            this.btnAddNewTask.Name = "btnAddNewTask";
            this.btnAddNewTask.Size = new System.Drawing.Size(159, 30);
            this.btnAddNewTask.TabIndex = 2;
            this.btnAddNewTask.Text = "Add New Task";
            this.btnAddNewTask.UseVisualStyleBackColor = false;
            this.btnAddNewTask.Click += new System.EventHandler(this.btnAddNewTask_Click);
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.BackColor = System.Drawing.Color.Black;
            this.btnDeleteTask.Font = new System.Drawing.Font("MV Boli", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteTask.ForeColor = System.Drawing.Color.Aqua;
            this.btnDeleteTask.Location = new System.Drawing.Point(466, 496);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(159, 30);
            this.btnDeleteTask.TabIndex = 3;
            this.btnDeleteTask.Text = "Delete Task";
            this.btnDeleteTask.UseVisualStyleBackColor = false;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click_1);
            // 
            // btnUpdateTask
            // 
            this.btnUpdateTask.BackColor = System.Drawing.Color.Black;
            this.btnUpdateTask.Font = new System.Drawing.Font("MV Boli", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateTask.ForeColor = System.Drawing.Color.Aqua;
            this.btnUpdateTask.Location = new System.Drawing.Point(881, 496);
            this.btnUpdateTask.Name = "btnUpdateTask";
            this.btnUpdateTask.Size = new System.Drawing.Size(159, 30);
            this.btnUpdateTask.TabIndex = 4;
            this.btnUpdateTask.Text = "Update Task";
            this.btnUpdateTask.UseVisualStyleBackColor = false;
            this.btnUpdateTask.Click += new System.EventHandler(this.btnUpdateTask_Click_1);
            // 
            // txtNewTaskName
            // 
            this.txtNewTaskName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtNewTaskName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNewTaskName.Font = new System.Drawing.Font("MV Boli", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewTaskName.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txtNewTaskName.Location = new System.Drawing.Point(28, 532);
            this.txtNewTaskName.Name = "txtNewTaskName";
            this.txtNewTaskName.Size = new System.Drawing.Size(205, 31);
            this.txtNewTaskName.TabIndex = 5;
            this.txtNewTaskName.Text = "Enter Task Name";
            this.txtNewTaskName.Validating += new System.ComponentModel.CancelEventHandler(this.txtNewTaskName_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // nudGetIndexToDelete
            // 
            this.nudGetIndexToDelete.AutoSize = true;
            this.nudGetIndexToDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.nudGetIndexToDelete.Font = new System.Drawing.Font("MV Boli", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudGetIndexToDelete.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.nudGetIndexToDelete.Location = new System.Drawing.Point(510, 538);
            this.nudGetIndexToDelete.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudGetIndexToDelete.Name = "nudGetIndexToDelete";
            this.nudGetIndexToDelete.Size = new System.Drawing.Size(70, 38);
            this.nudGetIndexToDelete.TabIndex = 6;
            this.nudGetIndexToDelete.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tstxtUpdateTask);
            this.panel1.Controls.Add(this.nudGetIndexToUpdate);
            this.panel1.Location = new System.Drawing.Point(806, 532);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 37);
            this.panel1.TabIndex = 7;
            // 
            // tstxtUpdateTask
            // 
            this.tstxtUpdateTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.tstxtUpdateTask.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tstxtUpdateTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tstxtUpdateTask.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.tstxtUpdateTask.Location = new System.Drawing.Point(3, 6);
            this.tstxtUpdateTask.Name = "tstxtUpdateTask";
            this.tstxtUpdateTask.Size = new System.Drawing.Size(239, 19);
            this.tstxtUpdateTask.TabIndex = 1;
            this.tstxtUpdateTask.Validating += new System.ComponentModel.CancelEventHandler(this.tstxtUpdateTask_Validating);
            // 
            // nudGetIndexToUpdate
            // 
            this.nudGetIndexToUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.nudGetIndexToUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudGetIndexToUpdate.Font = new System.Drawing.Font("Ink Free", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudGetIndexToUpdate.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.nudGetIndexToUpdate.Location = new System.Drawing.Point(248, 6);
            this.nudGetIndexToUpdate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudGetIndexToUpdate.Name = "nudGetIndexToUpdate";
            this.nudGetIndexToUpdate.Size = new System.Drawing.Size(57, 27);
            this.nudGetIndexToUpdate.TabIndex = 0;
            this.nudGetIndexToUpdate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Cyan;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(15)))), ((int)(((byte)(219)))));
            this.label2.Location = new System.Drawing.Point(411, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 29);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tasks Completion Progress";
            // 
            // lblProgresPrecentage
            // 
            this.lblProgresPrecentage.AutoSize = true;
            this.lblProgresPrecentage.Font = new System.Drawing.Font("Ink Free", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgresPrecentage.Location = new System.Drawing.Point(536, 85);
            this.lblProgresPrecentage.Name = "lblProgresPrecentage";
            this.lblProgresPrecentage.Size = new System.Drawing.Size(30, 23);
            this.lblProgresPrecentage.TabIndex = 9;
            this.lblProgresPrecentage.Text = "%";
            // 
            // pbTasksProgress
            // 
            this.pbTasksProgress.Location = new System.Drawing.Point(441, 63);
            this.pbTasksProgress.Name = "pbTasksProgress";
            this.pbTasksProgress.Size = new System.Drawing.Size(221, 10);
            this.pbTasksProgress.Step = 1;
            this.pbTasksProgress.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Cyan;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(15)))), ((int)(((byte)(219)))));
            this.label3.Location = new System.Drawing.Point(897, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 29);
            this.label3.TabIndex = 11;
            this.label3.Text = "Taskes Completed";
            // 
            // lblCompletedTTasks
            // 
            this.lblCompletedTTasks.AutoSize = true;
            this.lblCompletedTTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblCompletedTTasks.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompletedTTasks.ForeColor = System.Drawing.Color.Black;
            this.lblCompletedTTasks.Location = new System.Drawing.Point(854, 79);
            this.lblCompletedTTasks.Name = "lblCompletedTTasks";
            this.lblCompletedTTasks.Size = new System.Drawing.Size(281, 29);
            this.lblCompletedTTasks.TabIndex = 12;
            this.lblCompletedTTasks.Text = "Tasks Completion Progress";
            // 
            // frmTaskManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1147, 581);
            this.Controls.Add(this.lblCompletedTTasks);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbTasksProgress);
            this.Controls.Add(this.lblProgresPrecentage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.nudGetIndexToDelete);
            this.Controls.Add(this.txtNewTaskName);
            this.Controls.Add(this.btnUpdateTask);
            this.Controls.Add(this.btnDeleteTask);
            this.Controls.Add(this.btnAddNewTask);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clbTasks);
            this.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.Name = "frmTaskManager";
            this.Text = "Tasck Manager";
            this.Load += new System.EventHandler(this.frmTaskManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGetIndexToDelete)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGetIndexToUpdate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbTasks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddNewTask;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.Button btnUpdateTask;
        private System.Windows.Forms.TextBox txtNewTaskName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.NumericUpDown nudGetIndexToDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tstxtUpdateTask;
        private System.Windows.Forms.NumericUpDown nudGetIndexToUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pbTasksProgress;
        private System.Windows.Forms.Label lblProgresPrecentage;
        private System.Windows.Forms.Label lblCompletedTTasks;
        private System.Windows.Forms.Label label3;
    }
}