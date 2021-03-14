using NotesWindowsFormsApp.Context;
using NotesWindowsFormsApp.Models;
using System.Linq;

namespace NotesWindowsFormsApp.Repo
{
    public class NoteDBRepository : INoteRepository
    {
        private readonly TaskContext context;
        private readonly Note note;

        public NoteDBRepository(TaskContext context)
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
