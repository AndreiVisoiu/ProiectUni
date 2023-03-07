using API.Common;
using API.Models;
using API.Settings;
using MongoDB.Driver;

namespace API.Services
{
    public class RocketService : IRocketService
    {
        private readonly IMongoCollection<RocketModel> _rocketRepository;
        public RocketService(DatabaseSettings databaseSettings)
        {
            try
            {
                IMongoDatabase database = DatabaseConnection.GetDatabaseConnection(databaseSettings);
                _rocketRepository = database.GetCollection<RocketModel>("Rockets");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Read Rockets by id .
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RocketModel> Get(string id)
        {
            if(String.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id), "Invalid ID");
            }    
            try
            {
                return await _rocketRepository.Find<RocketModel>(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Read Rockets.
        /// </summary>
        /// <returns></returns>
        public async Task<List<RocketModel>> GetAll()
        {
            try
            {
                return await _rocketRepository.Find<RocketModel>(x => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
  
        }


        /// <summary>
        /// Update Rockets by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newRocket"></param>
        /// <returns></returns>
        public async Task Update(string id, RocketModel newRocket)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(id, "Invalid id");  
            }
            if(newRocket == null)
            {
                throw new ArgumentNullException( "Invalid input");
            }
            try
            {
                newRocket.Id = id;
                await _rocketRepository.ReplaceOneAsync<RocketModel>(x => x.Id == id, newRocket);
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }


        /// <summary>
        /// Delete Rockets by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(string id )
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(id, "Invalid id");
            }
            try
            {
                await _rocketRepository.DeleteOneAsync<RocketModel>(x => x.Id == id);
            }

            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public async Task Create(RocketModel rocketModel)
        {
            if(rocketModel == null) 
            {
                throw new ArgumentNullException("Invalid Input");
            }
            try
            {
                await _rocketRepository.InsertOneAsync(rocketModel);
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

    }
}
