using Microsoft.Extensions.DependencyInjection;
using System;

namespace NotesWindowsFormsApp
{
    public class MyContainer
    {
        public static IServiceProvider Initialize()
        {
            IServiceCollection services = new ServiceCollection();
            var context = new TaskContext();            
            TaskDatabaseRepository taskDatabaseRepository = new TaskDatabaseRepository(context);
            TagDatabaseRepository tagDatabaseRepository = new TagDatabaseRepository(context);
            services.AddSingleton(context);
            services.AddSingleton(taskDatabaseRepository);
            services.AddSingleton(tagDatabaseRepository);
            IServiceProvider provider = services.BuildServiceProvider();            
            return provider;
        }
    }
}
