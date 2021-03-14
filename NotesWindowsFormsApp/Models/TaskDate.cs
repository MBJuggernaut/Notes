using System;
using System.Collections.Generic;

namespace NotesWindowsFormsApp.Models
{
    public class TaskDate : BaseEntity
    {
        public DateTime Day { get; set; }

        public virtual List<UserTask> Tasks { get; set; }

        public TaskDate()
        {
            Tasks = new List<UserTask>();
        }

    }
}
