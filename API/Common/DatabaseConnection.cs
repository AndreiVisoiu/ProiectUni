using API.Settings;
using MongoDB.Driver;

namespace API.Common
{
    public class DatabaseConnection
    {
        public static IMongoDatabase GetDatabaseConnection(DatabaseSettings databaseSettings)
        {
            /*
            if (databaseSettings == null)
            {
                throw new ArgumentNullException(nameof(databaseSettings));
            }
            if(String.IsNullOrWhiteSpace(databaseSettings.ConnectionString) ||
                String.IsNullOrWhiteSpace(databaseSettings.Server)   ||
                String.IsNullOrWhiteSpace(databaseSettings.Username) || 
                String.IsNullOrWhiteSpace(databaseSettings.Password) ||
                String.IsNullOrWhiteSpace(databaseSettings.Database))
            {
                throw new ArgumentException("invalid  property settings");
            }
            try
            {
                string connectionString = databaseSettings.ConnectionString;
                connectionString = connectionString.Replace("<server>", databaseSettings.Server);
                connectionString = connectionString.Replace("<username>", databaseSettings.Username);
                connectionString = connectionString.Replace("<password>", databaseSettings.Password);

                MongoClient client = new MongoClient(connectionString);
                IMongoDatabase database = client.GetDatabase(databaseSettings.Database);

                return database;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            */
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://RocketDataUser:RocketDataPassword@rocketdata.aou1nyo.mongodb.net/?retryWrites=true&w=majority");
            //settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("RocketDataDB");
            return database;
        }
    }
}
