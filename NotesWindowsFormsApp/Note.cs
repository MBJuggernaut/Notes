namespace NotesWindowsFormsApp
{
    public class Note
    {
        public string Text;
        readonly string path = "notes.json";
        public Note()
        {
            Text = GetText();
        }

        public string GetText()
        {
            string text = FileProvider.Get(path);

            return text;
        }

        public void Save()
        {
            FileProvider.Replace(path, Text);
        }
    }
}
