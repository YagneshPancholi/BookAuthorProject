namespace Project1.Models
{
    public class BookGenre
    {
        [Key]
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}