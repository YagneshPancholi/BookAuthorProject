using Application.Repository;
using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.DTOs;
using Project1.Models;

namespace Project1.Services.GenreService
{
    public class GenreService : IGenreService
    {
        private readonly Project1DbContext _context;

        public GenreService(Project1DbContext context)
        {
            _context = context;
        }

        public async Task AddGenre(AddGenreDTO request)
        {
            var value = new Genre
            {
                GenreName = request.GenreName,
                CreationDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, PublisherService.PublisherService.INDIAN_ZONE)
            };
            _context.Genres.Add(value);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteGenre(string name)
        {
            var value = _context.Genres.Where(s => s.GenreName == name);
            if (!value.Any())
            {
                return false;
            }
            _context.Genres.Remove(value.First());
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<GetGenreDTO>> GetAllGenres()
        {
            return await _context.Genres.Select(s => new GetGenreDTO
            {
                GenreName = s.GenreName,
            }).ToListAsync();
        }
    }
}