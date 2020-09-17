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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelFormButton = new System.Windows.Forms.Button();
            this.CommentTextBox = new System.Windows.Forms.TextBox();
            this.HoursComboBox = new System.Windows.Forms.ComboBox();
            this.MinutesComboBox = new System.Windows.Forms.ComboBox();
            this.TaskDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.thisisDateChooseLabel = new System.Windows.Forms.Label();
            this.thisisTimeLabel = new System.Windows.Forms.Label();
            this.thisisCommentLabel = new System.Windows.Forms.Label();
            this.tagsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.alarmingComboBox = new System.Windows.Forms.ComboBox();
            this.thisisAlertLabel = new System.Windows.Forms.Label();
            this.addTagButton = new System.Windows.Forms.Button();
            this.repeatingComboBox = new System.Windows.Forms.ComboBox();
            this.thisIsRepeatingLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(44, 396);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(62, 29);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelFormButton
            // 
            this.cancelFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelFormButton.Location = new System.Drawing.Point(164, 396);
            this.cancelFormButton.Name = "cancelFormButton";
            this.cancelFormButton.Size = new System.Drawing.Size(93, 29);
            this.cancelFormButton.TabIndex = 1;
            this.cancelFormButton.Text = "Отмена";
            this.cancelFormButton.UseVisualStyleBackColor = true;
            // 
            // CommentTextBox
            // 
            this.CommentTextBox.Location = new System.Drawing.Point(22, 230);
            this.CommentTextBox.Multiline = true;
            this.CommentTextBox.Name = "CommentTextBox";
            this.CommentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CommentTextBox.Size = new System.Drawing.Size(243, 89);
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
            this.HoursComboBox.Location = new System.Drawing.Point(22, 140);
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
            this.MinutesComboBox.Location = new System.Drawing.Point(85, 140);
            this.MinutesComboBox.Name = "MinutesComboBox";
            this.MinutesComboBox.Size = new System.Drawing.Size(54, 24);
            this.MinutesComboBox.TabIndex = 8;
            this.MinutesComboBox.TabStop = false;
            // 
            // TaskDateTimePicker
            // 
            this.TaskDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.TaskDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TaskDateTimePicker.Location = new System.Drawing.Point(22, 58);
            this.TaskDateTimePicker.Name = "TaskDateTimePicker";
            this.TaskDateTimePicker.Size = new System.Drawing.Size(135, 22);
            this.TaskDateTimePicker.TabIndex = 9;
            // 
            // thisisDateChooseLabel
            // 
            this.thisisDateChooseLabel.AutoSize = true;
            this.thisisDateChooseLabel.Location = new System.Drawing.Point(19, 26);
            this.thisisDateChooseLabel.Name = "thisisDateChooseLabel";
            this.thisisDateChooseLabel.Size = new System.Drawing.Size(106, 17);
            this.thisisDateChooseLabel.TabIndex = 10;
            this.thisisDateChooseLabel.Text = "Дата события:";
            // 
            // thisisTimeLabel
            // 
            this.thisisTimeLabel.AutoSize = true;
            this.thisisTimeLabel.Location = new System.Drawing.Point(19, 105);
            this.thisisTimeLabel.Name = "thisisTimeLabel";
            this.thisisTimeLabel.Size = new System.Drawing.Size(106, 17);
            this.thisisTimeLabel.TabIndex = 11;
            this.thisisTimeLabel.Text = "Время начала:";
            // 
            // thisisCommentLabel
            // 
            this.thisisCommentLabel.AutoSize = true;
            this.thisisCommentLabel.Location = new System.Drawing.Point(19, 199);
            this.thisisCommentLabel.Name = "thisisCommentLabel";
            this.thisisCommentLabel.Size = new System.Drawing.Size(134, 17);
            this.thisisCommentLabel.TabIndex = 12;
            this.thisisCommentLabel.Text = "Краткое описание:";
            // 
            // tagsCheckedListBox
            // 
            this.tagsCheckedListBox.FormattingEnabled = true;
            this.tagsCheckedListBox.Location = new System.Drawing.Point(297, 230);
            this.tagsCheckedListBox.Name = "tagsCheckedListBox";
            this.tagsCheckedListBox.Size = new System.Drawing.Size(162, 89);
            this.tagsCheckedListBox.TabIndex = 13;
            // 
            // alarmingComboBox
            // 
            this.alarmingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.alarmingComboBox.FormattingEnabled = true;
            this.alarmingComboBox.Items.AddRange(new object[] {
            "В момент начала",
            "5 мин.",
            "15 мин.",
            "30 мин.",
            "1 час",
            "1 день",
            "1 неделя",
            "Не напоминать"});
            this.alarmingComboBox.Location = new System.Drawing.Point(297, 140);
            this.alarmingComboBox.Name = "alarmingComboBox";
            this.alarmingComboBox.Size = new System.Drawing.Size(162, 24);
            this.alarmingComboBox.TabIndex = 14;
            // 
            // thisisAlertLabel
            // 
            this.thisisAlertLabel.AutoSize = true;
            this.thisisAlertLabel.Location = new System.Drawing.Point(332, 105);
            this.thisisAlertLabel.Name = "thisisAlertLabel";
            this.thisisAlertLabel.Size = new System.Drawing.Size(93, 17);
            this.thisisAlertLabel.TabIndex = 15;
            this.thisisAlertLabel.Text = "Оповещение";
            // 
            // addTagButton
            // 
            this.addTagButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addTagButton.BackgroundImage")));
            this.addTagButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addTagButton.Location = new System.Drawing.Point(465, 252);
            this.addTagButton.Name = "addTagButton";
            this.addTagButton.Size = new System.Drawing.Size(39, 37);
            this.addTagButton.TabIndex = 16;
            this.addTagButton.UseVisualStyleBackColor = true;
            this.addTagButton.Click += new System.EventHandler(this.AddTagButton_Click);
            // 
            // repeatingComboBox
            // 
            this.repeatingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.repeatingComboBox.FormattingEnabled = true;
            this.repeatingComboBox.Items.AddRange(new object[] {
            "Один раз",
            "Каждый день",
            "Каждую неделю",
            "Каждый месяц",
            "Каждый год"});
            this.repeatingComboBox.Location = new System.Drawing.Point(297, 58);
            this.repeatingComboBox.Name = "repeatingComboBox";
            this.repeatingComboBox.Size = new System.Drawing.Size(162, 24);
            this.repeatingComboBox.TabIndex = 17;
            // 
            // thisIsRepeatingLabel
            // 
            this.thisIsRepeatingLabel.AutoSize = true;
            this.thisIsRepeatingLabel.Location = new System.Drawing.Point(332, 26);
            this.thisIsRepeatingLabel.Name = "thisIsRepeatingLabel";
            this.thisIsRepeatingLabel.Size = new System.Drawing.Size(81, 17);
            this.thisIsRepeatingLabel.TabIndex = 18;
            this.thisIsRepeatingLabel.Text = "Напомнить";
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 450);
            this.Controls.Add(this.thisIsRepeatingLabel);
            this.Controls.Add(this.repeatingComboBox);
            this.Controls.Add(this.addTagButton);
            this.Controls.Add(this.thisisAlertLabel);
            this.Controls.Add(this.alarmingComboBox);
            this.Controls.Add(this.tagsCheckedListBox);
            this.Controls.Add(this.thisisCommentLabel);
            this.Controls.Add(this.thisisTimeLabel);
            this.Controls.Add(this.thisisDateChooseLabel);
            this.Controls.Add(this.TaskDateTimePicker);
            this.Controls.Add(this.MinutesComboBox);
            this.Controls.Add(this.HoursComboBox);
            this.Controls.Add(this.CommentTextBox);
            this.Controls.Add(this.cancelFormButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskForm";
            this.Text = "Задача";
            this.Load += new System.EventHandler(this.TaskForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelFormButton;
        public System.Windows.Forms.TextBox CommentTextBox;
        public System.Windows.Forms.ComboBox HoursComboBox;
        public System.Windows.Forms.ComboBox MinutesComboBox;
        public System.Windows.Forms.DateTimePicker TaskDateTimePicker;
        private System.Windows.Forms.Label thisisDateChooseLabel;
        private System.Windows.Forms.Label thisisTimeLabel;
        private System.Windows.Forms.Label thisisCommentLabel;
        private System.Windows.Forms.CheckedListBox tagsCheckedListBox;
        public System.Windows.Forms.ComboBox alarmingComboBox;
        private System.Windows.Forms.Label thisisAlertLabel;
        private System.Windows.Forms.Button addTagButton;
        public System.Windows.Forms.ComboBox repeatingComboBox;
        private System.Windows.Forms.Label thisIsRepeatingLabel;
    }
}