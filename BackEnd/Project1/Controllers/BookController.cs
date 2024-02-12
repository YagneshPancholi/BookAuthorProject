using Application.Repository;
using Microsoft.AspNetCore.Mvc;
using Project1.DTOs;

namespace Project1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AddBookDTO>>> GetAllBooks()
        {
            var books = await _bookService.GetAllBooks();
            if (books == null)
            {
                return Ok(books);
            }
            return Ok(books);
        }

        [HttpGet("{bookName}")]
        public async Task<ActionResult<AddBookDTO>> GetBookByName(string bookName)
        {
            var request = await _bookService.GetBookByName(bookName);
            if (request == null)
            {
                return Ok(request);
            }
            return Ok(request);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddBook(AddBookDTO request)
        {
            bool IsBookAdded = await _bookService.AddBook(request);
            if (!IsBookAdded)
            {
                return Ok(IsBookAdded);
            }
            return Ok(IsBookAdded);
        }

        [HttpPut("{bookName}")]
        public async Task<ActionResult<bool>> UpdateBook(string bookName, AddBookDTO request)
        {
            bool IsBookUpdated = await _bookService.UpdateBook(bookName, request);
            if (!IsBookUpdated)
            {
                return Ok(IsBookUpdated);
            }
            return Ok(IsBookUpdated);
        }

        [HttpDelete("{bookName}")]
        public async Task<ActionResult<bool>> DeleteBook(string bookName)
        {
            bool IsBookDeleted = await _bookService.DeleteBook(bookName);
            if (!IsBookDeleted)
            {
                return Ok(IsBookDeleted);
            }
            return Ok(IsBookDeleted);
        }
    }
}