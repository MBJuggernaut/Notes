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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.notesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todolistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notesPanel = new System.Windows.Forms.Panel();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.todolistPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.notesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notesToolStripMenuItem,
            this.todolistToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(86, 450);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // notesToolStripMenuItem
            // 
            this.notesToolStripMenuItem.Name = "notesToolStripMenuItem";
            this.notesToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.notesToolStripMenuItem.Text = "Заметки";
            // 
            // todolistToolStripMenuItem
            // 
            this.todolistToolStripMenuItem.Name = "todolistToolStripMenuItem";
            this.todolistToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.todolistToolStripMenuItem.Text = "Задачи";
            // 
            // notesPanel
            // 
            this.notesPanel.Controls.Add(this.notesTextBox);
            this.notesPanel.Location = new System.Drawing.Point(136, 0);
            this.notesPanel.Name = "notesPanel";
            this.notesPanel.Size = new System.Drawing.Size(250, 190);
            this.notesPanel.TabIndex = 2;
            // 
            // notesTextBox
            // 
            this.notesTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.notesTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.notesTextBox.Location = new System.Drawing.Point(0, 0);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.notesTextBox.Size = new System.Drawing.Size(250, 77);
            this.notesTextBox.TabIndex = 2;
            this.notesTextBox.TabStop = false;
            this.notesTextBox.TextChanged += new System.EventHandler(this.notesTextBox_TextChanged);
            // 
            // todolistPanel
            // 
            this.todolistPanel.Location = new System.Drawing.Point(393, 0);
            this.todolistPanel.Name = "todolistPanel";
            this.todolistPanel.Size = new System.Drawing.Size(202, 190);
            this.todolistPanel.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.todolistPanel);
            this.Controls.Add(this.notesPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Notes";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.notesPanel.ResumeLayout(false);
            this.notesPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem notesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todolistToolStripMenuItem;
        private System.Windows.Forms.Panel notesPanel;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.Panel todolistPanel;
    }
}

