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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.notesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todolistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notesPanel = new System.Windows.Forms.Panel();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.todolistPanel = new System.Windows.Forms.Panel();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip.SuspendLayout();
            this.notesPanel.SuspendLayout();
            this.todolistPanel.SuspendLayout();
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
            this.notesToolStripMenuItem.Click += new System.EventHandler(this.notesToolStripMenuItem_Click);
            // 
            // todolistToolStripMenuItem
            // 
            this.todolistToolStripMenuItem.Name = "todolistToolStripMenuItem";
            resources.ApplyResources(this.todolistToolStripMenuItem, "todolistToolStripMenuItem");
            this.todolistToolStripMenuItem.Click += new System.EventHandler(this.todolistToolStripMenuItem_Click);
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
            this.notesTextBox.TextChanged += new System.EventHandler(this.notesTextBox_TextChanged);
            // 
            // todolistPanel
            // 
            this.todolistPanel.Controls.Add(this.monthCalendar1);
            this.todolistPanel.Controls.Add(this.label1);
            resources.ApplyResources(this.todolistPanel, "todolistPanel");
            this.todolistPanel.Name = "todolistPanel";
            // 
            // monthCalendar1
            // 
            resources.ApplyResources(this.monthCalendar1, "monthCalendar1");
            this.monthCalendar1.Name = "monthCalendar1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            resources.ApplyResources(this.trayIcon, "trayIcon");
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.todolistPanel);
            this.Controls.Add(this.notesPanel);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
            this.todolistPanel.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.NotifyIcon trayIcon;
    }
}

