using System;
using System.Collections.Generic;

namespace NotesWindowsFormsApp
{
    interface ITaskRepository
    {
        List<Task> GetByDate(DateTime date);
        void Update(Task task);
        void Delete(Task task);
        void Add(Task task);
        List<DateTime> FindAllActual();
        Task FindbyId(int id);


    }
}
