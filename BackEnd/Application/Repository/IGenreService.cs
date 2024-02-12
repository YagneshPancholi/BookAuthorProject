using Project1.DTOs;

namespace Application.Repository
{
    public interface IGenreService
    {
        Task<List<GetGenreDTO>> GetAllGenres();

        Task AddGenre(AddGenreDTO request);

        Task<bool> DeleteGenre(string name);
    }
}