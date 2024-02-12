using Domain.Models;

namespace Project1.Models
{
    public class Publisher : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PublisherName { get; set; } = string.Empty;

        public List<Book> Books { get; set; }
    }
}