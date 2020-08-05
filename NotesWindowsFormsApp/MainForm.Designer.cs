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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.notesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notesPanel = new System.Windows.Forms.Panel();
            this.todolistPanel = new System.Windows.Forms.Panel();
            this.AddTaskButton = new System.Windows.Forms.Button();
            this.TasksForDayDataGridView = new System.Windows.Forms.DataGridView();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TasksContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ChangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myCalendar = new System.Windows.Forms.MonthCalendar();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.EverySecondTimer = new System.Windows.Forms.Timer(this.components);
            this.thisisTasksForTheDayLabel = new System.Windows.Forms.Label();
            this.notesRichTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip.SuspendLayout();
            this.notesPanel.SuspendLayout();
            this.todolistPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TasksForDayDataGridView)).BeginInit();
            this.TasksContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notesToolStripMenuItem,
            this.TasksToolStripMenuItem});
            this.menuStrip.Name = "menuStrip";
            // 
            // notesToolStripMenuItem
            // 
            this.notesToolStripMenuItem.Name = "notesToolStripMenuItem";
            resources.ApplyResources(this.notesToolStripMenuItem, "notesToolStripMenuItem");
            this.notesToolStripMenuItem.Click += new System.EventHandler(this.NotesToolStripMenuItem_Click);
            // 
            // TasksToolStripMenuItem
            // 
            this.TasksToolStripMenuItem.Name = "TasksToolStripMenuItem";
            resources.ApplyResources(this.TasksToolStripMenuItem, "TasksToolStripMenuItem");
            this.TasksToolStripMenuItem.Click += new System.EventHandler(this.TasksToolStripMenuItem_Click);
            // 
            // notesPanel
            // 
            this.notesPanel.Controls.Add(this.notesRichTextBox);
            resources.ApplyResources(this.notesPanel, "notesPanel");
            this.notesPanel.Name = "notesPanel";
            // 
            // todolistPanel
            // 
            this.todolistPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.todolistPanel.Controls.Add(this.thisisTasksForTheDayLabel);
            this.todolistPanel.Controls.Add(this.AddTaskButton);
            this.todolistPanel.Controls.Add(this.TasksForDayDataGridView);
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
            // TasksForDayDataGridView
            // 
            this.TasksForDayDataGridView.AllowUserToOrderColumns = true;
            this.TasksForDayDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.TasksForDayDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.TasksForDayDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.TasksForDayDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TasksForDayDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TasksForDayDataGridView.ColumnHeadersVisible = false;
            this.TasksForDayDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time,
            this.Task});
            this.TasksForDayDataGridView.ContextMenuStrip = this.TasksContextMenuStrip;
            this.TasksForDayDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.TasksForDayDataGridView.GridColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.TasksForDayDataGridView, "TasksForDayDataGridView");
            this.TasksForDayDataGridView.MultiSelect = false;
            this.TasksForDayDataGridView.Name = "TasksForDayDataGridView";
            this.TasksForDayDataGridView.ReadOnly = true;
            this.TasksForDayDataGridView.RowHeadersVisible = false;
            this.TasksForDayDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            this.TasksForDayDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.TasksForDayDataGridView.RowTemplate.Height = 24;
            this.TasksForDayDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.TasksForDayDataGridView.ShowCellErrors = false;
            this.TasksForDayDataGridView.ShowCellToolTips = false;
            this.TasksForDayDataGridView.ShowEditingIcon = false;
            this.TasksForDayDataGridView.ShowRowErrors = false;
            this.TasksForDayDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TasksForDayDataGridView_CellDoubleClick);
            this.TasksForDayDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TasksForDayDataGridView_MouseDown);
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
            this.Task.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // TasksContextMenuStrip
            // 
            this.TasksContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TasksContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeToolStripMenuItem,
            this.DeleteToolStripMenuItem});
            this.TasksContextMenuStrip.Name = "TasksContextMenuStrip";
            resources.ApplyResources(this.TasksContextMenuStrip, "TasksContextMenuStrip");
            this.TasksContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.TasksContextMenuStrip_Opening);
            // 
            // ChangeToolStripMenuItem
            // 
            this.ChangeToolStripMenuItem.Name = "ChangeToolStripMenuItem";
            resources.ApplyResources(this.ChangeToolStripMenuItem, "ChangeToolStripMenuItem");
            this.ChangeToolStripMenuItem.Click += new System.EventHandler(this.ChangeToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            resources.ApplyResources(this.DeleteToolStripMenuItem, "DeleteToolStripMenuItem");
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
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
            // EverySecondTimer
            // 
            this.EverySecondTimer.Enabled = true;
            this.EverySecondTimer.Interval = 1000;
            this.EverySecondTimer.Tick += new System.EventHandler(this.EverySecondTimer_Tick);
            // 
            // thisisTasksForTheDayLabel
            // 
            resources.ApplyResources(this.thisisTasksForTheDayLabel, "thisisTasksForTheDayLabel");
            this.thisisTasksForTheDayLabel.Name = "thisisTasksForTheDayLabel";
            // 
            // notesRichTextBox
            // 
            this.notesRichTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.notesRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.notesRichTextBox, "notesRichTextBox");
            this.notesRichTextBox.Name = "notesRichTextBox";
            this.notesRichTextBox.TextChanged += new System.EventHandler(this.notesRichTextBox_TextChanged);
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
            this.todolistPanel.ResumeLayout(false);
            this.todolistPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TasksForDayDataGridView)).EndInit();
            this.TasksContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem notesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TasksToolStripMenuItem;
        private System.Windows.Forms.Panel notesPanel;
        private System.Windows.Forms.Panel todolistPanel;
        private System.Windows.Forms.MonthCalendar myCalendar;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Button AddTaskButton;
        private System.Windows.Forms.DataGridView TasksForDayDataGridView;
        private System.Windows.Forms.ContextMenuStrip TasksContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ChangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task;
        private System.Windows.Forms.Timer EverySecondTimer;
        private System.Windows.Forms.Label thisisTasksForTheDayLabel;
        private System.Windows.Forms.RichTextBox notesRichTextBox;
    }
}

