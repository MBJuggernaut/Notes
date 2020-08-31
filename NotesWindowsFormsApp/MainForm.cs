using System;
using System.Collections.Generic;
using System.Globalization;
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
        private Note myNote = new Note();

        private DateTime chosenDate;
        private DateTime today = DateTime.Today;
        private List<Task> listOfTodayTasks = new List<Task>();
        readonly TaskJsonRepository taskManager = new TaskJsonRepository();
        readonly NoteRepository noteRepository = new NoteRepository();
        readonly WeatherInfoProvider weatherInfoRepository = new WeatherInfoProvider();
        // readonly TaskContext taskContext = new TaskContext();
        private void MainForm_Load(object sender, EventArgs e)
        {
            myNote = noteRepository.Get();
            notesRichTextBox.Text = myNote.Text;
            notesToolStripMenuItem.PerformClick();
            listOfTodayTasks = taskManager.GetByDate(today);
            GetWeather();
        }
        private void TasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            todolistPanel.Dock = DockStyle.Fill;
            todolistPanel.Show();
            notesPanel.Hide();
            weatherPanel.Hide();

            chosenDate = today;
            UpdateMyTasks();
        }
        private void NotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notesPanel.Show();
            notesPanel.Dock = DockStyle.Fill;
            notesRichTextBox.Dock = DockStyle.Fill;
            todolistPanel.Hide();
            weatherPanel.Hide();
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
            chosenDate = myCalendar.SelectionRange.Start;
            ShowTasksForDay();
        }
        private void AddTaskButton_Click(object sender, EventArgs e)
        {
            TaskForm taskform = new TaskForm();

            taskform.TaskDateTimePicker.Value = chosenDate;

            if (chosenDate == today)
            {
                //ставим время на час больше нынешней минуты, при необходимости перескакиваем на завтра
                var nexthour = Convert.ToInt32(DateTime.Now.ToString("HH")) + 1;
                if (nexthour == 24)
                    taskform.TaskDateTimePicker.Value = DateTime.Now.AddDays(1);

                taskform.HoursComboBox.Text = nexthour.ToString("D2");
                taskform.MinutesComboBox.Text = DateTime.Now.ToString("mm");
            }

            if (taskform.ShowDialog(this) == DialogResult.OK)
            {
                var editedTask = new Task();
                SetTask(editedTask, taskform);
                taskManager.Add(editedTask);
                UpdateMyTasks();
            }
        }
        private void ShowTasksForDay()
        {
            tasksForDayDataGridView.Rows.Clear();
            var tasksForDay = taskManager.GetByDate(chosenDate);
            foreach (var task in tasksForDay)
            {
                tasksForDayDataGridView.Rows.Add(task.Id, task.Time, task.Text);
            }
        }
        private void ColorDates()
        {
            myCalendar.BoldedDates = null;            
            myCalendar.BoldedDates = taskManager.FindAllActual()?.ToArray();
        }
        private void UpdateMyTasks()
        {
            ShowTasksForDay();
            listOfTodayTasks = taskManager.GetByDate(today);
            ColorDates();
            tasksForDayDataGridView.ClearSelection();
        }
        private void TasksForDayDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = tasksForDayDataGridView.HitTest(e.X, e.Y);
            if (hit.Type != DataGridViewHitTestType.Cell || tasksForDayDataGridView.Rows[hit.RowIndex].Cells[hit.ColumnIndex].Value == null)
            {
                tasksForDayDataGridView.ClearSelection();
                return;
            }

            tasksForDayDataGridView.Rows[hit.RowIndex].Selected = true;
        }
        private void TasksContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tasksForDayDataGridView.SelectedRows.Count != 1) e.Cancel = true;
        }
        private void ChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var task = taskManager.FindbyId((int)tasksForDayDataGridView.CurrentRow.Cells[0].Value);

            TaskForm taskform = new TaskForm();
            var time = tasksForDayDataGridView.CurrentRow.Cells[1].Value.ToString().Split(':');
            taskform.HoursComboBox.Text = time[0];
            taskform.MinutesComboBox.Text = time[1];
            taskform.CommentTextBox.Text = task.Text;
            taskform.TaskDateTimePicker.Value = Convert.ToDateTime(chosenDate);

            if (taskform.ShowDialog(this) == DialogResult.OK)
            {
                SetTask(task, taskform);
                taskManager.Update(task);
                UpdateMyTasks();
            }
        }
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var task = taskManager.FindbyId((int)tasksForDayDataGridView.CurrentRow.Cells[0].Value);
            taskManager.Delete(task);
            UpdateMyTasks();
        }
        private void EveryTenSecondsTimer_Tick(object sender, EventArgs e)
        {
            var currenttime = DateTime.Now.ToString("HH:mm");

            if (currenttime == "00:00")
            {
                today = DateTime.Today;
                listOfTodayTasks = taskManager.GetByDate(today);
            }
            if (listOfTodayTasks.Count != 0)
            {
                foreach (var taskfromlist in listOfTodayTasks)
                {
                    if (taskfromlist.Time == currenttime && taskfromlist.IsActual == true)
                    {
                        taskfromlist.IsActual = false;
                        everyTenSecondsTimer.Stop();
                        AlertForm alertForm = new AlertForm();
                        alertForm.AlertMessageLabel.Text = taskfromlist.Text;
                        alertForm.TopMost = true;
                        alertForm.Show();

                        everyTenSecondsTimer.Start();
                        return;
                    }
                }
            }
        }
        private void SaveNote()
        {
            myNote.Text = notesRichTextBox.Text;
            noteRepository.Update(myNote);
        }
        private void NotesRichTextBox_Leave(object sender, EventArgs e)
        {
            SaveNote();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveNote();
        }
        
        private void SetTask(Task task, TaskForm taskform)
        {
            task.Time = taskform.HoursComboBox.Text + ":" + taskform.MinutesComboBox.Text;
            task.Text = taskform.CommentTextBox.Text;
            task.Date = taskform.TaskDateTimePicker.Value.Date;
        }
        private void WeatherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notesPanel.Hide();
            todolistPanel.Hide();
            weatherPanel.Show();
            weatherPanel.Dock = DockStyle.Fill;
        }
        private void GetWeather()
        {
            var weatherData = weatherInfoRepository.GetData().Result;

            if (weatherData != null)
            {
                temperatureLabel.Text = String.Format("{0} °C", weatherData.Main.Temp.ToString());
                cloudsLabel.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(weatherData.Weather[0].Description.ToString().ToLower());
                feelslikeLabel.Text = String.Format("Ощущается как {0}", weatherData.Main.Feels_like.ToString());
                var iconURL = "http://openweathermap.org/img/wn/" + weatherData.Weather[0].Icon + "@2x.png";
                weatherPictureBox.ImageLocation = iconURL;
            }
            else
            {
                weatherErrorLabel.Size = weatherErrorLabel.MaximumSize;
                weatherErrorLabel.Dock = DockStyle.Fill;
                weatherErrorLabel.Visible = true;
            }

        }
        private void ТестToolStripMenuItem_Click(object sender, EventArgs e)
        {


            //    Task testTask = new Task
            //    {
            //        Time = "20:00",
            //        Date = DateTime.Now,
            //        Text = "1111",
            //        IsActual = true
            //    };
            //    taskContext.Tasks.Add(testTask);
            //    //taskContext.SaveChanges();

            //    var test2 = taskContext.Tasks;

            //    foreach (var t in test2)
            //    {
            //        MessageBox.Show(t.Date.ToString(), t.Id.ToString());
            //    }

            //    //var test = taskContext.Tasks;

            //    //foreach (var t in test)
            //    //{
            //    //    taskContext.Tasks.Remove(t);

            //    //}
            //    //taskContext.SaveChanges();
        }
        private void WeatherTimer_Tick(object sender, EventArgs e)
        {
            GetWeather();
        }


    }
}






