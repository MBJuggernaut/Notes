using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesWindowsFormsApp.Models
{
    public class TaskUpdater
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        [Range(0, 2)]
        public int Id { get; set; }
        public DateTime LastExitTime { get; set; }
        public DateTime NextUpdateTime { get; set; }
    }
}
