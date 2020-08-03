using System.IO;
using System.Threading;

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
            StreamReader text;  
            string allLines;
            if (!File.Exists(path))
            {
                File.Create(path);
                return "";
            }
            
            try
            {
                text = new StreamReader(path);
                allLines = File.ReadAllText(path);
            }
            catch
            {
                Thread.Sleep(100);
                text = new StreamReader(path);
                allLines = File.ReadAllText(path);
            }

            text.Close();
            return allLines;
        }
    }
}
