using System;
using System.Collections.Generic;

namespace NotesWindowsFormsApp
{
    public class TaskDate : BaseEntity
    {
        public DateTime Day { get; set; }

        public virtual List<Task> Tasks { get; set; }

        public TaskDate()
        {
            Tasks = new List<Task>();
        }

    }
}
