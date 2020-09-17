using System;
using System.Collections.Generic;
using System.Globalization;
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
        private DateTime today;
        private DateTime chosenDate;
        private List<Task> listOfTodayAlerts = new List<Task>();        
        readonly TaskDatabaseRepository taskManager = new TaskDatabaseRepository();
        readonly NoteRepository noteRepository = new NoteRepository();
        readonly WeatherInfoProvider weatherInfoProvider = new WeatherInfoProvider();        
        private void MainForm_Load(object sender, EventArgs e)
        {
            myNote = noteRepository.Get();
            notesRichTextBox.Text = myNote.Text;
            notesToolStripMenuItem.PerformClick();            

            
            //while (true)
            //{
            //    var listOfPossiblyMissedEvents = taskManager.FindAllPast();
            //    int countPME = listOfPossiblyMissedEvents.Count;

            //    foreach (var task in listOfPossiblyMissedEvents)
            //    {
            //        taskManager.ChangeAlarmIfNeeded(task);
            //    }

            //    var listOfPossiblyMissedEvents2 = taskManager.FindAllPast();
            //    int countPME2 = listOfPossiblyMissedEvents2.Count;

            //    if (countPME == countPME2)
            //        break;                
            //}
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
                taskform.tags = taskManager.GetAllTags();
            }

            if (taskform.ShowDialog(this) == DialogResult.OK)
            {                                                        
                taskManager.Add(taskform.newTask);                
                UpdateMyTasks();
            }
        }
        private void ChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var task = taskManager.FindById((int)tasksForDayDataGridView.SelectedRows[0].Cells[0].Value);

            TaskForm taskform = new TaskForm();
            var time = task.Time.Split(':');
            taskform.HoursComboBox.Text = time[0];
            taskform.MinutesComboBox.Text = time[1];
            taskform.CommentTextBox.Text = task.Text;
            taskform.TaskDateTimePicker.Value = Convert.ToDateTime(chosenDate);
            taskform.tags = taskManager.GetAllTags();
            taskform.newTask.Id = task.Id;
            taskform.checkedTags = task.Tags;
            taskform.alarmingComboBox.Text = task.Alarming;
            taskform.repeatingComboBox.Text = task.Repeating;

            if (taskform.ShowDialog(this) == DialogResult.OK)
            {                                           
                taskManager.Update(taskform.newTask);
                UpdateMyTasks();
            }
        }
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int taskId = (int)tasksForDayDataGridView.CurrentRow.Cells[0].Value;
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
            myCalendar.BoldedDates = taskManager.FindAllNotEmptyDates()?.ToArray();
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
        private void WeatherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notesPanel.Hide();
            todolistPanel.Hide();
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
                        taskManager.CountNextAlarmTime(taskfromlist);
                        AlertForm alertForm = new AlertForm();
                        alertForm.AlertMessageLabel.Text = String.Format("{0}, {1},{2}", taskfromlist.NextDate.ToShortDateString(), taskfromlist.Time, taskfromlist.Text);
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