namespace NotesWindowsFormsApp
{
    partial class TagsForm
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
            this.tagsDataGridView = new System.Windows.Forms.DataGridView();
            this.TagsFormText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagsFormDeleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.newTagTextBox = new System.Windows.Forms.TextBox();
            this.addTagButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tagsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tagsDataGridView
            // 
            this.tagsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tagsDataGridView.ColumnHeadersVisible = false;
            this.tagsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TagsFormText,
            this.TagsFormDeleteButton});
            this.tagsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.tagsDataGridView.MultiSelect = false;
            this.tagsDataGridView.Name = "tagsDataGridView";
            this.tagsDataGridView.ReadOnly = true;
            this.tagsDataGridView.RowHeadersVisible = false;
            this.tagsDataGridView.RowHeadersWidth = 51;
            this.tagsDataGridView.RowTemplate.Height = 24;
            this.tagsDataGridView.RowTemplate.ReadOnly = true;
            this.tagsDataGridView.Size = new System.Drawing.Size(349, 201);
            this.tagsDataGridView.TabIndex = 0;
            this.tagsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tagsDataGridView_CellContentClick);
            // 
            // TagsFormText
            // 
            this.TagsFormText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TagsFormText.HeaderText = "Text";
            this.TagsFormText.MinimumWidth = 6;
            this.TagsFormText.Name = "TagsFormText";
            this.TagsFormText.ReadOnly = true;
            // 
            // TagsFormDeleteButton
            // 
            this.TagsFormDeleteButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TagsFormDeleteButton.HeaderText = "Delete";
            this.TagsFormDeleteButton.MinimumWidth = 6;
            this.TagsFormDeleteButton.Name = "TagsFormDeleteButton";
            this.TagsFormDeleteButton.ReadOnly = true;
            this.TagsFormDeleteButton.Text = "Удалить";
            this.TagsFormDeleteButton.UseColumnTextForButtonValue = true;
            this.TagsFormDeleteButton.Width = 60;
            // 
            // newTagTextBox
            // 
            this.newTagTextBox.Location = new System.Drawing.Point(12, 219);
            this.newTagTextBox.Name = "newTagTextBox";
            this.newTagTextBox.Size = new System.Drawing.Size(187, 22);
            this.newTagTextBox.TabIndex = 1;
            this.newTagTextBox.Text = "Введите текст своего тэга";
            this.newTagTextBox.Click += new System.EventHandler(this.newTagTextBox_Click);
            // 
            // addTagButton
            // 
            this.addTagButton.Location = new System.Drawing.Point(224, 207);
            this.addTagButton.Name = "addTagButton";
            this.addTagButton.Size = new System.Drawing.Size(105, 46);
            this.addTagButton.TabIndex = 2;
            this.addTagButton.Text = "Добавить";
            this.addTagButton.UseVisualStyleBackColor = true;
            this.addTagButton.Click += new System.EventHandler(this.addTagButton_Click);
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(142, 303);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // TagsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(352, 355);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.addTagButton);
            this.Controls.Add(this.newTagTextBox);
            this.Controls.Add(this.tagsDataGridView);
            this.Name = "TagsForm";
            this.Text = "TagsForm";
            this.Load += new System.EventHandler(this.TagsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tagsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView tagsDataGridView;
        private System.Windows.Forms.TextBox newTagTextBox;
        private System.Windows.Forms.Button addTagButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagsFormText;
        private System.Windows.Forms.DataGridViewButtonColumn TagsFormDeleteButton;
        private System.Windows.Forms.Button okButton;
    }
}