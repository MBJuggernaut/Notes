using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesWindowsFormsApp
{
    public class Task
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 5)]       
        public string Time { get; set; }

        public DateTime AlarmTime { get; set; }

        [Required(ErrorMessage = "Поле примечания не должно оставаться пустым. Примечание к заданию должно содержать от 3-х до 50-ти символов.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Примечание к заданию должно содержать от 3-х до 50-ти символов.")]
        public string Text { get; set; }

        public bool IsActual { get; set; }

        public virtual List<Tags> Tags { get; set; }

        public Task()
        {
            Tags = new List<Tags>();
        }       
    }
    public class Tags
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]        
        public int Id { get; set; }

        [StringLength(20, MinimumLength = 1, ErrorMessage = "Тэг может содержать максимум 20 символов.")]
        public string Text { get; set; }

        public virtual List<Task> Tasks { get; set; }

        public Tags()
        {
            Tasks = new List<Task>();
        }        
    }
}
