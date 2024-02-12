using Domain.Models;

namespace Project1.Models
{
    public class Genre : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string GenreName { get; set; }

        public List<Book> Books { get; set; }
    }
}