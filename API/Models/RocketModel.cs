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

    // Parser class
    public class JsonLdParser
    {
        public Context @context { get; set; }
        public string @type { get; set; }

        public List<RocketModel> @list { get; set; } = new List<RocketModel>();
        public JsonLdParser(RocketModel rocket) {
            @context = new Context("MongoDb");
            @type = "Rocket Engine Data";
            @list.Add(rocket);
        }

        public JsonLdParser(List<RocketModel> rocket)
        {
            @context = new Context("MongoDb");
            @type = "Rocket Engine Data";

            foreach (var i in rocket)
            {
                @list.Add(i);
            }
            
        }
        
        /*
        public string ObjectToJsonLd(RocketModel response, string type)
        {
            var properResponse = JArray.Parse(JsonConvert.SerializeObject(response, Formatting.Indented));
            var contextObject = new JObject { { "@schema", "MongoDB" } };

            foreach(var value in properResponse)
            {
                value.First?.AddBeforeSelf(new JProperty("@id", Guid.NewGuid()));
            }

            var convertedObject = new JObject
            {
                { "@context", contextObject},
                { "@type", type },
                { "@list", properResponse }
            };
        
            return JsonConvert.SerializeObject(convertedObject);
        }
        */
    }
}

