using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NotesWindowsFormsApp
{
    public class TaskDatabaseRepository : ITaskRepository
    {
        readonly TaskContext context;
        public TaskDatabaseRepository(TaskContext context)
        {
            this.context = context;
        }
        private void Add(Task task)
        {
            SetAllDates(task);
            task.CountNextAlarmTime();
            context.Tasks.Add(task);
            context.SaveChanges();
        }
        public void TryToAdd(Task task)
        {
            if (task != null)
            {
                if (task.Validate().Count == 0)
                {
                    Add(task);
                }
            }
        }
        public void Delete(int id)
        {
            var tasktoDelete = FindById(id);
            if (tasktoDelete != null)
            {
                context.Tasks.Remove(tasktoDelete);
                context.SaveChanges();
            }
        }       
        public List<Task> GetAll()
        {
            return context.Tasks.ToList();
        }
        public List<DateTime> FindAllActualDates()
        {
            var listofactual = context.Dates.Where((t => DateTime.Compare(t.Day, DateTime.Today) >= 0)).Where(t => t.Tasks.Count > 0).ToList();
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
        public void Update(Task task)
        {
            if (task.Validate().Count == 0)
            {
                var taskToChange = context.Tasks.SingleOrDefault(t => t.Id == task.Id);

                if (taskToChange != null)
                {
                    foreach (var date in taskToChange.Dates)
                    {
                        date.Tasks.Remove(taskToChange);
                    }
                    taskToChange.Dates.Clear();

                    taskToChange.Repeating = task.Repeating;
                    SetAllDates(taskToChange);

                    taskToChange.Time = task.Time;
                    taskToChange.Alarming = task.Alarming;
                    taskToChange.CountNextAlarmTime();

                    taskToChange.Text = task.Text;
                    taskToChange.Tags = task.Tags;

                    context.SaveChanges();
                }
            }
        }
        public List<Task> GetTodayAlerts() => context.Tasks.Where(t => DbFunctions.TruncateTime(t.AlarmTime) == DateTime.Today).ToList();
        public void SetAllDates(Task task)
        {
            if (task != null)
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
        }       
    }
}
