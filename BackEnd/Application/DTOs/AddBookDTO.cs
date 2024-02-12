namespace Project1.DTOs
{
    public class AddBookDTO
    {
        public string BookName { get; set; }
        public decimal Price { get; set; } = 200;
        public List<string> AuthorNames { get; set; }
        public List<string> GenreNames { get; set; }
        public List<string> PublisherNames { get; set; }
    }
}