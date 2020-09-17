using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NotesWindowsFormsApp
{
    class TaskDatabaseRepository : ITaskRepository
    {
        private readonly TaskContext context = new TaskContext();
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
        public void Delete(Task task)
        {
            context.Tasks.Remove(task);
            context.SaveChanges();
        }
        public List<DateTime> FindAllActualDates()
        {
            var listofactual = context.Dates.Where((t => DateTime.Compare(t.Day, DateTime.Today) >= 0)).Where(t => t.Tasks.Count > 0);
            List <DateTime> listofdates = new List<DateTime>();
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
            var day = context.Dates.FirstOrDefault(t => t.Day == date);
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
        public List<Tag> GetAllTags()
        {
            var listOfTags = new List<Tag>();
            foreach (var t in context.Tags)
            {
                listOfTags.Add(t);
            }
            return listOfTags;
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
                
                taskToChange.FirstDate = task.FirstDate;
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
            if (task.Dates.Count <2)
                return DateTime.MinValue;

            for (int i =0;i<task.Dates.Count-1;i++)
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
            while (true)
            {       
                
                switch (task.Alarming)
                {
                    case "В момент начала":
                        supposedTime = timeOfStart;
                        break;
                    case "5 мин.":
                        supposedTime = timeOfStart.AddMinutes(-5);
                        break;
                    case "15 мин.":
                        supposedTime = timeOfStart.AddMinutes(-15);
                        break;
                    case "30 мин.":
                        supposedTime = timeOfStart.AddMinutes(-30);
                        break;
                    case "1 час":
                        supposedTime = timeOfStart.AddHours(-1);
                        break;
                    case "1 день":
                        supposedTime = timeOfStart.AddDays(-1);
                        break;
                    case "1 неделя":
                        supposedTime = timeOfStart.AddDays(-7);
                        break;
                    case "Не напоминать":
                        break;
                }

                if (DateTime.Compare(supposedTime, DateTime.Now) > 0)
                    break;

                date = PickNextDate(task, date);

                if(date == DateTime.MinValue)
                { 
                    supposedTime = DateTime.Now.AddDays(-1);
                    break;
                }

                timeOfStart = date.Add(DateTime.Parse(task.Time).TimeOfDay);
                
            }
            task.AlarmTime = supposedTime;
        }
        public void SetAllDates(Task task)
        {
            var day = task.FirstDate;
            List<Date> dates = new List<Date>();

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
        public void AddDates()
        {
            
            var day = context.Dates.Last().Day.AddDays(1);
            List <Date> dates = new List<Date>();
            for (int i = 0; i <= 31; i++)
            {
                dates.Add(new Date { Day = day });
                day = day.AddDays(1);
            }
            context.Dates.AddRange(dates);

            foreach (var task in context.Tasks)
            {
                task.Dates.Clear();
                SetAllDates(task);
            }
            context.SaveChanges();
            
        }
    }
}
