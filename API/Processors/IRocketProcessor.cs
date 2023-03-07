using API.Models;

namespace API.Processors
{
    public interface IRocketProcessor
    {
        Task Create(RocketModel rocketModel);
        Task<JsonLdParser> Get(string id);
        Task<JsonLdParser> GetAll();
      
        Task Update(string id, RocketModel rocketModel);
        Task Delete(string id);
    }
}
