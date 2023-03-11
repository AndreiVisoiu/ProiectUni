using API.Models;

namespace API.Processors
{
    public interface IRocketProcessor
    {
        Task Create(RocketModel rocketModel);
        Task<String> Get(string id);
        Task<String> GetAll();
      
        Task Update(string id, RocketModel rocketModel);
        Task Delete(string id);
    }
}
