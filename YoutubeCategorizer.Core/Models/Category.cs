using System.ComponentModel.DataAnnotations;

namespace YoutubeCategorizer.Core.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        // Navigation Property (1 category -> many videos)
        public List<Video> Videos { get; set; } = new();
    }
}