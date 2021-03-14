using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NotesWindowsFormsApp.Models
{
    public class Tag : BaseEntity
    {
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Тэг может содержать максимум 20 символов.")]
        public string Text { get; set; }

        public virtual List<UserTask> Tasks { get; set; }

        public Tag()
        {
            Tasks = new List<UserTask>();
        }
    }
}
