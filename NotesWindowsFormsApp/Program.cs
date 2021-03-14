using System;
using System.Windows.Forms;

namespace NotesWindowsFormsApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var provider = MyContainer.Initialize();
            Application.Run(new MainForm(provider));
        }
    }
}
