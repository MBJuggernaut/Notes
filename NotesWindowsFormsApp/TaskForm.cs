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
            newTask.IsActual = DateTime.Compare(newTask.Date, DateTime.Today) > 0 ||
                         DateTime.Compare(newTask.Date, DateTime.Today) == 0 && 
                         string.Compare(newTask.Time, DateTime.Now.ToString("HH:mm")) > 0;

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
    }
}
