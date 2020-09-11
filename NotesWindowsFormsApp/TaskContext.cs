using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace NotesWindowsFormsApp
{
   public class TaskContext: DbContext
    {
        public TaskContext(): base ("DBConnection")
        {
            Database.SetInitializer(new TagsDbInitializer());
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Tags> Tags { get; set; }
    }
    class TagsDbInitializer: CreateDatabaseIfNotExists<TaskContext>
    {
        protected override void Seed(NotesWindowsFormsApp.TaskContext context)
        {            
            Tags tags1 = new Tags { Id = 1, Text = "Домашнее" };
            Tags tags2 = new Tags { Id = 2, Text = "Работа" };
            Tags tags3 = new Tags { Id = 3, Text = "Мероприятие" };
            Tags tags4 = new Tags { Id = 4, Text = "Событие" };
            Tags tags5 = new Tags { Id = 5, Text = "Покупки" };

            context.Tags.AddRange(new List<Tags> { tags1, tags2, tags3, tags4, tags5 });            
            context.SaveChanges();
        }
    }
}
