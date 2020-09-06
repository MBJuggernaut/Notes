namespace NotesWindowsFormsApp
{
    public class NoteRepository : INoteRepository
    {
        readonly string notePath = "notes.json";
        public Note Get()
        {
            Note note = new Note
            { Text = FileProvider.CreateOrGet(notePath) };

            return note;
        }
        public void Update(Note note)
        {
            FileProvider.Replace(notePath, note.Text);
        }
    }
}
