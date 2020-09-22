using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NotesWindowsFormsApp
{
    public partial class TaskForm : Form
    {
        public Task newTask = new Task();
        public List<Tag> tags = new List<Tag>();
        public List<Tag> checkedTags = new List<Tag>();
        public TaskForm()
        {
            InitializeComponent();
            HoursComboBox.Text = "00";
            MinutesComboBox.Text = "00";           
            alertSpanComboBox.Text = alertSpanComboBox.Items[0].ToString();
            repeatingComboBox.Text = repeatingComboBox.Items[0].ToString();
        }
        private void TaskForm_Load(object sender, EventArgs e)
        {
            foreach (var tag in tags)
            {
                tagsCheckedListBox.Items.Add(tag.Text);
            }
            foreach (var tag in checkedTags)
            {
                int index = tags.FindIndex(t => t == tag);

                tagsCheckedListBox.SetItemCheckState(index, CheckState.Checked);
            }
        }
        private void OkButton_Click(object sender, EventArgs e)
        {

            newTask.Time = HoursComboBox.Text + ":" + MinutesComboBox.Text;
            newTask.Text = CommentTextBox.Text;
            newTask.Repeating = repeatingComboBox.Text;

            var alertCount = alertCountTextBox.Text;
            bool isNumber = int.TryParse(alertCount, out _);
            if (isNumber)
            {
                newTask.Alarming = alertCount + " " + alertSpanComboBox.Text;
            }
            else
                MessageBox.Show("В ячейке со сроком должны быть цифры", "Что-то не так", MessageBoxButtons.OK, MessageBoxIcon.Error);


            var errors = Validation.Check(newTask);

            if (errors.Count == 0)
            {

                for (int i = tagsCheckedListBox.Items.Count - 1; i >= 0; i--)
                {
                    if (tagsCheckedListBox.GetItemCheckState(i) != CheckState.Checked)
                    {
                        tags.RemoveAt(i);
                    }
                }
                newTask.Tags = tags;

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
        private void AddTagButton_Click(object sender, EventArgs e)
        {
            var tagsform = new TagsForm();

            using (TaskContext context = new TaskContext())
            {
                foreach (var tag in context.Tags)
                {
                    tagsform.tagsDataGridView.Rows.Add(tag.Text);
                }
            }
            tagsform.ShowDialog(this);

            tagsCheckedListBox.Items.Clear();
            using (var context = new TaskContext())
            {
                foreach (var t in context.Tags)
                {
                    tagsCheckedListBox.Items.Add(t.Text);
                }
            }
        }

        private void TaskDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            newTask.FirstDate = TaskDateTimePicker.Value;
        }
    }
}
