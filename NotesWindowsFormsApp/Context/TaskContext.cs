using System.Data.Entity;

namespace NotesWindowsFormsApp
{
    public class TaskContext : DbContext
    {
        public TaskContext() : base("TaskDB")
        {
            Database.SetInitializer(new DbInitializer());
        }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TaskDate> Dates { get; set; }
        public DbSet<TaskUpdater> Updater { get; set; }
        public DbSet<Note> Note { get; set; }
    }
}
