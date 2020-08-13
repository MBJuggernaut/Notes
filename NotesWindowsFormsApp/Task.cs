using System.ComponentModel.DataAnnotations;

namespace NotesWindowsFormsApp
{
    public class Task
    {
        [Required]
        public string Date { get; set; }

        [Required]       
        public string Time { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Примечание к заданию должно быть не менее 3-х символов")]        
        public string Text { get; set; }

        public bool IsActual = true;
    }
}
