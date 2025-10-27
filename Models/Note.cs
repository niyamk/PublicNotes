using System.ComponentModel.DataAnnotations;

namespace PublicNotes.Models
{
    public class Note
    {
        // This will be the unique ID for each note (e.g., 1, 2, 3...)
        public int Id { get; set; }

        [Required] // Makes this field mandatory
        public string? Title { get; set; }

        [Required]
        public string? Content { get; set; }

        // Automatically set the time when the note is created
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}