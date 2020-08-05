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
        private void TasksForDayDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TasksForDayDataGridView.CurrentRow.Cells[1].Value += "";
            if (TasksForDayDataGridView.CurrentRow.Cells[0].Value != null)
            {
                ChangeToolStripMenuItem.PerformClick();
            }
            else
            {
                AddTaskButton.PerformClick();
            }
        }
        private void AddTaskButton_Click(object sender, EventArgs e)
        {
            TaskForm taskform = new TaskForm();

            taskform.TaskDateTimePicker.Value = Convert.ToDateTime(chosenDate);

            if (chosenDate == today)
            {
                var nexthour = Convert.ToInt32(DateTime.Now.ToString("HH")) + 1;
                taskform.HoursComboBox.Text = nexthour.ToString();
            }


            if (taskform.ShowDialog(this) == DialogResult.OK)
            {
                var editedTask = new Task
                {
                    Time = taskform.HoursComboBox.Text + ":" + taskform.MinutesComboBox.Text,
                    Text = taskform.CommentTextBox.Text,
                    Date = taskform.TaskDateTimePicker.Value.ToShortDateString()
                };
                listOfAllTasks.Add(editedTask);                
                UpdateMyTasks();
            }
        }
        private void ShowTasksForDay()
        {
            TasksForDayDataGridView.Rows.Clear();
            if (listOfAllTasks != null)
            {
                foreach (var taskfromlist in listOfAllTasks)
                {
                    if (taskfromlist.Date == chosenDate)
                    {
                        TasksForDayDataGridView.Rows.Add(taskfromlist.Time, taskfromlist.Text);
                    }
                }

            }
        }
        private void ColorDates()
        {
            myCalendar.BoldedDates = null;
            var coloreddates = myCalendar.BoldedDates.ToList();
            foreach (var taskfromlist in listOfAllTasks)
            {
                coloreddates.Add(Convert.ToDateTime(taskfromlist.Date));
            }

            myCalendar.BoldedDates = coloreddates.ToArray();
        }
        private void SortTasks()
        {
            var sortedTasks = from t in listOfAllTasks
                              orderby t.Date, t.Time ascending
                              select t;

            listOfAllTasks = sortedTasks.ToList();
        }
        private void SaveTasks()
        {
            var jsontasks = JsonConvert.SerializeObject(listOfAllTasks, Formatting.Indented);
            FileProvider.Replace(tasksPath, jsontasks);
        }
        private void UpdateMyTasks()
        {
            SaveTasks();
            SortTasks();
            ShowTasksForDay();
            ColorDates();
        }
        private void TasksForDayDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hit = TasksForDayDataGridView.HitTest(e.X, e.Y);
                if (hit.Type != DataGridViewHitTestType.Cell)
                {
                    TasksForDayDataGridView.ClearSelection();
                    return;
                }
                TasksForDayDataGridView.Rows[hit.RowIndex].Cells[hit.ColumnIndex].Selected = true;
            }
        }
        private void TasksContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (TasksForDayDataGridView.SelectedCells.Count != 1) e.Cancel = true;
        }
        private void ChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var task in listOfAllTasks)
            {
                if (task.Date == chosenDate && task.Time == TasksForDayDataGridView.CurrentRow.Cells[0].Value.ToString() && task.Text == TasksForDayDataGridView.CurrentRow.Cells[1].Value.ToString())
                {
                    TaskForm taskform = new TaskForm();
                    var time = TasksForDayDataGridView.CurrentRow.Cells[0].Value.ToString().Split(':');
                    taskform.HoursComboBox.Text = time[0];
                    taskform.MinutesComboBox.Text = time[1];
                    taskform.CommentTextBox.Text = task.Text;

                    if (taskform.ShowDialog(this) == DialogResult.OK)
                    {
                        task.Time = taskform.HoursComboBox.Text + ":" + taskform.MinutesComboBox.Text;
                        task.Text = taskform.CommentTextBox.Text;
                        task.Date = taskform.TaskDateTimePicker.Value.ToShortDateString();                        
                        UpdateMyTasks();
                    }
                    break;
                }
            }
        }
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var task in listOfAllTasks)
            {
                if (task.Date == chosenDate && task.Time == TasksForDayDataGridView.CurrentRow.Cells[0].Value.ToString() && task.Text == TasksForDayDataGridView.CurrentRow.Cells[1].Value.ToString())
                {
                    listOfAllTasks.Remove(task);
                    
                    UpdateMyTasks();

                    break;
                }
            }
        }
       
    }

}
