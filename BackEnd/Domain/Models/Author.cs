global using System.ComponentModel.DataAnnotations;
using Domain.Models;

namespace Project1.Models
{
    public class Author : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string Education { get; set; }

        public List<Book> Books { get; set; }
    }
}