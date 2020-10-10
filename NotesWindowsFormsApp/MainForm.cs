using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace NotesWindowsFormsApp
{
    public partial class MainForm : Form
    {
        private DateTime today;
        private DateTime chosenDate;
        private List<Task> listOfTodayAlerts = new List<Task>();
        readonly ITaskRepository taskManager;
        readonly ITagRepository tagManager;
        readonly ITaskUpdaterRepository taskUpdater;
        readonly INoteRepository noteRepository;
        readonly WeatherInfoProvider weatherInfoProvider = new WeatherInfoProvider();
        public MainForm(IServiceProvider provider)
        {
            InitializeComponent();
            taskManager = provider.GetService<ITaskRepository>();
            tagManager = provider.GetService<ITagRepository>();
            //taskUpdater = provider.GetService<ITaskUpdaterRepository>();
            taskUpdater = new TaskUpdaterDatabaseRepository(provider.GetService<TaskContext>(), (TaskDatabaseRepository)taskManager);
            noteRepository = provider.GetService<INoteRepository>();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            notesRichTextBox.Text = noteRepository.Get();
            notesToolStripMenuItem.PerformClick();

            taskUpdater.Set();
            midnightTimer.Enabled = true;
            everyMinuteTimer.Enabled = true;
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
            TaskForm taskform = new TaskForm(tagManager);

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
                taskform.newTask.FirstDate = DateTime.Parse(taskform.TaskDateTimePicker.Value.ToShortDateString());
                taskManager.TryToAdd(taskform.newTask);
                UpdateMyTasks();
            }
        }
        private void ChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idToFindBy = (int)tasksForDayDataGridView.SelectedRows[0].Cells[0].Value;
            var task = taskManager.FindById(idToFindBy);
            TaskForm taskform = new TaskForm(tagManager, task);
            taskform.TaskDateTimePicker.Value = chosenDate;

            if (taskform.ShowDialog(this) == DialogResult.OK)
            {
                taskManager.Update(taskform.newTask);
                UpdateMyTasks();
            }
        }
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int taskId = (int)tasksForDayDataGridView.SelectedRows[0].Cells[0].Value;
            taskManager.Delete(taskId);
            UpdateMyTasks();
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
            myCalendar.BoldedDates = taskManager.FindAllActualDates()?.ToArray();
        }
        private void UpdateMyTasks()
        {
            ShowTasksForDay();
            listOfTodayAlerts = taskManager.GetTodayAlerts();
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
        private void SaveNote()
        {
            noteRepository.Update(notesRichTextBox.Text);
        }
        private void NotesRichTextBox_Leave(object sender, EventArgs e)
        {
            SaveNote();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveNote();
            taskUpdater.ChangeExitTime();
            trayIcon.Visible = false;
            trayIcon.Dispose();
        }
        private void WeatherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notesPanel.Hide();
            todolistPanel.Hide();
            GetWeather();
            weatherPanel.Show();
            weatherPanel.Dock = DockStyle.Fill;
        }
        private void GetWeather()
        {
            var weatherData = weatherInfoProvider.GetData().Result;

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
        private void WeatherTimer_Tick(object sender, EventArgs e)
        {
            GetWeather();
        }
        private void MidnightTimer_Tick(object sender, EventArgs e)
        {
            today = DateTime.Today;
            midnightTimer.Interval = (int)(DateTime.Today.AddDays(1) - DateTime.Now).TotalMilliseconds;
            listOfTodayAlerts = taskManager.GetTodayAlerts();
            taskUpdater.Update();
        }
        private void EveryMinuteTimer_Tick(object sender, EventArgs e)
        {
            if (listOfTodayAlerts.Count != 0)
            {
                var now = DateTime.Now;
                var nowShort = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);
                foreach (var taskfromlist in listOfTodayAlerts)
                {
                    if (taskfromlist.AlarmTime == nowShort)
                    {
                        taskfromlist.CountNextAlarmTime();
                        AlertForm alertForm = new AlertForm();
                        alertForm.AlertMessageLabel.Text = String.Format("{0}, {1},{2}", taskfromlist.FirstDate.ToShortDateString(), taskfromlist.Time, taskfromlist.Text);
                        alertForm.TopMost = true;
                        alertForm.Show();
                        return;
                    }
                }
            }

            everyMinuteTimer.Interval = (60 - DateTime.Now.Second) * 1000;
        }
        private void ТестToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}