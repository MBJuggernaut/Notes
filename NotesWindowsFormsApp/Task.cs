using System.ComponentModel.DataAnnotations;

namespace NotesWindowsFormsApp
{
    public class Task
    {
        [Required]
        public string Date { get; set; }

        [Required]       
        public string Time { get; set; }
        
        [Required(ErrorMessage = "Поле примечания не должно оставаться пустым. Примечание к заданию должно содержать от 3-х до 50-ти символов.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Примечание к заданию должно содержать от 3-х до 50-ти символов.")]
        public string Text { get; set; }

        public bool IsActual = true;


    }
}
