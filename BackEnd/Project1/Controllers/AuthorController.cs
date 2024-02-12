using Application.Repository;
using Microsoft.AspNetCore.Mvc;
using Project1.DTOs;
using System.Text.RegularExpressions;

namespace Project1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorService;

        public AuthorController(IAuthorRepository authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAuthorDTO>>> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthors();
            if (authors == null)
            {
                return Ok(authors);
            }
            return Ok(authors);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<GetAuthorDTO>> GetAuthorByName(string name)
        {
            var author = await _authorService.GetAuthorByName(name);
            if (author == null)
            {
                return Ok(author);
            }
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddAuthor(AddAuthorDTO request)
        {
            if (request.AuthorName == string.Empty || request.Email == string.Empty || request.Education == string.Empty)
            {
                return BadRequest(false);
            }

            await _authorService.AddAuthor(request);
            return Ok(true);
        }

        [HttpPut("{name}")]
        public async Task<ActionResult<bool>> UpdateAuthor(string name, AddAuthorDTO request)
        {
            bool IsAuthorUpdated = await _authorService.UpdateAuthor(name, request);
            if (!IsAuthorUpdated)
            {
                return Ok(IsAuthorUpdated);
            }
            return Ok(IsAuthorUpdated);
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult<bool>> DeleteAuthor(string name)
        {
            bool IsAuthorDeleted = await _authorService.DeleteAuthor(name);
            if (!IsAuthorDeleted)
            {
                return Ok(IsAuthorDeleted);
            }
            return Ok(IsAuthorDeleted);
        }
    }
}