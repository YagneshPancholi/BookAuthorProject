using Project1.DTOs;

namespace Application.Repository
{
    public interface IPublisherService
    {
        Task<List<GetPublisherDTO>> GetAllPublishers();

        Task AddPublisher(AddPublisherDTO request);

        Task<bool> DeletePublisher(string name);
    }
}