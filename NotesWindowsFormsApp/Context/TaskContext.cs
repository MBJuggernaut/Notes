using NotesWindowsFormsApp.Models;
using System.Data.Entity;

namespace NotesWindowsFormsApp.Context
{
    public class TaskContext : DbContext
    {
        public TaskContext() : base("TaskDB")
        {
            Database.SetInitializer(new DbInitializer());
        }
        public DbSet<UserTask> Tasks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TaskDate> Dates { get; set; }
        public DbSet<TaskUpdater> Updater { get; set; }
        public DbSet<Note> Note { get; set; }
    }
}
