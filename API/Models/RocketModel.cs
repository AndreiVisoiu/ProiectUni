using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Globalization;

namespace API.Models
{
    [BsonIgnoreExtraElements]
    public class RocketModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }      
        public string UnitNumber { get; set; }
        public string Time { get; set; }
        public List<string> OperationalSettings { get; set; }
        public List<string> SensorMeasurements { get; set; }

    }
}
