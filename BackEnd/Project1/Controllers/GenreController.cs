using Application.Repository;
using Microsoft.AspNetCore.Mvc;
using Project1.DTOs;

namespace Project1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddGenre(AddGenreDTO request)
        {
            await _genreService.AddGenre(request);
            return Ok(true);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetGenreDTO>>> GetAllGenres()
        {
            return Ok(await _genreService.GetAllGenres());
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult<bool>> DeleteGenre(string name)
        {
            var IsGenreDeleted = await _genreService.DeleteGenre(name);
            if (!IsGenreDeleted)
            {
                return Ok(IsGenreDeleted);
            }
            return Ok(IsGenreDeleted);
        }
    }
}