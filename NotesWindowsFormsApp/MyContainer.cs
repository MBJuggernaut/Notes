using Microsoft.Extensions.DependencyInjection;
using NotesWindowsFormsApp.Context;
using NotesWindowsFormsApp.Providers;
using NotesWindowsFormsApp.Repo;
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
            services.AddSingleton<INoteRepository, NoteDBRepository>();
            services.AddSingleton<IWeatherInfoProvider, WeatherInfoProvider>();

            IServiceProvider provider = services.BuildServiceProvider();
            return provider;
        }
    }
}
