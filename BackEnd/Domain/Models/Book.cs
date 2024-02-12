using Domain.Models;

namespace Project1.Models
{
    public class Book : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BookName { get; set; } = String.Empty;

        [Required]
        [Range(0, 9999999999999999.99)]
        public decimal Price { get; set; } = 100;

        public List<Genre> Genres { get; set; }
        public List<Publisher> Publishers { get; set; }

        public List<Author> Authors { get; set; }
    }
}