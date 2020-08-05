namespace NotesWindowsFormsApp
{
    partial class TaskForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskForm));
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelFormButton = new System.Windows.Forms.Button();
            this.CommentTextBox = new System.Windows.Forms.TextBox();
            this.HoursComboBox = new System.Windows.Forms.ComboBox();
            this.MinutesComboBox = new System.Windows.Forms.ComboBox();
            this.TaskDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(44, 365);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(62, 29);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelFormButton
            // 
            this.CancelFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelFormButton.Location = new System.Drawing.Point(164, 365);
            this.CancelFormButton.Name = "CancelFormButton";
            this.CancelFormButton.Size = new System.Drawing.Size(93, 29);
            this.CancelFormButton.TabIndex = 1;
            this.CancelFormButton.Text = "Отмена";
            this.CancelFormButton.UseVisualStyleBackColor = true;
            // 
            // CommentTextBox
            // 
            this.CommentTextBox.Location = new System.Drawing.Point(44, 227);
            this.CommentTextBox.Multiline = true;
            this.CommentTextBox.Name = "CommentTextBox";
            this.CommentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CommentTextBox.Size = new System.Drawing.Size(221, 89);
            this.CommentTextBox.TabIndex = 6;
            // 
            // HoursComboBox
            // 
            this.HoursComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HoursComboBox.FormattingEnabled = true;
            this.HoursComboBox.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            ""});
            this.HoursComboBox.Location = new System.Drawing.Point(44, 135);
            this.HoursComboBox.Name = "HoursComboBox";
            this.HoursComboBox.Size = new System.Drawing.Size(57, 24);
            this.HoursComboBox.TabIndex = 7;
            this.HoursComboBox.TabStop = false;
            // 
            // MinutesComboBox
            // 
            this.MinutesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MinutesComboBox.FormattingEnabled = true;
            this.MinutesComboBox.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.MinutesComboBox.Location = new System.Drawing.Point(130, 135);
            this.MinutesComboBox.Name = "MinutesComboBox";
            this.MinutesComboBox.Size = new System.Drawing.Size(54, 24);
            this.MinutesComboBox.TabIndex = 8;
            this.MinutesComboBox.TabStop = false;
            // 
            // TaskDateTimePicker
            // 
            this.TaskDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.TaskDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TaskDateTimePicker.Location = new System.Drawing.Point(44, 58);
            this.TaskDateTimePicker.Name = "TaskDateTimePicker";
            this.TaskDateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.TaskDateTimePicker.TabIndex = 9;
            // 
            // TaskForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 450);
            this.Controls.Add(this.TaskDateTimePicker);
            this.Controls.Add(this.MinutesComboBox);
            this.Controls.Add(this.HoursComboBox);
            this.Controls.Add(this.CommentTextBox);
            this.Controls.Add(this.CancelFormButton);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskForm";
            this.Text = "Задача";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelFormButton;
        public System.Windows.Forms.TextBox CommentTextBox;
        public System.Windows.Forms.ComboBox HoursComboBox;
        public System.Windows.Forms.ComboBox MinutesComboBox;
        public System.Windows.Forms.DateTimePicker TaskDateTimePicker;
    }
}