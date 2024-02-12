using Application.Repository;
using Microsoft.AspNetCore.Mvc;
using Project1.DTOs;

namespace Project1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddPublisher(AddPublisherDTO request)
        {
            await _publisherService.AddPublisher(request);
            return Ok(true);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetPublisherDTO>>> GetAllPublishers()
        {
            return Ok(await _publisherService.GetAllPublishers());
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult<bool>> DeletePublisher(string name)
        {
            bool IsPublisherDeleted = await _publisherService.DeletePublisher(name);
            if (!IsPublisherDeleted)
            {
                return Ok(IsPublisherDeleted);
            }
            return Ok(IsPublisherDeleted);
        }
    }
}