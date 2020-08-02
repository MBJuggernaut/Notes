using System.IO;

namespace NotesWindowsFormsApp
{
    class FileProvider
    {
        public static void Add(string path, string text)
        {
            var textsaver = new StreamWriter(path, true, System.Text.Encoding.UTF8);
            {
                textsaver.WriteLine(text);
                textsaver.Close();
            }
        }
        public static void Replace(string path, string text)
        {
            var textsaver = new StreamWriter(path, false, System.Text.Encoding.UTF8);
            {
                textsaver.WriteLine(text);
                textsaver.Close();
            }
        }
        public static string Get(string path)
        {            
            string allLines;
            if (!File.Exists(path))
            {
                File.Create(path);
                return "";
            }
            var text = new StreamReader(path);
            try
            {                
                allLines = File.ReadAllText(path);
            }
            catch
            {
                text.Close();
                allLines = File.ReadAllText(path);
            }
           

            
            text.Close();
            return allLines;
        }
    }
}
