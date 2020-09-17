using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
        public List<DateTime> FindAllNotEmptyDates()
        {
            var listofactual = context.Dates.Where(t => t.Tasks.Count > 0);
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
            var day = context.Dates.FirstOrDefault(t => t.Day == date);
            var listOfTasks = day.Tasks;
            return listOfTasks.OrderBy(t => t.Time).ToList();
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
                    date.Tasks.Remove(task);
                }
                taskToChange.Tags.Clear();
                taskToChange.Dates.Clear();

                taskToChange = task;

                SetAllDates(taskToChange);

                CountNextAlarmTime(taskToChange);

                //  context.Tasks.Attach(taskToChange);
                //context.Entry(taskToChange).State = EntityState.Modified;                

                //context.Tasks.AddOrUpdate(FindById(taskToChange.Id));
                context.SaveChanges();
            }
        }
        public List<Task> GetTodayAlerts()
        {
            var listOfAlerts = context.Tasks.Where(t => DbFunctions.TruncateTime(t.AlarmTime) == DateTime.Today).ToList();
            return listOfAlerts;
        }
        public void PickNextDate(Task task)
        {
            task.NextDate = task.Dates.FirstOrDefault(t => DateTime.Compare(t.Day, DateTime.Today) >= 0).Day;
        }
        public void CountNextAlarmTime(Task task)
        {
            PickNextDate(task);
            DateTime timeOfStart = task.NextDate.Add(DateTime.Parse(task.Time).TimeOfDay);
            switch (task.Alarming)
            {
                case "В момент начала":
                    task.AlarmTime = timeOfStart;
                    break;
                case "5 мин.":
                    task.AlarmTime = timeOfStart.AddMinutes(-5);
                    break;
                case "15 мин.":
                    task.AlarmTime = timeOfStart.AddMinutes(-15);
                    break;
                case "30 мин.":
                    task.AlarmTime = timeOfStart.AddMinutes(-30);
                    break;
                case "1 час":
                    task.AlarmTime = timeOfStart.AddHours(-1);
                    break;
                case "1 день":
                    task.AlarmTime = timeOfStart.AddDays(-1);
                    break;
                case "1 неделя":
                    task.AlarmTime = timeOfStart.AddDays(-7);
                    break;
                case "Не напоминать":
                    break;
            }
        }
        public void SetAllDates(Task task)
        {
            var day = task.NextDate;
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
    }
}
