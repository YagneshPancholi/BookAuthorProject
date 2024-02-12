using Application.Repository;
using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.DTOs;
using Project1.Models;

namespace Project1.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly Project1DbContext _context;

        public BookService(Project1DbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBook(AddBookDTO request)
        {
            if (!request.AuthorNames.Any() || !request.GenreNames.Any() || !request.PublisherNames.Any())
            {
                return false;
            }

            List<Author> authors = new List<Author>();
            foreach (string name in request.AuthorNames)
            {
                var author = _context.Authors.Where(s => s.AuthorName == name);
                if (author.Any())
                {
                    authors.Add(author.First());
                }
            }

            List<Genre> genres = new List<Genre>();
            foreach (string name in request.GenreNames)
            {
                var genre = _context.Genres.Where(s => s.GenreName == name);
                if (genre.Any())
                {
                    genres.Add(genre.First());
                }
            }

            List<Publisher> publishers = new List<Publisher>();
            foreach (string name in request.PublisherNames)
            {
                var publisher = _context.Publishers.Where(s => s.PublisherName == name);
                if (publisher.Any())
                {
                    publishers.Add(publisher.First());
                }
            }
            if (!authors.Any() || !genres.Any() || !publishers.Any())
            {
                return false;
            }
            var book = new Book
            {
                BookName = request.BookName,
                Price = request.Price,
                Authors = authors,
                Genres = genres,
                Publishers = publishers,
                CreationDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, PublisherService.PublisherService.INDIAN_ZONE)
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBook(string bookName)
        {
            var value = _context.Books.Where(x => x.BookName == bookName);
            if (!value.Any())
            {
                return false;
            }
            _context.Books.Remove(value.First());
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<AddBookDTO>> GetAllBooks()
        {
            return await _context.Books.Select(s => new AddBookDTO
            {
                BookName = s.BookName,
                Price = s.Price,
                AuthorNames = s.Authors.Select(x => new string(x.AuthorName)).ToList(),
                GenreNames = s.Genres.Select(x => new string(x.GenreName)).ToList(),
                PublisherNames = s.Publishers.Select(x => new string(x.PublisherName)).ToList()
            }).ToListAsync();
        }

        public async Task<AddBookDTO> GetBookByName(string bookName)
        {
            var value = _context.Books.Where(x => x.BookName == bookName);
            if (!value.Any())
            {
                return null;
            }
            return await value.Select(s => new AddBookDTO
            {
                BookName = s.BookName,
                Price = s.Price,
                AuthorNames = s.Authors.Select(x => new string(x.AuthorName)).ToList(),
                GenreNames = s.Genres.Select(x => new string(x.GenreName)).ToList(),
                PublisherNames = s.Publishers.Select(x => new string(x.PublisherName)).ToList()
            }).FirstAsync();
        }

        public async Task<bool> UpdateBook(string bookName, AddBookDTO request)
        {
            var value = _context.Books.Where(s => s.BookName == bookName).Include("Authors").Include("Genres").Include("Publishers");
            if (!request.AuthorNames.Any() || !request.GenreNames.Any() || !request.PublisherNames.Any() || !value.Any())
            {
                return false;
            }
            Book bookToUpdate = value.First();
            List<Author> authors = new List<Author>();
            foreach (string name in request.AuthorNames)
            {
                var author = _context.Authors.Where(s => s.AuthorName == name);
                if (author.Any())
                {
                    authors.Add(author.First());
                }
            }
            if (!authors.Any())
            {
                return false;
            }
            List<Genre> genres = new List<Genre>();
            foreach (string name in request.GenreNames)
            {
                var genre = _context.Genres.Where(s => s.GenreName == name);
                if (genre.Any())
                {
                    genres.Add(genre.First());
                }
            }
            if (!genres.Any())
            {
                return false;
            }
            List<Publisher> publishers = new List<Publisher>();
            foreach (string name in request.PublisherNames)
            {
                var publisher = _context.Publishers.Where(s => s.PublisherName == name);
                if (publisher.Any())
                {
                    publishers.Add(publisher.First());
                }
            }
            if (!publishers.Any())
            {
                return false;
            }

            bookToUpdate.BookName = request.BookName;
            bookToUpdate.Price = request.Price;
            bookToUpdate.Authors = authors;
            bookToUpdate.Genres = genres;
            bookToUpdate.Publishers = publishers;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}