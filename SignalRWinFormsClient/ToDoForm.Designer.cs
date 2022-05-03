namespace SignalRWinFormsClient
{
	partial class ToDoForm
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
            this.lblUserName = new System.Windows.Forms.Label();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConnId = new System.Windows.Forms.TextBox();
            this.btnTasksAll = new System.Windows.Forms.Button();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnEditTask = new System.Windows.Forms.Button();
            this.btnTaskDelete = new System.Windows.Forms.Button();
            this.taskDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taskIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmployeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(14, 15);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(111, 15);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Ім\'я співробітника:";
            // 
            // disconnectButton
            // 
            this.disconnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.disconnectButton.Enabled = false;
            this.disconnectButton.Location = new System.Drawing.Point(629, 9);
            this.disconnectButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(88, 27);
            this.disconnectButton.TabIndex = 6;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "ConnId:";
            // 
            // txtConnId
            // 
            this.txtConnId.Location = new System.Drawing.Point(86, 49);
            this.txtConnId.Name = "txtConnId";
            this.txtConnId.Size = new System.Drawing.Size(297, 23);
            this.txtConnId.TabIndex = 8;
            // 
            // btnTasksAll
            // 
            this.btnTasksAll.Location = new System.Drawing.Point(479, 87);
            this.btnTasksAll.Name = "btnTasksAll";
            this.btnTasksAll.Size = new System.Drawing.Size(97, 23);
            this.btnTasksAll.TabIndex = 11;
            this.btnTasksAll.Text = "Всі задачі";
            this.btnTasksAll.UseVisualStyleBackColor = true;
            this.btnTasksAll.Click += new System.EventHandler(this.getTasks_Click);
            // 
            // dgvTasks
            // 
            this.dgvTasks.AutoGenerateColumns = false;
            this.dgvTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.taskIdDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.idEmployeeDataGridViewTextBoxColumn});
            this.dgvTasks.DataSource = this.taskDTOBindingSource;
            this.dgvTasks.Location = new System.Drawing.Point(14, 87);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.RowTemplate.Height = 25;
            this.dgvTasks.Size = new System.Drawing.Size(450, 147);
            this.dgvTasks.TabIndex = 12;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(132, 12);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.ReadOnly = true;
            this.txtEmployeeName.Size = new System.Drawing.Size(251, 23);
            this.txtEmployeeName.TabIndex = 15;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(479, 116);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(97, 25);
            this.btnAddTask.TabIndex = 16;
            this.btnAddTask.Text = "Додати";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // btnEditTask
            // 
            this.btnEditTask.Location = new System.Drawing.Point(479, 147);
            this.btnEditTask.Name = "btnEditTask";
            this.btnEditTask.Size = new System.Drawing.Size(97, 25);
            this.btnEditTask.TabIndex = 17;
            this.btnEditTask.Text = "Редагувати";
            this.btnEditTask.UseVisualStyleBackColor = true;
            this.btnEditTask.Click += new System.EventHandler(this.btnTaskEdit_Click);
            // 
            // btnTaskDelete
            // 
            this.btnTaskDelete.Location = new System.Drawing.Point(479, 178);
            this.btnTaskDelete.Name = "btnTaskDelete";
            this.btnTaskDelete.Size = new System.Drawing.Size(97, 25);
            this.btnTaskDelete.TabIndex = 18;
            this.btnTaskDelete.Text = "Видалити";
            this.btnTaskDelete.UseVisualStyleBackColor = true;
            this.btnTaskDelete.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // taskDTOBindingSource
            // 
            this.taskDTOBindingSource.DataSource = typeof(SignalRServer.Models.DB.TaskDTO);
            // 
            // taskIdDataGridViewTextBoxColumn
            // 
            this.taskIdDataGridViewTextBoxColumn.DataPropertyName = "TaskId";
            this.taskIdDataGridViewTextBoxColumn.HeaderText = "TaskId";
            this.taskIdDataGridViewTextBoxColumn.Name = "taskIdDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // idEmployeeDataGridViewTextBoxColumn
            // 
            this.idEmployeeDataGridViewTextBoxColumn.DataPropertyName = "IdEmployee";
            this.idEmployeeDataGridViewTextBoxColumn.HeaderText = "IdEmployee";
            this.idEmployeeDataGridViewTextBoxColumn.Name = "idEmployeeDataGridViewTextBoxColumn";
            this.idEmployeeDataGridViewTextBoxColumn.Visible = false;
            // 
            // ToDoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 273);
            this.Controls.Add(this.btnTaskDelete);
            this.Controls.Add(this.btnEditTask);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.dgvTasks);
            this.Controls.Add(this.btnTasksAll);
            this.Controls.Add(this.txtConnId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.lblUserName);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ToDoForm";
            this.Text = "SignalR ToDo Task";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ToDoForm_FormClosed);
            this.Load += new System.EventHandler(this.ToDo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskDTOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lblUserName;
		private System.Windows.Forms.Button disconnectButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtConnId;
        private System.Windows.Forms.Button btnTasksAll;
        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnEditTask;
        private System.Windows.Forms.Button btnTaskDelete;
        private System.Windows.Forms.BindingSource taskDTOBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmployeeDataGridViewTextBoxColumn;
    }
}

