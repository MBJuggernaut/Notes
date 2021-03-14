namespace NotesWindowsFormsApp
{
    interface INoteRepository
    {
        string Get();
        void Update(string text);
    }
}
