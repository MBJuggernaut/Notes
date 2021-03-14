using System.Data.Entity.Migrations;
using System.Linq;

namespace NotesWindowsFormsApp
{
    public class NoteDataBaseRepository : INoteRepository
    {
        private readonly TaskContext context;
        private readonly Note note;

        public NoteDataBaseRepository(TaskContext context)
        {
            this.context = context;
            note = context.Note.First();
        }
        public string Get()
        {           
            return note.Text;
        }
        public void Update(string text)
        {           
            note.Text = text;                 
            context.SaveChanges();            
        }
    }
}
