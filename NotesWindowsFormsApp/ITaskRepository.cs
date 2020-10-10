using System;
using System.Collections.Generic;

namespace NotesWindowsFormsApp
{
    public interface ITaskRepository
    {
        List<Task> GetByDate(DateTime date);
        void Update(Task task);
        void Delete(int id);
        void TryToAdd(Task task);        
        Task FindById(int id);
        List<Task> GetTodayAlerts();
        List<DateTime> FindAllActualDates();
        List<Task> GetAll();


    }
}
