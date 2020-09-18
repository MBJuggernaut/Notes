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
        [Column(TypeName = "datetime2")]
        public DateTime FirstDate { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 5)]       
        public string Time { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime AlarmTime { get; set; }

        [Required(ErrorMessage = "Поле примечания не должно оставаться пустым. Примечание к заданию должно содержать от 3-х до 50-ти символов.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Примечание к заданию должно содержать от 3-х до 50-ти символов.")]
        public string Text { get; set; }      

        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string Repeating { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 5)]      
        public string Alarming { get; set; }
       
        public virtual List<Tag> Tags { get; set; }
        public virtual List<Date> Dates { get; set; }


        public Task()
        {
            Tags = new List<Tag>();
            Dates = new List<Date>();
        }       
    }
}
