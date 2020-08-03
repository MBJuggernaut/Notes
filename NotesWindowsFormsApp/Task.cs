using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesWindowsFormsApp
{
    public class Task
    {
        public string Date;
        public string Time;
        public string Text;
        public Task()
        {

        }

        public List<Task> GetAll(string path)
        {            
            var tasks = JsonConvert.DeserializeObject<List<Task>>(FileProvider.Get(path));

            return tasks;
        }



    }
}
