using System.IO;

namespace NotesWindowsFormsApp
{
    class FileProvider
    {
        public static void Add(string path, string text)
        {
            var textsaver = new StreamWriter(path, true, System.Text.Encoding.UTF8);

            textsaver.WriteLine(text);
            textsaver.Close();
        }
        public static void Replace(string path, string text)
        {
            var textsaver = new StreamWriter(path, false, System.Text.Encoding.UTF8);

            textsaver.WriteLine(text);
            textsaver.Close();

        }
        public static string Get(string path)
        {
            StreamReader text;
            text = new StreamReader(path);
            var allLines = File.ReadAllText(path);
            text.Close();
            return allLines;
        }
        public static string CreateOrGet(string path)
        {
            if (!File.Exists(path))
            { File.Create(path); return ""; }

            else
              return Get(path);
        }
            
    }
}
