using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace NotesWindowsFormsApp
{
    class TaskDatabaseRepository : ITaskRepository
    {
        private readonly TaskContext taskContext = new TaskContext();
        public void Add(Task task)
        {
            taskContext.Tasks.Add(task);
            taskContext.SaveChanges();
        }
        public void Delete(int id)
        {
            taskContext.Tasks.Remove(FindById(id));
            taskContext.SaveChanges();
        }
        public List<DateTime> FindAllActual()
        {            
            var listofactual = taskContext.Tasks.Where(t => DateTime.Compare(t.Date, DateTime.Today) >= 0).ToList();
            List<DateTime> listofdates = new List<DateTime>();
            foreach (var task in listofactual)
            {
                listofdates.Add(task.Date);
            }
            return listofdates;
        }
        public List<Task> FindAllPast()
        {
            return taskContext.Tasks.Where(t => DateTime.Compare(t.Date, DateTime.Today) < 0).ToList();
        }
        public Task FindById(int id)
        {
            var thisTask = taskContext.Tasks.FirstOrDefault(t => t.Id == id);
            return thisTask;
        }
        public List<Task> GetByDate(DateTime date)
        {
            var listOfTasks = taskContext.Tasks.Where(t => t.Date == date).ToList();
            return listOfTasks.OrderBy(t => t.Time).ToList();
        }
        public List<Tags> GetAllTags()
        {
            var listOfTags = new List<Tags>();
            foreach (var t in taskContext.Tags)
            {
                listOfTags.Add(t);
            }
            return listOfTags;
        }
        public void Update(Task task)
        {
            var taskToChange = taskContext.Tasks.SingleOrDefault(t => t.Id == task.Id);
            if (taskToChange != null)
            {
                taskToChange.Tags.Clear();
                taskToChange.Tags.AddRange(task.Tags);

                taskContext.Tasks.AddOrUpdate(task);
                taskContext.SaveChanges();
            }
        }
        public void Delete(Task task)
        {
            taskContext.Tasks.Remove(task);
            taskContext.SaveChanges();
        }
        public List<Task> GetTodayAlerts()
        {
            var listOfAlerts = taskContext.Tasks.Where(t => DbFunctions.TruncateTime(t.AlarmTime) == DateTime.Today).ToList();
            return listOfAlerts;
        }
        public void ChangeAlarmIfNeeded(Task task)
        {
            var taskToChange = taskContext.Tasks.SingleOrDefault(t => t.Id == task.Id);
            var newtask = taskToChange;
            switch (taskToChange.Repeating)
            {
                case "Один раз":
                    break;
                case "Каждый день":
                    newtask.Date = taskToChange.Date.AddDays(1);
                    newtask.AlarmTime = taskToChange.AlarmTime.AddDays(1);
                   
                    break;
                case "Каждую неделю":
                    newtask.Date = taskToChange.Date.AddDays(7);
                    newtask.AlarmTime = taskToChange.AlarmTime.AddDays(7);
                  
                    break;
                case "Каждый месяц":
                    newtask.Date = taskToChange.Date.AddMonths(1);
                    newtask.AlarmTime = taskToChange.AlarmTime.AddMonths(1);
                  
                    break;
                case "Каждый год":
                    newtask.Date = taskToChange.Date.AddYears(1);
                    newtask.AlarmTime = taskToChange.AlarmTime.AddYears(1);
                   
                    break;
            }

            taskContext.Tasks.AddOrUpdate(newtask);
            taskContext.SaveChanges();

        }
    }
}
