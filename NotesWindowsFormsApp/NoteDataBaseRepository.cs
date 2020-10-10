using System.Data.Entity.Migrations;
using System.Linq;

namespace NotesWindowsFormsApp
{
    public class NoteDataBaseRepository : INoteRepository
    {
        private readonly TaskContext context;
        private Note note;

        public NoteDataBaseRepository(TaskContext context)
        {
            this.context = context;
            //note = context.Note.First();
        }
        public string Get()
        {
            note = context.Note.First();
            return note.Text;
        }
        public void Update(string text)
        {
            note = context.Note.First();
            note.Text = text;                 
            context.SaveChanges();

            note = context.Note.First();
        }
    }
}
