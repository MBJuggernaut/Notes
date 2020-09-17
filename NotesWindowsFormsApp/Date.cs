using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesWindowsFormsApp
{
    public class Date
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Day { get; set; }

        public virtual List<Task> Tasks { get; set; }

        public Date()
        {
            Tasks = new List<Task>();
        }

    }
}
