using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace NotesWindowsFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private Note myNote;
        readonly string notePath = "notes.json";
        readonly string tasksPath = "tasks.json";
        private string chosenDate;
        private string today;
        private List<Task> listOfAllTasks;
        private List<Task> listOfTodayTasks = new List<Task>();

        private void MainForm_Load(object sender, EventArgs e)
        {
            myNote = new Note
            {
                Text = FileProvider.CreateOrGet(notePath)
            };
            notesRichTextBox.Text = myNote.Text;
            notesToolStripMenuItem.PerformClick();

            listOfAllTasks = JsonConvert.DeserializeObject<List<Task>>(FileProvider.CreateOrGet(tasksPath));
            if (listOfAllTasks == null)
            {
                listOfAllTasks = new List<Task>();
            }
            GetTodayTasks();
        }
        private void TasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            todolistPanel.Show();
            notesPanel.Hide();

            chosenDate = today;
            UpdateMyTasks();
        }
        private void NotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notesPanel.Show();
            notesPanel.Dock = DockStyle.Fill;
            notesRichTextBox.Dock = DockStyle.Fill;
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
                //ставим время на час больше нынешней минуты
                var nexthour = Convert.ToInt32(DateTime.Now.ToString("HH")) + 1;                
                taskform.HoursComboBox.Text = nexthour.ToString("D2");
                taskform.MinutesComboBox.Text = DateTime.Now.ToString("mm");
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

            foreach (var taskfromlist in listOfAllTasks)
            {
                if (taskfromlist.Date == chosenDate)
                {
                    TasksForDayDataGridView.Rows.Add(taskfromlist.Time, taskfromlist.Text);
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
            GetTodayTasks();
            TasksForDayDataGridView.ClearSelection();
        }
        private void TasksForDayDataGridView_MouseDown(object sender, MouseEventArgs e)
        {            
            DataGridView.HitTestInfo hit = TasksForDayDataGridView.HitTest(e.X, e.Y);
            if (hit.Type != DataGridViewHitTestType.Cell || TasksForDayDataGridView.Rows[hit.RowIndex].Cells[hit.ColumnIndex].Value==null)
            {
                TasksForDayDataGridView.ClearSelection();
                return;
            }

            TasksForDayDataGridView.Rows[hit.RowIndex].Selected = true;                       
        }
        private void TasksContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (TasksForDayDataGridView.SelectedRows.Count != 1) e.Cancel = true;
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
                    taskform.TaskDateTimePicker.Value = Convert.ToDateTime(chosenDate);

                    if (taskform.ShowDialog(this) == DialogResult.OK)
                    {
                        task.Time = taskform.HoursComboBox.Text + ":" + taskform.MinutesComboBox.Text;
                        task.Text = taskform.CommentTextBox.Text;
                        task.Date = taskform.TaskDateTimePicker.Value.ToShortDateString();

                        if (task.Date == today&&
                            Convert.ToInt32(taskform.HoursComboBox.Text)>= Convert.ToInt32(DateTime.Now.ToString("HH"))&& 
                            Convert.ToInt32(taskform.MinutesComboBox.Text) >= Convert.ToInt32(DateTime.Now.ToString("mm"))
                            )
                        task.IsActual = true;

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
        private void GetTodayTasks()
        {
            listOfTodayTasks = new List<Task>();
            today = DateTime.Today.ToShortDateString();
            foreach (var taskfromlist in listOfAllTasks)
            {
                if (taskfromlist.Date == today)
                {
                    listOfTodayTasks.Add(taskfromlist);
                }
            }
        }
        private void EveryTenSecondsTimer_Tick(object sender, EventArgs e)
        {            
            var currenttime = DateTime.Now.ToString("HH:mm");

            if (currenttime == "00:00")
            {
                GetTodayTasks();
            }
            if (listOfTodayTasks.Count != 0)
            {
                foreach (var taskfromlist in listOfTodayTasks)
                {
                    if (taskfromlist.Time == currenttime&&taskfromlist.IsActual==true)
                    {
                        taskfromlist.IsActual = false;
                        EveryTenSecondsTimer.Stop();
                        AlertForm alertForm = new AlertForm();
                        alertForm.AlertMessageLabel.Text = taskfromlist.Text;
                        alertForm.TopMost = true;                        
                        alertForm.Show();

                        listOfTodayTasks.Remove(taskfromlist);

                        EveryTenSecondsTimer.Start();
                        return;
                    }
                }
            }
        }
        private void SaveNote()
        {
            myNote.Text = notesRichTextBox.Text;
            FileProvider.Replace(notePath, myNote.Text);
        }
        private void NotesRichTextBox_Leave(object sender, EventArgs e)
        {
            SaveNote();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveNote();
        }       
        private void тестToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
    }
}
    


