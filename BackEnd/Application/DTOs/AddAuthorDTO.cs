namespace Project1.DTOs
{
    public class AddAuthorDTO
    {
        public string AuthorName { get; set; }

        public string BirthDate { get; set; } = DateTime.Now.ToString("d");

        public string? Email { get; set; }

        public string? Education { get; set; }
    }
}