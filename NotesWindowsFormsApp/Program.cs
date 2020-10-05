using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace NotesWindowsFormsApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IServiceCollection services = new ServiceCollection();
            services.AddSingleton(new TaskContext());
            var provider = services.BuildServiceProvider();

            Application.Run(new MainForm() {Provider = provider });
        }
    }
}
