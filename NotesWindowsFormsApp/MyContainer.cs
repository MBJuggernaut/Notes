using Microsoft.Extensions.DependencyInjection;
using System;

namespace NotesWindowsFormsApp
{
    public class MyContainer
    {
        public static IServiceProvider Initialize()
        {
            IServiceCollection services = new ServiceCollection();            
            services.AddSingleton<TaskContext>();
            services.AddSingleton<ITaskRepository, TaskDatabaseRepository>();
            services.AddSingleton<ITagRepository, TagDatabaseRepository>();
            services.AddSingleton<ITaskUpdaterRepository, TaskUpdaterDatabaseRepository>();
            services.AddSingleton<INoteRepository, NoteDataBaseRepository>();

            IServiceProvider provider = services.BuildServiceProvider();                        
            return provider;
        }
    }
}
