using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesWindowsFormsApp
{
    class FileProvider
    {
        public static void Add(string path, string text)
        {
            var userResultsaver = new StreamWriter(path, true, System.Text.Encoding.UTF8);
            {
                userResultsaver.WriteLine(text);
                userResultsaver.Close();
            }
        }
        public static void Replace(string path, string text)
        {
            var userResultsaver = new StreamWriter(path, false, System.Text.Encoding.UTF8);
            {
                userResultsaver.WriteLine(text);
                userResultsaver.Close();
            }
        }
        public static string Get(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
                return "";
            }
            var userResultreader = new StreamReader(path);
            var allLines = File.ReadAllText(path);
            userResultreader.Close();
            return allLines;
        }
    }
}
