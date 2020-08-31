using System;
using System.Collections.Generic;

namespace NotesWindowsFormsApp
{
    class TaskDatabaseRepository : ITaskRepository
    {
        public void Add(Task task)
        {
            throw new NotImplementedException();
        }

        public void Delete(Task task)
        {
            throw new NotImplementedException();
        }

        public List<DateTime> FindAllActual()
        {
            throw new NotImplementedException();
        }

        public Task FindbyId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Task> GetByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public void Update(Task task)
        {
            throw new NotImplementedException();
        }
    }
}
