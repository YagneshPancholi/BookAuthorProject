using Application.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using persistance;
using Project1.Data;
using Project1.DTOs;
using Project1.Models;
using System.Data;

namespace Project1.Services.AuthorService
{
    public class AuthorService : IAuthorRepository
    {
        private readonly Project1DbContext _context;
        private readonly IDeleteAuthor _deleteAuthor;

        public AuthorService(Project1DbContext context, IConfiguration configuration)
        {
            _context = context;
            _deleteAuthor = new DeleteAuthorService(configuration);
        }

        public async Task AddAuthor(AddAuthorDTO request)
        {
            var dateTimeStringArr = request.BirthDate.Split(" ");
            var dateStringArr = dateTimeStringArr[0].Split("/");
            var month = Convert.ToInt32(dateStringArr[0]);
            var day = Convert.ToInt32(dateStringArr[1]);
            var year = Convert.ToInt32(dateStringArr[2]);
            var author = new Author
            {
                AuthorName = request.AuthorName,
                BirthDate = new DateTime(year, month, day),
                Education = request.Education,
                Email = request.Email,
                CreationDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, PublisherService.PublisherService.INDIAN_ZONE)
            };
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAuthor(string name)
        {
            bool IsAuthorDeleted = false;
            await _deleteAuthor.DeleteAuthorAsync(name).ContinueWith(task =>
            {
                if (task.Result)
                {
                    IsAuthorDeleted = true;
                }
            });
            return IsAuthorDeleted;
        }

        public async Task<List<GetAuthorDTO>> GetAllAuthors()
        {
            var value = await _context.Authors.FromSqlRaw("spAuthors_GetAllAuthors").ToListAsync();

            return value.Select(x => new GetAuthorDTO
            {
                AuthorName = x.AuthorName,
                BirthDate = x.BirthDate.ToString(),
                Education = x.Education,
                Email = x.Email,
            }).ToList();
        }

        public async Task<GetAuthorDTO> GetAuthorByName(string name)
        {
            var author = await _context.Authors.FromSqlInterpolated($"spAuthors_GetAuthorByName {name}").ToListAsync();
            if (!author.Any())
            {
                return null;
            }
            return author.Select(x => new GetAuthorDTO
            {
                AuthorName = x.AuthorName,
                BirthDate = x.BirthDate.ToString(),
                Education = x.Education,
                Email = x.Email,
            }).Single();
        }

        public async Task<bool> UpdateAuthor(string name, AddAuthorDTO request)
        {
            var authors = _context.Authors.Where(s => s.AuthorName == name);
            if (!authors.Any())
            {
                return false;
            }
            request.BirthDate = request.BirthDate.Split(" ")[0];
            var dateStringArr = request.BirthDate.Split("/");
            var month = Convert.ToInt32(dateStringArr[0]);
            var day = Convert.ToInt32(dateStringArr[1]);
            var year = Convert.ToInt32(dateStringArr[2]);
            var value = authors.First();
            value.AuthorName = request.AuthorName;
            value.BirthDate = new DateTime(year, month, day);
            value.Education = request.Education;
            value.Email = request.Email;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}