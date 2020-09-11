using System;
using System.Collections.Generic;
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
            var listofactual = taskContext.Tasks.Where(t => t.IsActual == true).ToList();
            List<DateTime> listofdates = new List<DateTime>();
            foreach (var task in listofactual)
            {
                listofdates.Add(task.Date);
            }
            return listofdates;
        }
        public Task FindById(int id)
        {
            var thisTask = taskContext.Tasks.FirstOrDefault(t => t.Id == id);
            return thisTask;
        }
        public List<Task> GetByDate(DateTime date)
        {
            var x = taskContext.Tasks.Where(t => t.Date == date).ToList();            
            return x.OrderBy(t => t.Time).ToList();
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
    }
}
