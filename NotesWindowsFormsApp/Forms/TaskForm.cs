using NotesWindowsFormsApp.Models;
using NotesWindowsFormsApp.Repo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NotesWindowsFormsApp
{
    public partial class TaskForm : Form
    {
        public UserTask newTask;
        private List<Tag> tags;
        public List<Tag> checkedTags;
        readonly ITagRepository tagManager;
        public TaskForm(ITagRepository tagDatabaseRepository)
        {
            InitializeComponent();

            tagManager = tagDatabaseRepository;
            newTask = new UserTask()
            {
                Time = "00:00",
                Repeating = "Один раз",
                Alarming = "00 мин."
            };
            Set();
        }
        public TaskForm(ITagRepository tagDatabaseRepository, UserTask task)
        {
            InitializeComponent();
            tagManager = tagDatabaseRepository;
            newTask = task;
            Set();
        }
        private void TaskForm_Load(object sender, EventArgs e)
        {
            ShowAllTags();
            checkedTags = newTask.Tags;
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

            var errors = newTask.Validate();
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
            var tagsform = new TagsForm(tagManager);

            tagsform.ShowDialog(this);

            tagsCheckedListBox.Items.Clear();
            ShowAllTags();
        }
        private void TaskDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            newTask.FirstDate = TaskDateTimePicker.Value;
        }
        private void ShowAllTags()
        {

            tags = tagManager.GetAll();
            foreach (var tag in tags)
            {
                tagsCheckedListBox.Items.Add(tag.Text);
            }
        }
        private void Set()
        {
            var time = newTask.Time.Split(':');
            HoursComboBox.Text = time[0];
            MinutesComboBox.Text = time[1];
            CommentTextBox.Text = newTask.Text;
            repeatingComboBox.Text = newTask.Repeating;
            var alarmingParts = newTask.Alarming.Split(' ');
            var count = alarmingParts[0];
            var span = alarmingParts[1];
            alertCountTextBox.Text = count;
            alertSpanComboBox.Text = span;
        }



    }
}
