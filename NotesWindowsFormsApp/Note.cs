using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesWindowsFormsApp
{
    public class Note
    {
        public string Text;
        string path = "notes.json";
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
