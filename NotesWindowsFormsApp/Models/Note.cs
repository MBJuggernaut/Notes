using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesWindowsFormsApp
{
    public class Note
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]        
        [Range(0, 2)]
        public int Id { get; set; }
        
        public string Text { get; set; }
    }
}
