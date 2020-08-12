namespace NotesWindowsFormsApp
{
    partial class AlertForm
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
            this.AlertMessageLabel = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AlertMessageLabel
            // 
            this.AlertMessageLabel.Location = new System.Drawing.Point(1, 0);
            this.AlertMessageLabel.Name = "AlertMessageLabel";
            this.AlertMessageLabel.Size = new System.Drawing.Size(314, 77);
            this.AlertMessageLabel.TabIndex = 0;
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(83, 80);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(137, 40);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // AlertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 132);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.AlertMessageLabel);
            this.Name = "AlertForm";
            this.Text = "AlertForm";
            this.Load += new System.EventHandler(this.AlertForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label AlertMessageLabel;
        private System.Windows.Forms.Button OkButton;
    }
}