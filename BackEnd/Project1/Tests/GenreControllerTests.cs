using Application.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project1.Controllers;
using Project1.DTOs;

namespace API.Tests
{
    [TestClass]
    public class GenreControllerTests
    {
        [TestMethod]
        public async void GetAllGenre_ShouldReturnAllGenres()
        {
            // arrange
            var _genreService = new Mock<IGenreService>();
            var controller = new GenreController(_genreService.Object);
            AddGenreDTO genre = new AddGenreDTO
            {
                GenreName = "Test"
            };
            // act
            await controller.AddGenre(genre);
            // assert
            _genreService.Verify(r => r.AddGenre(genre), Times.Once);
        }
    }
}