using System.ComponentModel.DataAnnotations;
namespace Almisbah_library.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Authur { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}