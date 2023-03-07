using API.Models;

namespace API.Services
{
    public interface IRocketService
    {
        Task Create(RocketModel rocketModel);
        Task<RocketModel> Get(string id);
        Task<List<RocketModel>> GetAll();
     
        Task Update(string id, RocketModel rocketModel); 
        Task Delete(string id);
    }
}
