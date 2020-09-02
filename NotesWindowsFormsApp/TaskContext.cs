using System.Data.Entity;

namespace NotesWindowsFormsApp
{
    class TaskContext: DbContext
    {
        public TaskContext(): base ("DBConnection")
        {
            
        }

        public DbSet<Task> Tasks { get; set; }
    }
}
