using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NotesWindowsFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        Note myNote;
        string chosenDate;
        string today;
        List<Task> listOfAllTasks;
        readonly string tasksPath = "tasks.json";
        private void MainForm_Load(object sender, EventArgs e)
        {
            myNote = new Note();
            notesTextBox.Text = myNote.Text;
            notesTextBox.SelectedText = null;
            notesToolStripMenuItem.PerformClick();
        }
        private void NotesTextBox_TextChanged(object sender, EventArgs e)
        {
            myNote.Text = notesTextBox.Text;
            myNote.Save();
        }
        private void TodolistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            todolistPanel.Show();
            notesPanel.Hide();
            today = DateTime.Today.ToShortDateString();
            chosenDate = today;

            Task task = new Task();
            listOfAllTasks = task.GetAll(tasksPath);
            if (listOfAllTasks == null)
            {
                listOfAllTasks = new List<Task>();
            }
            UpdateMyTasks();
            ShowTasksForDay();
            
        }
        private void NotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notesPanel.Show();
            notesPanel.Dock = DockStyle.Fill;
            notesTextBox.Dock = DockStyle.Fill;
            todolistPanel.Hide();
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                trayIcon.Visible = true;
                trayIcon.ShowBalloonTip(1000);
            }
        }
        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            trayIcon.Visible = false;
        }
        private void MyCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            chosenDate = myCalendar.SelectionRange.Start.ToShortDateString();
            ShowTasksForDay();
        }
        private void ToDoListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
            ToDoListDataGridView.CurrentRow.Cells[1].Value += "";
            if (ToDoListDataGridView.CurrentRow.Cells[0].Value != null)
            {
                foreach (var task in listOfAllTasks)
                {
                    if (task.Date == chosenDate && task.Time == ToDoListDataGridView.CurrentRow.Cells[0].Value.ToString() && task.Text == ToDoListDataGridView.CurrentRow.Cells[1].Value.ToString())
                    {
                        TaskForm taskform = new TaskForm();
                        var time = ToDoListDataGridView.CurrentRow.Cells[0].Value.ToString().Split(':');
                        taskform.HoursComboBox.Text = time[0];
                        taskform.MinutesComboBox.Text = time[1];
                        taskform.CommentTextBox.Text = task.Text;

                        if (taskform.ShowDialog(this) == DialogResult.OK)
                        {
                            task.Time = taskform.HoursComboBox.Text + ":" + taskform.MinutesComboBox.Text;
                            task.Text = taskform.CommentTextBox.Text;
                            task.Date = taskform.TaskDateTimePicker.Value.ToShortDateString();

                            var jsontasks = JsonConvert.SerializeObject(listOfAllTasks, Formatting.Indented);
                            FileProvider.Replace(tasksPath, jsontasks);
                            UpdateMyTasks();
                        }
                        break;
                    }
                }
            }
            else
            {
                AddTaskButton.PerformClick();
            }
        }
        private void AddTaskButton_Click(object sender, EventArgs e)
        {
            TaskForm taskform = new TaskForm();
            
            if (taskform.ShowDialog(this) == DialogResult.OK)
            {
                var editedTask = new Task
                {
                    Time = taskform.HoursComboBox.Text + ":" + taskform.MinutesComboBox.Text,
                    Text = taskform.CommentTextBox.Text,
                    Date = taskform.TaskDateTimePicker.Value.ToShortDateString()
                };
                listOfAllTasks.Add(editedTask);
                var jsonTasks = JsonConvert.SerializeObject(listOfAllTasks, Formatting.Indented);
                FileProvider.Replace(tasksPath, jsonTasks);
                UpdateMyTasks();
            }
        }
        private void ShowTasksForDay()
        {
            ToDoListDataGridView.Rows.Clear();
            if (listOfAllTasks != null)
            {
                foreach (var taskfromlist in listOfAllTasks)
                {
                    if (taskfromlist.Date == chosenDate)
                    {
                        ToDoListDataGridView.Rows.Add(taskfromlist.Time, taskfromlist.Text);
                    }
                }

            }
        }
        private void UpdateMyTasks()
        {
            myCalendar.BoldedDates = null;
            var coloreddates = myCalendar.BoldedDates.ToList();
            SortTasks();
            foreach (var taskfromlist in listOfAllTasks)
            {
                coloreddates.Add(Convert.ToDateTime(taskfromlist.Date));
            }

            myCalendar.BoldedDates = coloreddates.ToArray();
            ShowTasksForDay();
        }
        private void SortTasks()
        {
            var sortedTasks = from t in listOfAllTasks
                              orderby t.Date, t.Time ascending
                              select t;
            
            listOfAllTasks = sortedTasks.ToList();
        }
    }
}
