using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesWindowsFormsApp
{
    public class Tag
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]        
        public int Id { get; set; }

        [StringLength(20, MinimumLength = 1, ErrorMessage = "Тэг может содержать максимум 20 символов.")]
        public string Text { get; set; }

        public virtual List<Task> Tasks { get; set; }

        public Tag()
        {
            Tasks = new List<Task>();
        }        
    }    
}
