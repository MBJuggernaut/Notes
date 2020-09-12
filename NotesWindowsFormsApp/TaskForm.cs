using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NotesWindowsFormsApp
{
    public partial class TaskForm : Form
    {
        public Task newTask = new Task();
        public List<Tags> tags;
        public List<Tags> checkedTags = new List<Tags>();
        public TaskForm()
        {
            InitializeComponent();
            HoursComboBox.Text = "00";
            MinutesComboBox.Text = "00";
            alertTimeOptionComboBox.Text = "В момент начала";
        }
        private void TaskForm_Load(object sender, EventArgs e)
        {
            foreach (var tag in tags)
            {
                tagsCheckedListBox.Items.Add(tag.Text);
            }            
            foreach(var tag in checkedTags)
            {
                int index = tags.FindIndex(t=>t==tag);

                tagsCheckedListBox.SetItemCheckState(index, CheckState.Checked);
            }            
        }
        private void OkButton_Click(object sender, EventArgs e)
        {

            newTask.Time = HoursComboBox.Text + ":" + MinutesComboBox.Text;
            newTask.Text = CommentTextBox.Text;
            newTask.Date = TaskDateTimePicker.Value.Date;           

            var errors = Validation.Check(newTask);

            if (errors.Count == 0)
            {

                for (int i = tagsCheckedListBox.Items.Count-1; i >= 0; i--)
                {
                    if (tagsCheckedListBox.GetItemCheckState(i) != CheckState.Checked)
                    {
                        tags.RemoveAt(i);
                    }
                }
                newTask.Tags = tags;

                DateTime timeOfAlarm = newTask.Date.Add(DateTime.Parse(newTask.Time).TimeOfDay);
                switch (alertTimeOptionComboBox.Text)
                {
                    case "В момент начала":
                        newTask.AlarmTime = timeOfAlarm;
                        break;
                    case "5 мин.":
                        newTask.AlarmTime = timeOfAlarm.AddMinutes(-5);
                        break;
                    case "15 мин.":
                        newTask.AlarmTime = timeOfAlarm.AddMinutes(-15);
                        break;
                    case "30 мин.":
                        newTask.AlarmTime = timeOfAlarm.AddMinutes(-30);
                        break;
                    case "1 час":
                        newTask.AlarmTime = timeOfAlarm.AddHours(-1);
                        break;
                    case "1 день":
                        newTask.AlarmTime = timeOfAlarm.AddDays(-1);
                        break;
                    case "1 неделя":
                        newTask.AlarmTime = timeOfAlarm.AddDays(-7);
                        break;
                    case "Не напоминать":
                        break;
                }

                newTask.IsActual = DateTime.Compare(newTask.Date, DateTime.Today) > 0 ||
                         DateTime.Compare(newTask.Date, DateTime.Today) == 0 &&
                         string.Compare(newTask.Time, DateTime.Now.ToString("HH:mm")) > 0;

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                foreach (var error in errors)
                {
                    MessageBox.Show(error, "Что-то не так", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void addTagButton_Click(object sender, EventArgs e)
        {
            var tagsform = new TagsForm();

            foreach (var tag in tags)
            {
                tagsform.tagsDataGridView.Rows.Add(tag.Text);
            }
            if (tagsform.ShowDialog(this) == DialogResult.OK)
            {
                tagsCheckedListBox.Items.Clear();

                for (int i = 0; i< tagsform.tagsDataGridView.Rows.Count-1;i++)
                    tagsCheckedListBox.Items.Add(tagsform.tagsDataGridView.Rows[i].Cells[0].Value.ToString());                
            }
        }
    }
}
