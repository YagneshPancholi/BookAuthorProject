using Application.Repository;
using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.DTOs;
using Project1.Models;

namespace Project1.Services.PublisherService
{
    public class PublisherService : IPublisherService
    {
        public static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        private readonly Project1DbContext _context;

        public PublisherService(Project1DbContext context)
        {
            _context = context;
        }

        public async Task AddPublisher(AddPublisherDTO request)
        {
            var value = new Publisher
            {
                PublisherName = request.PublisherName,
                CreationDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE)
            };
            _context.Publishers.Add(value);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeletePublisher(string name)
        {
            var value = _context.Publishers.Where(s => s.PublisherName == name);
            if (!value.Any())
            {
                return false;
            }
            _context.Publishers.Remove(value.First());
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<GetPublisherDTO>> GetAllPublishers()
        {
            return await _context.Publishers.Select(x => new GetPublisherDTO
            {
                PublisherName = x.PublisherName,
            }
            ).ToListAsync();
        }
    }
}