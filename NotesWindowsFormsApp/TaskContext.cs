using System.Data.Entity;

namespace NotesWindowsFormsApp
{
    class TaskContext: DbContext
    {
        public TaskContext(): base ("DBConnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<TaskContext, EF6Console.Migrations.Configuration>();
        }

        public DbSet<Task> Tasks { get; set; }
    }
}
