using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        int indexOEditedTask;
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
            //myCalendar.SetSelectionRange(Convert.ToDateTime(today), Convert.ToDateTime(today));

            Task task = new Task();
            listOfAllTasks = task.GetAll(tasksPath);

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
            
            ToDoListDataGridView.CurrentRow.Cells[0].Value += "";
            ToDoListDataGridView.CurrentRow.Cells[1].Value += "";
            if (listOfAllTasks != null)
            {
                indexOEditedTask = listOfAllTasks.Count + 1;
                foreach (var task in listOfAllTasks)
                {
                    if (task.Time == ToDoListDataGridView.CurrentRow.Cells[0].Value.ToString()&&task.Text == ToDoListDataGridView.CurrentRow.Cells[1].Value.ToString())
                    {
                        indexOEditedTask = listOfAllTasks.IndexOf(task);
                        break;
                    }
                }
            }
        }
        private void ToDoListDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var editedTask = new Task
            {
                Time = Convert.ToString(ToDoListDataGridView.CurrentRow.Cells[0].Value),
                Text = Convert.ToString(ToDoListDataGridView.CurrentRow.Cells[1].Value),
                Date = chosenDate
            };
            if (listOfAllTasks == null)
            {
                listOfAllTasks = new List<Task>();
            }
            if (listOfAllTasks.Count < indexOEditedTask|| listOfAllTasks.Count==0)
                listOfAllTasks.Add(editedTask);
            else
                listOfAllTasks[indexOEditedTask] = editedTask;

            var jsonTasks = JsonConvert.SerializeObject(listOfAllTasks, Formatting.Indented);
            
            FileProvider.Replace(tasksPath, jsonTasks);
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

       
    }
}
