using Project1.DTOs;

namespace Application.Repository
{
    public interface IAuthorRepository
    {
        Task<GetAuthorDTO> GetAuthorByName(string authorName);

        Task<List<GetAuthorDTO>> GetAllAuthors();

        Task AddAuthor(AddAuthorDTO Author);

        Task<bool> UpdateAuthor(string name, AddAuthorDTO Author);

        Task<bool> DeleteAuthor(string name);
    }
}