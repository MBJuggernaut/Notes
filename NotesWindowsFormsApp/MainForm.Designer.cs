namespace NotesWindowsFormsApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.notesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todolistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notesPanel = new System.Windows.Forms.Panel();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.todolistPanel = new System.Windows.Forms.Panel();
            this.AddTaskButton = new System.Windows.Forms.Button();
            this.ToDoListDataGridView = new System.Windows.Forms.DataGridView();
            this.myCalendar = new System.Windows.Forms.MonthCalendar();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip.SuspendLayout();
            this.notesPanel.SuspendLayout();
            this.todolistPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToDoListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notesToolStripMenuItem,
            this.todolistToolStripMenuItem});
            this.menuStrip.Name = "menuStrip";
            // 
            // notesToolStripMenuItem
            // 
            this.notesToolStripMenuItem.Name = "notesToolStripMenuItem";
            resources.ApplyResources(this.notesToolStripMenuItem, "notesToolStripMenuItem");
            this.notesToolStripMenuItem.Click += new System.EventHandler(this.NotesToolStripMenuItem_Click);
            // 
            // todolistToolStripMenuItem
            // 
            this.todolistToolStripMenuItem.Name = "todolistToolStripMenuItem";
            resources.ApplyResources(this.todolistToolStripMenuItem, "todolistToolStripMenuItem");
            this.todolistToolStripMenuItem.Click += new System.EventHandler(this.TodolistToolStripMenuItem_Click);
            // 
            // notesPanel
            // 
            this.notesPanel.Controls.Add(this.notesTextBox);
            resources.ApplyResources(this.notesPanel, "notesPanel");
            this.notesPanel.Name = "notesPanel";
            // 
            // notesTextBox
            // 
            this.notesTextBox.BackColor = System.Drawing.SystemColors.Info;
            resources.ApplyResources(this.notesTextBox, "notesTextBox");
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.TabStop = false;
            this.notesTextBox.TextChanged += new System.EventHandler(this.NotesTextBox_TextChanged);
            // 
            // todolistPanel
            // 
            this.todolistPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.todolistPanel.Controls.Add(this.AddTaskButton);
            this.todolistPanel.Controls.Add(this.ToDoListDataGridView);
            this.todolistPanel.Controls.Add(this.myCalendar);
            resources.ApplyResources(this.todolistPanel, "todolistPanel");
            this.todolistPanel.Name = "todolistPanel";
            // 
            // AddTaskButton
            // 
            resources.ApplyResources(this.AddTaskButton, "AddTaskButton");
            this.AddTaskButton.Name = "AddTaskButton";
            this.AddTaskButton.UseVisualStyleBackColor = true;
            this.AddTaskButton.Click += new System.EventHandler(this.AddTaskButton_Click);
            // 
            // ToDoListDataGridView
            // 
            this.ToDoListDataGridView.AllowUserToOrderColumns = true;
            this.ToDoListDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ToDoListDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ToDoListDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ToDoListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ToDoListDataGridView.ColumnHeadersVisible = false;
            this.ToDoListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time,
            this.Task});
            resources.ApplyResources(this.ToDoListDataGridView, "ToDoListDataGridView");
            this.ToDoListDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.ToDoListDataGridView.GridColor = System.Drawing.SystemColors.Window;
            this.ToDoListDataGridView.MultiSelect = false;
            this.ToDoListDataGridView.Name = "ToDoListDataGridView";
            this.ToDoListDataGridView.ReadOnly = true;
            this.ToDoListDataGridView.RowHeadersVisible = false;
            this.ToDoListDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            this.ToDoListDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ToDoListDataGridView.RowTemplate.Height = 24;
            this.ToDoListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ToDoListDataGridView.ShowCellErrors = false;
            this.ToDoListDataGridView.ShowCellToolTips = false;
            this.ToDoListDataGridView.ShowEditingIcon = false;
            this.ToDoListDataGridView.ShowRowErrors = false;
            this.ToDoListDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ToDoListDataGridView_CellClick);
            // 
            // myCalendar
            // 
            this.myCalendar.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.myCalendar, "myCalendar");
            this.myCalendar.Name = "myCalendar";
            this.myCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.MyCalendar_DateSelected);
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            resources.ApplyResources(this.trayIcon, "trayIcon");
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
            // 
            // Time
            // 
            resources.ApplyResources(this.Time, "Time");
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            // 
            // Task
            // 
            resources.ApplyResources(this.Task, "Task");
            this.Task.Name = "Task";
            this.Task.ReadOnly = true;
            this.Task.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.todolistPanel);
            this.Controls.Add(this.notesPanel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.notesPanel.ResumeLayout(false);
            this.notesPanel.PerformLayout();
            this.todolistPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ToDoListDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem notesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todolistToolStripMenuItem;
        private System.Windows.Forms.Panel notesPanel;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.Panel todolistPanel;
        private System.Windows.Forms.MonthCalendar myCalendar;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Button AddTaskButton;
        private System.Windows.Forms.DataGridView ToDoListDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task;
    }
}

