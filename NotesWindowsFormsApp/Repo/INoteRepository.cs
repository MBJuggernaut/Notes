namespace NotesWindowsFormsApp.Repo
{
    public interface INoteRepository
    {
        string Get();
        void Update(string text);
    }
}
