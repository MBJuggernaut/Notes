using System;
using System.Windows.Forms;

namespace NotesWindowsFormsApp
{
    static class Program
    {
        //public static IServiceProvider ServiceProvider { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
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
