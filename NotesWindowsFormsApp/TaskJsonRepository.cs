using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NotesWindowsFormsApp
{
    public class TaskJsonRepository : ITaskRepository
    {
        readonly static string tasksPath = "tasks.json";
        public List<Task> listOfAllTasks = GetAll();

        public void Add(Task task)
        {
            task.Id = GenerateId();
            task.IsActual = DateTime.Compare(task.Date, DateTime.Today) > 0 ||
                         DateTime.Compare(task.Date, DateTime.Today) == 0 && String.Compare(task.Time, DateTime.Now.ToString("HH:mm")) > 0;
            listOfAllTasks.Add(task);
            SortandSave();
        }

        public void Delete(Task task)
        {
            listOfAllTasks.Remove(task);
            SortandSave();
        }

        public List<Task> GetByDate(DateTime date)
        {
            return listOfAllTasks.Where(t => t.Date == date).ToList();
        }
        public Task FindById(int id)
        {
            var listwithonetask = listOfAllTasks.Where(t => t.Id == id).ToList();
            return listwithonetask[0];
        }

        public void Update(Task task)
        {
            var taskToChange = listOfAllTasks.FindIndex(t => t.Id == task.Id);
            listOfAllTasks[taskToChange] = task;
            SortandSave();
        }
        public List<DateTime> FindAllActual()
        {
            var listofactual = listOfAllTasks.Where(t => t.IsActual == true).ToList();
            List<DateTime> listofdates = new List<DateTime>();
            foreach (var task in listofactual)
            {
                listofdates.Add(task.Date);
            }
            return listofdates;
        }
        
        public static List<Task> GetAll()
        {
            var allTasksAsJson = FileProvider.CreateOrGet(tasksPath);
            var allTasksasList = JsonConvert.DeserializeObject<List<Task>>(allTasksAsJson) ?? new List<Task>();

            foreach (var task in allTasksasList)
            {
                if (DateTime.Compare(task.Date, DateTime.Today) <= 0 &&
                     String.Compare(task.Time, DateTime.Now.ToString("HH:mm")) < 0)
                {
                    task.IsActual = false;
                }
            }
            return allTasksasList;
        }

        public int GenerateId()
        {
            int maxId = 0;
            foreach (var task in listOfAllTasks)
            {
                if (task.Id > maxId)
                    maxId = task.Id;
            }
                return ++maxId;
        }

        private void SortandSave()
        {
            listOfAllTasks = listOfAllTasks.OrderBy(t => t.Date).ThenBy(t=>t.Time).ToList();
            var jsontasks = JsonConvert.SerializeObject(listOfAllTasks, Formatting.Indented);
            FileProvider.Replace(tasksPath, jsontasks);
        }
    }
}
