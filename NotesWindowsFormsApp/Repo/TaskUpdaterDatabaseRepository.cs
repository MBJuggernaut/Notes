using NotesWindowsFormsApp.Context;
using NotesWindowsFormsApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace NotesWindowsFormsApp.Repo
{
    public class TaskUpdaterDatabaseRepository : ITaskUpdaterRepository
    {
        private readonly TaskContext context;
        readonly TaskUpdater updater;
        public TaskUpdaterDatabaseRepository(TaskContext context)
        {
            this.context = context;
            updater = context.Updater.First(t => t.Id == 1);
        }
        public void ChangeExitTime()
        {
            updater.LastExitTime = DateTime.Now;
            context.SaveChanges();
        }
        private void ChangeNextUpdateTime()
        {
            updater.NextUpdateTime = updater.NextUpdateTime.AddMonths(1);
            context.SaveChanges();
        }
        public void Update()
        {
            if (UpdateIsNeeded())
            {
                AddDates();
                ChangeNextUpdateTime();
            }
        }
        public void Set()
        {
            //находим все события, будильники которых были установлены на время, пока программа была закрыта
            List<UserTask> tasksWithMissedAlarms = context.Tasks.Where(t => DateTime.Compare(t.AlarmTime, DateTime.Now) < 0).Where(t => DateTime.Compare(t.AlarmTime, updater.LastExitTime) > 0).ToList();
            foreach (var task in tasksWithMissedAlarms)
            {
                task.CountNextAlarmTime();
                context.SaveChanges();
            }
        }
        private void AddDates()
        {
            var countdays = (DateTime.Today - updater.NextUpdateTime).Days + 31;
            var day = context.Dates.Max(t => t.Day);

            for (int i = 0; i <= countdays; i++)
            {
                context.Dates.AddOrUpdate(t => t.Day, new TaskDate { Day = day });
                context.SaveChanges();
                day = day.AddDays(1);
            }

            context.SaveChanges();
        }
        private bool UpdateIsNeeded()
        {
            return DateTime.Compare(updater.NextUpdateTime, DateTime.Today) <= 0;
        }
    }
}
