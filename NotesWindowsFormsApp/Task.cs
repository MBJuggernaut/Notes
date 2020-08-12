using System.ComponentModel.DataAnnotations;

namespace NotesWindowsFormsApp
{
    public class Task
    {
        [Required]
        public string Date;
        [Required]
        [RegularExpression(@"^\+[1-9]\d{2}:\d{2}$", ErrorMessage = "Дата должна иметь формать ЧЧ:мм")]
        public string Time;
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Примечание к заданию должно быть не менее 3-х символов")]
        public string Text;
    }
}
