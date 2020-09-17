﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NotesWindowsFormsApp
{
    public partial class TaskForm : Form
    {
        public Task newTask = new Task();
        public List<Tag> tags=new List<Tag>();
        public List<Tag> checkedTags = new List<Tag>();
        public TaskForm()
        {
            InitializeComponent();
            HoursComboBox.Text = "00";
            MinutesComboBox.Text = "00";
            alarmingComboBox.Text = alarmingComboBox.Items[0].ToString();
            repeatingComboBox.Text = repeatingComboBox.Items[0].ToString();
        }
        private void TaskForm_Load(object sender, EventArgs e)
        {
            //using (TaskDatabaseRepository taskManager = new TaskDatabaseRepository())
            //{
            //    tags = context.Ta
            //    context.Tags.Add(new Tag { Text = newTagTextBox.Text });
            //    context.SaveChanges();
            //}
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
            newTask.NextDate = TaskDateTimePicker.Value.Date;
            newTask.Repeating = repeatingComboBox.Text;
            newTask.Alarming = alarmingComboBox.Text;          

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
    }
}
