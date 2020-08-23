using Newtonsoft.Json;
using System.Collections.Generic;

namespace NotesWindowsFormsApp
{
    interface ITaskRepository
    {        
        List<Task> GetAll();
        void Update(List<Task> listOfTasks);       
    }
    public class TaskRepository : ITaskRepository
    {
        readonly string tasksPath = "tasks.json";
        public List<Task> GetAll()
        {
            var allTasksAsJson = FileProvider.CreateOrGet(tasksPath);
            var allTasksasList = JsonConvert.DeserializeObject<List<Task>>(allTasksAsJson) ?? new List<Task>();
            return allTasksasList;
        }               
        public void Update(List<Task> listOfAllTasks)
        {
            var jsontasks = JsonConvert.SerializeObject(listOfAllTasks, Formatting.Indented);
            FileProvider.Replace(tasksPath, jsontasks);
        }        
    }
}
