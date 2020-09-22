using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Migrations;

namespace NotesWindowsFormsApp
{
    class TaskDatabaseRepository : ITaskRepository
    {
        internal TaskContext context;
        public void Add(Task task)
        {
            SetAllDates(task);
            CountNextAlarmTime(task);
            context.Tasks.Add(task);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            context.Tasks.Remove(FindById(id));
            context.SaveChanges();
        }      
        public List<DateTime> FindAllActualDates()
        {
            var listofactual = context.Dates.Where((t => DateTime.Compare(t.Day, DateTime.Today) >= 0)).Where(t => t.Tasks.Count > 0);
            List<DateTime> listofdates = new List<DateTime>();
            foreach (var date in listofactual)
            {
                listofdates.Add(date.Day);
            }
            return listofdates;
        }

        public Task FindById(int id)
        {
            var thisTask = context.Tasks.FirstOrDefault(t => t.Id == id);
            return thisTask;
        }
        public List<Task> GetByDate(DateTime date)
        {
            TaskDate day = context.Dates.FirstOrDefault(t => t.Day == date);
            if (day == null)
            {
                context.Dates.Add(new TaskDate { Day = date });
                context.SaveChanges();
                day = context.Dates.FirstOrDefault(t => t.Day == date);
            }
            var listOfTasks = day.Tasks;
            return listOfTasks.OrderBy(t => t.Time).ToList();
        }
        public void RecountAllMissedAlarms(DateTime lastExitTime)
        {
            //находим все события, будильники которых были установлены на время, пока программа была закрыта
            List<Task> tasksWithMissedAlarms = context.Tasks.Where(t => DateTime.Compare(t.AlarmTime, DateTime.Now) < 0).Where(t => DateTime.Compare(t.AlarmTime, lastExitTime) > 0).ToList();
            foreach (var task in tasksWithMissedAlarms)
            {
                CountNextAlarmTime(task);
                context.SaveChanges();
            }
        }       
        public void Update(Task task)
        {
            var taskToChange = context.Tasks.SingleOrDefault(t => t.Id == task.Id);

            if (taskToChange != null)
            {
                foreach (var date in taskToChange.Dates)
                {
                    date.Tasks.Remove(taskToChange);
                }
                taskToChange.Tags.Clear();
                taskToChange.Dates.Clear();

                taskToChange.Repeating = task.Repeating;
                SetAllDates(taskToChange);

                taskToChange.Time = task.Time;
                taskToChange.Alarming = task.Alarming;
                CountNextAlarmTime(taskToChange);

                taskToChange.Text = task.Text;
                
                context.SaveChanges();
            }
        }
        public List<Task> GetTodayAlerts()
        {
            var listOfAlerts = context.Tasks.Where(t => DbFunctions.TruncateTime(t.AlarmTime) == DateTime.Today).ToList();
            return listOfAlerts;
        }
        public DateTime PickNextDate(Task task, DateTime date)
        {
            if (task.Dates.Count < 2)
                return DateTime.MinValue;

            for (int i = 0; i < task.Dates.Count - 1; i++)
            {
                if (task.Dates[i].Day == date)
                {
                    return task.Dates[i + 1].Day;
                }
            }

            return DateTime.MinValue;
        }
        public void CountNextAlarmTime(Task task)
        {
            var date = task.FirstDate;
            DateTime timeOfStart = date.Add(DateTime.Parse(task.Time).TimeOfDay);
            var supposedTime = DateTime.MinValue;

            var alarmingParts = task.Alarming.Split(' ');
            var count = Int32.Parse(alarmingParts[0]);
            var span = alarmingParts[1];
            

            while (true)
            {
                switch (span)
                {
                    case "мин.":
                        supposedTime = timeOfStart.AddMinutes(-count);
                        break;
                    case "ч.":
                        supposedTime = timeOfStart.AddHours(-count);
                        break;
                    case "д.":
                        supposedTime = timeOfStart.AddDays(-count);
                        break;
                    case "нед.":
                        supposedTime = timeOfStart.AddDays(-7*count);
                        break;
                    case "мес.":
                        supposedTime = timeOfStart.AddMonths(-count);
                        break;
                    case "г.":
                        supposedTime = timeOfStart.AddYears(-count);
                        break;                    
                }

                if (DateTime.Compare(supposedTime, DateTime.Now) > 0)
                    break;

                date = PickNextDate(task, date);

                if (date == DateTime.MinValue)
                {
                    supposedTime = date;
                    break;
                }

                timeOfStart = date.Add(DateTime.Parse(task.Time).TimeOfDay);
            }
            task.AlarmTime = supposedTime;
        }
        public void SetAllDates(Task task)
        {
            var day = task.FirstDate;
            List<TaskDate> dates = new List<TaskDate>();

            switch (task.Repeating)
            {
                case "Один раз":

                    var date = context.Dates.FirstOrDefault(t => t.Day == day);
                    if (date != null)
                        dates.Add(date);
                    break;
                case "Каждый день":
                    while (true)
                    {
                        date = context.Dates.FirstOrDefault(t => t.Day == day);
                        if (date != null)
                        {
                            dates.Add(date);
                            day = day.AddDays(1);
                        }
                        else break;
                    }
                    break;
                case "Каждую неделю":
                    while (true)
                    {
                        date = context.Dates.FirstOrDefault(t => t.Day == day);
                        if (date != null)
                        {
                            dates.Add(date);
                            day = day.AddDays(7);
                        }
                        else break;
                    }
                    break;
                case "Каждый месяц":
                    while (true)
                    {
                        date = context.Dates.FirstOrDefault(t => t.Day == day);
                        if (date != null)
                        {
                            dates.Add(date);
                            day = day.AddMonths(1);
                        }
                        else break;
                    }

                    break;
                case "Каждый год":
                    while (true)
                    {
                        date = context.Dates.FirstOrDefault(t => t.Day == day);
                        if (date != null)
                        {
                            dates.Add(date);
                            day = day.AddYears(1);
                        }
                        else break;
                    }

                    break;
            }
            task.Dates.AddRange(dates);

            foreach (var date in dates)
            {
                date.Tasks.Add(task);
            }
        }
        public void AddDates(int countdays)
        {
            var day = context.Dates.Max(t => t.Day);

           
            for (int i = 0; i <= countdays; i++)
            {                
                context.Dates.AddOrUpdate(t => t.Day, new TaskDate { Day = day });
                context.SaveChanges();
                day = day.AddDays(1);
            }          

            foreach (var task in context.Tasks)
            {
                task.Dates.Clear();
                SetAllDates(task);
            }
            context.SaveChanges();
        }
    }
}
