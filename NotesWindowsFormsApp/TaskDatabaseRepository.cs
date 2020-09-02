using System;
using System.Collections.Generic;
using System.Linq;

namespace NotesWindowsFormsApp
{
    class TaskDatabaseRepository : ITaskRepository
    {
        private readonly TaskContext taskContext = new TaskContext();
        public void Add(Task task)
        {
            task.IsActual = DateTime.Compare(task.Date, DateTime.Today) > 0 ||
                         DateTime.Compare(task.Date, DateTime.Today) == 0 && String.Compare(task.Time, DateTime.Now.ToString("HH:mm")) > 0;
            taskContext.Tasks.Add(task);
            taskContext.SaveChanges();
        }

        public void Delete(Task task)
        {
            taskContext.Tasks.Remove(task);
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

        public Task FindbyId(int id)
        {
            var listwithonetask = taskContext.Tasks.Where(t => t.Id == id).ToList();
            return listwithonetask[0];
        }

        public List<Task> GetByDate(DateTime date)
        {
            var x = taskContext.Tasks.Where(t => t.Date == date).ToList();
            return x;
        }

        public void Update(Task task)
        {
            var taskToChange = taskContext.Tasks.SingleOrDefault(t => t.Id == task.Id);
            if (taskToChange != null)
            {
                taskToChange = task;
                taskContext.SaveChanges();
            }            
        }
    }
}
