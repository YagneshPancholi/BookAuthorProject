namespace Project1.Models
{
    public class BookPublisher
    {
        [Key]
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int PublisherId { get; set; }

        public Publisher Publisher { get; set; }
    }
}