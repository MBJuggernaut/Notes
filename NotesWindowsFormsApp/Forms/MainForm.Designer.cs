namespace NotesWindowsFormsApp.Forms
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
            this.tasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weatherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notesPanel = new System.Windows.Forms.Panel();
            this.notesRichTextBox = new System.Windows.Forms.RichTextBox();
            this.todolistPanel = new System.Windows.Forms.Panel();
            this.thisisTasksForTheDayLabel = new System.Windows.Forms.Label();
            this.addTaskButton = new System.Windows.Forms.Button();
            this.tasksForDayDataGridView = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TextColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tasksContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myCalendar = new System.Windows.Forms.MonthCalendar();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.weatherPanel = new System.Windows.Forms.Panel();
            this.weatherErrorLabel = new System.Windows.Forms.Label();
            this.feelslikeLabel = new System.Windows.Forms.Label();
            this.weatherPictureBox = new System.Windows.Forms.PictureBox();
            this.cloudsLabel = new System.Windows.Forms.Label();
            this.temperatureLabel = new System.Windows.Forms.Label();
            this.weatherTimer = new System.Windows.Forms.Timer(this.components);
            this.midnightTimer = new System.Windows.Forms.Timer(this.components);
            this.everyMinuteTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.notesPanel.SuspendLayout();
            this.todolistPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tasksForDayDataGridView)).BeginInit();
            this.tasksContextMenuStrip.SuspendLayout();
            this.weatherPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weatherPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notesToolStripMenuItem,
            this.tasksToolStripMenuItem,
            this.weatherToolStripMenuItem,
            this.тестToolStripMenuItem});
            this.menuStrip.Name = "menuStrip";
            // 
            // notesToolStripMenuItem
            // 
            this.notesToolStripMenuItem.Name = "notesToolStripMenuItem";
            resources.ApplyResources(this.notesToolStripMenuItem, "notesToolStripMenuItem");
            this.notesToolStripMenuItem.Click += new System.EventHandler(this.NotesToolStripMenuItem_Click);
            // 
            // tasksToolStripMenuItem
            // 
            this.tasksToolStripMenuItem.Name = "tasksToolStripMenuItem";
            resources.ApplyResources(this.tasksToolStripMenuItem, "tasksToolStripMenuItem");
            this.tasksToolStripMenuItem.Click += new System.EventHandler(this.TasksToolStripMenuItem_Click);
            // 
            // weatherToolStripMenuItem
            // 
            this.weatherToolStripMenuItem.Name = "weatherToolStripMenuItem";
            resources.ApplyResources(this.weatherToolStripMenuItem, "weatherToolStripMenuItem");
            this.weatherToolStripMenuItem.Click += new System.EventHandler(this.WeatherToolStripMenuItem_Click);
            // 
            // тестToolStripMenuItem
            // 
            this.тестToolStripMenuItem.Name = "тестToolStripMenuItem";
            resources.ApplyResources(this.тестToolStripMenuItem, "тестToolStripMenuItem");
            this.тестToolStripMenuItem.Click += new System.EventHandler(this.ТестToolStripMenuItem_Click);
            // 
            // notesPanel
            // 
            this.notesPanel.Controls.Add(this.notesRichTextBox);
            resources.ApplyResources(this.notesPanel, "notesPanel");
            this.notesPanel.Name = "notesPanel";
            // 
            // notesRichTextBox
            // 
            this.notesRichTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.notesRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.notesRichTextBox, "notesRichTextBox");
            this.notesRichTextBox.Name = "notesRichTextBox";
            this.notesRichTextBox.Leave += new System.EventHandler(this.NotesRichTextBox_Leave);
            // 
            // todolistPanel
            // 
            this.todolistPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.todolistPanel.Controls.Add(this.thisisTasksForTheDayLabel);
            this.todolistPanel.Controls.Add(this.addTaskButton);
            this.todolistPanel.Controls.Add(this.tasksForDayDataGridView);
            this.todolistPanel.Controls.Add(this.myCalendar);
            resources.ApplyResources(this.todolistPanel, "todolistPanel");
            this.todolistPanel.Name = "todolistPanel";
            // 
            // thisisTasksForTheDayLabel
            // 
            resources.ApplyResources(this.thisisTasksForTheDayLabel, "thisisTasksForTheDayLabel");
            this.thisisTasksForTheDayLabel.Name = "thisisTasksForTheDayLabel";
            // 
            // addTaskButton
            // 
            resources.ApplyResources(this.addTaskButton, "addTaskButton");
            this.addTaskButton.Name = "addTaskButton";
            this.addTaskButton.UseVisualStyleBackColor = true;
            this.addTaskButton.Click += new System.EventHandler(this.AddTaskButton_Click);
            // 
            // tasksForDayDataGridView
            // 
            this.tasksForDayDataGridView.AllowUserToAddRows = false;
            this.tasksForDayDataGridView.AllowUserToResizeColumns = false;
            this.tasksForDayDataGridView.AllowUserToResizeRows = false;
            this.tasksForDayDataGridView.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.tasksForDayDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tasksForDayDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.tasksForDayDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasksForDayDataGridView.ColumnHeadersVisible = false;
            this.tasksForDayDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.TimeColumn,
            this.TextColumn});
            this.tasksForDayDataGridView.ContextMenuStrip = this.tasksContextMenuStrip;
            this.tasksForDayDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.tasksForDayDataGridView.GridColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.tasksForDayDataGridView, "tasksForDayDataGridView");
            this.tasksForDayDataGridView.MultiSelect = false;
            this.tasksForDayDataGridView.Name = "tasksForDayDataGridView";
            this.tasksForDayDataGridView.ReadOnly = true;
            this.tasksForDayDataGridView.RowHeadersVisible = false;
            this.tasksForDayDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            this.tasksForDayDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tasksForDayDataGridView.RowTemplate.Height = 24;
            this.tasksForDayDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tasksForDayDataGridView.ShowCellErrors = false;
            this.tasksForDayDataGridView.ShowCellToolTips = false;
            this.tasksForDayDataGridView.ShowEditingIcon = false;
            this.tasksForDayDataGridView.ShowRowErrors = false;
            this.tasksForDayDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TasksForDayDataGridView_MouseDown);
            // 
            // IdColumn
            // 
            resources.ApplyResources(this.IdColumn, "IdColumn");
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            // 
            // TimeColumn
            // 
            resources.ApplyResources(this.TimeColumn, "TimeColumn");
            this.TimeColumn.Name = "TimeColumn";
            this.TimeColumn.ReadOnly = true;
            // 
            // TextColumn
            // 
            resources.ApplyResources(this.TextColumn, "TextColumn");
            this.TextColumn.Name = "TextColumn";
            this.TextColumn.ReadOnly = true;
            // 
            // tasksContextMenuStrip
            // 
            this.tasksContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tasksContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.tasksContextMenuStrip.Name = "TasksContextMenuStrip";
            resources.ApplyResources(this.tasksContextMenuStrip, "tasksContextMenuStrip");
            this.tasksContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.TasksContextMenuStrip_Opening);
            // 
            // changeToolStripMenuItem
            // 
            this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            resources.ApplyResources(this.changeToolStripMenuItem, "changeToolStripMenuItem");
            this.changeToolStripMenuItem.Click += new System.EventHandler(this.ChangeToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
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
            // weatherPanel
            // 
            this.weatherPanel.Controls.Add(this.weatherErrorLabel);
            this.weatherPanel.Controls.Add(this.feelslikeLabel);
            this.weatherPanel.Controls.Add(this.weatherPictureBox);
            this.weatherPanel.Controls.Add(this.cloudsLabel);
            this.weatherPanel.Controls.Add(this.temperatureLabel);
            resources.ApplyResources(this.weatherPanel, "weatherPanel");
            this.weatherPanel.Name = "weatherPanel";
            // 
            // weatherErrorLabel
            // 
            resources.ApplyResources(this.weatherErrorLabel, "weatherErrorLabel");
            this.weatherErrorLabel.Name = "weatherErrorLabel";
            // 
            // feelslikeLabel
            // 
            resources.ApplyResources(this.feelslikeLabel, "feelslikeLabel");
            this.feelslikeLabel.Name = "feelslikeLabel";
            // 
            // weatherPictureBox
            // 
            resources.ApplyResources(this.weatherPictureBox, "weatherPictureBox");
            this.weatherPictureBox.Name = "weatherPictureBox";
            this.weatherPictureBox.TabStop = false;
            // 
            // cloudsLabel
            // 
            resources.ApplyResources(this.cloudsLabel, "cloudsLabel");
            this.cloudsLabel.Name = "cloudsLabel";
            // 
            // temperatureLabel
            // 
            resources.ApplyResources(this.temperatureLabel, "temperatureLabel");
            this.temperatureLabel.Name = "temperatureLabel";
            // 
            // weatherTimer
            // 
            this.weatherTimer.Enabled = true;
            this.weatherTimer.Interval = 900000;
            this.weatherTimer.Tick += new System.EventHandler(this.WeatherTimer_Tick);
            // 
            // midnightTimer
            // 
            this.midnightTimer.Enabled = true;
            this.midnightTimer.Tick += new System.EventHandler(this.MidnightTimer_Tick);
            // 
            // everyMinuteTimer
            // 
            this.everyMinuteTimer.Enabled = true;
            this.everyMinuteTimer.Tick += new System.EventHandler(this.EveryMinuteTimer_Tick);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.weatherPanel);
            this.Controls.Add(this.todolistPanel);
            this.Controls.Add(this.notesPanel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.notesPanel.ResumeLayout(false);
            this.todolistPanel.ResumeLayout(false);
            this.todolistPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tasksForDayDataGridView)).EndInit();
            this.tasksContextMenuStrip.ResumeLayout(false);
            this.weatherPanel.ResumeLayout(false);
            this.weatherPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weatherPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem notesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tasksToolStripMenuItem;
        private System.Windows.Forms.Panel notesPanel;
        private System.Windows.Forms.Panel todolistPanel;
        private System.Windows.Forms.MonthCalendar myCalendar;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Button addTaskButton;
        private System.Windows.Forms.ContextMenuStrip tasksContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem changeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Timer everyMinuteTimer;
        private System.Windows.Forms.Label thisisTasksForTheDayLabel;
        private System.Windows.Forms.RichTextBox notesRichTextBox;
        private System.Windows.Forms.ToolStripMenuItem тестToolStripMenuItem;
        private System.Windows.Forms.DataGridView tasksForDayDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn task;
        private System.Windows.Forms.Panel weatherPanel;
        private System.Windows.Forms.Label temperatureLabel;
        private System.Windows.Forms.Label cloudsLabel;
        private System.Windows.Forms.PictureBox weatherPictureBox;
        private System.Windows.Forms.Label feelslikeLabel;
        private System.Windows.Forms.ToolStripMenuItem weatherToolStripMenuItem;
        private System.Windows.Forms.Timer weatherTimer;
        private System.Windows.Forms.Label weatherErrorLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TextColumn;
        private System.Windows.Forms.Timer midnightTimer;
    }
}

