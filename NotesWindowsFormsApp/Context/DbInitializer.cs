using NotesWindowsFormsApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace NotesWindowsFormsApp.Context
{
    public class DbInitializer : CreateDatabaseIfNotExists<TaskContext>
    {
        protected override void Seed(TaskContext context)
        {
            Tag tags1 = new Tag { Id = 1, Text = "Домашнее" };
            Tag tags2 = new Tag { Id = 2, Text = "Работа" };
            Tag tags3 = new Tag { Id = 3, Text = "Мероприятие" };
            Tag tags4 = new Tag { Id = 4, Text = "Событие" };
            Tag tags5 = new Tag { Id = 5, Text = "Покупки" };

            context.Tags.AddRange(new List<Tag> { tags1, tags2, tags3, tags4, tags5 });

            var day = DateTime.Today;

            TaskUpdater updater = new TaskUpdater { LastExitTime = day, NextUpdateTime = day.AddMonths(1) };
            context.Updater.Add(updater);

            List<TaskDate> dates = new List<TaskDate>();
            for (int i = 0; i < 3650; i++)
            {
                dates.Add(new TaskDate { Day = day });
                day = day.AddDays(1);
            }
            context.Dates.AddRange(dates);
            Note note = new Note() { Text = "Hello, world!" };
            context.Note.Add(note);

            context.SaveChanges();
        }
    }
}
