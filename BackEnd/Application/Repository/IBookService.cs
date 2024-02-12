using Project1.DTOs;

namespace Application.Repository
{
    public interface IBookService
    {
        Task<AddBookDTO> GetBookByName(string bookName);

        Task<List<AddBookDTO>> GetAllBooks();

        Task<bool> AddBook(AddBookDTO request);

        Task<bool> UpdateBook(string name, AddBookDTO request);

        Task<bool> DeleteBook(string bookName);
    }
}