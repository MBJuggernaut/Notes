﻿using System;
using System.Collections.Generic;

namespace NotesWindowsFormsApp
{
    interface ITaskRepository
    {
        List<Task> GetByDate(DateTime date);
        void Update(Task task);
        void Delete(int id);
        void Add(Task task);
        List<DateTime> FindAllActual();
        Task FindById(int id);
    }
}