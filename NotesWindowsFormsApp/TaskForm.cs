using System;
using System.Windows.Forms;

namespace NotesWindowsFormsApp
{
    public partial class TaskForm : Form
    {
        public TaskForm()
        {
            InitializeComponent();            
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (CommentTextBox.Text.Length < 3 || CommentTextBox.Text.Length > 50)
            {
                MessageBox.Show("Примечание к событию должно быть не короче 3, и не длиннее 50 символов.", "Что-то не так", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }
            else if (HoursComboBox.Text == "" || MinutesComboBox.Text == "")
            {
                MessageBox.Show("Не забудьте выставить время события.", "Что-то не так", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                OkButton.DialogResult = DialogResult.OK;
            }

            //var newTask = new Task
            //{
            //    Time = HoursComboBox.Text + ":" + MinutesComboBox.Text,
            //    Text = CommentTextBox.Text,
            //    Date = TaskDateTimePicker.Value.ToShortDateString()
            //};
            //var errors = Validation.CheckTask(newTask);

            //if (errors.Count == 0)
            //    OkButton.DialogResult = DialogResult.OK;

            //else
            //{
            //    foreach (var error in errors)
            //    {
            //        MessageBox.Show(error);
            //    }
            //}
        }
    }
}
