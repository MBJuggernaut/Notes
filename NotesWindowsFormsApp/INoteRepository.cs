namespace NotesWindowsFormsApp
{
    interface INoteRepository
    {
        Note Get();
        void Update(Note note);
    }
}
