using System.Collections.Generic;

namespace NotesWindowsFormsApp
{
    interface ITaskRepository
    {        
        List<Task> GetAll();
        void Update(List<Task> listOfTasks);       
    }
}
