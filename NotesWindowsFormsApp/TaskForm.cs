using System;
using System.Windows.Forms;

namespace NotesWindowsFormsApp
{
    public partial class TaskForm : Form
    {
        public TaskForm()
        {
            InitializeComponent();
            HoursComboBox.Text = "00";
            MinutesComboBox.Text = "00";
            CommentTextBox.Text = "";
        }

        private void OkButton_Click(object sender, EventArgs e)
        {         
            var newTask = new Task
            {
                Time = HoursComboBox.Text + ":" + MinutesComboBox.Text,
                Text = CommentTextBox.Text,
                Date = TaskDateTimePicker.Value.ToShortDateString()
            };
            var errors = Validation.CheckTask(newTask);

            if (errors.Count == 0)
                OkButton.DialogResult = DialogResult.OK;

            else
            {
                foreach (var error in errors)
                {
                    MessageBox.Show(error);
                }
            }
        }
    }
}
