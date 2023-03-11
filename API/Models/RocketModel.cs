using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Globalization;

using Newtonsoft.Json;

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
        public List<string> OperationalSettigs { get; set; }
        public List<string> SensorMeasurements { get; set; }

    }

    // Parser class
    public class JsonLdParser
    {
 

        public List<RocketModel> list { get; set; } = new List<RocketModel>();
        public JsonLdParser(RocketModel rocket)
        {
            list.Add(rocket);
        }

        public JsonLdParser(List<RocketModel> rocket)
        {
            foreach (var i in rocket)
            {
                list.Add(i);
            }

        }

        public String MakeStringOutput(RocketModel rocket)
        {
            String output = "{\n"; // Initializeaza output

            output += "  \"@context\": {\n";
            output += "   \"@schema\": \"MongoDB\"\n";
            output += "  },\n";
            output += "  \"@type\": \"Rocket Science Data\",\n";
            output += "  \"@list\": [\n";
            foreach (var value in list)
            {
                output += "\t{\n\t";
                output += "    \"@id\": \"" + value.Id + "\",\n";
                output += "\t    \"UnitNumber\": \"" + value.UnitNumber + "\",\n";
                output += "\t    \"Time\": \"" + value.Time + "\", \n";


                output += "\t    \"OperationalSettings\": [\n";
                foreach (var operationalSetting in value.OperationalSettigs)
                {
                    output += "\t      \"" + operationalSetting + "\",\n";
                }
                output += "\t    ],\n";

                output += "\t    \"SensorMeasurement\": [\n";
                foreach (var sensorMeasurement in value.SensorMeasurements)
                {
                    output += "\t      \"" + sensorMeasurement + "\",\n";
                }
                output += "\t    ]\n";
            }

            output += "\t}\n     ]\n }";

            return output;
        }

        public String MakeStringOutput(List<RocketModel> rocket)
        {
            String output = "{\n"; // Initializeaza output

            output += "  \"@context\": {\n";
            output += "   \"@schema\": \"MongoDB\"\n";
            output += "  },\n";
            output += "  \"@type\": \"Rocket Science Data\",\n";
            output += "  \"@list\": [\n";
            foreach (var value in list)
            {
                output += "\t{\n\t";
                output += "    \"@id\": \"" + value.Id + "\",\n";
                output += "\t    \"UnitNumber\": \"" + value.UnitNumber + "\",\n";
                output += "\t    \"Time\": \"" + value.Time + "\", \n";


                output += "\t    \"OperationalSettings\": [\n";
                foreach (var operationalSetting in value.OperationalSettigs)
                {
                    output += "\t      \"" + operationalSetting + "\",\n";
                }
                output += "\t    ],\n";

                output += "\t    \"SensorMeasurement\": [\n";
                foreach(var sensorMeasurement in value.SensorMeasurements)
                {
                    output += "\t      \"" + sensorMeasurement + "\",\n";
                }
                output += "\t    ]\n";    
            }

            output += "\t}\n     ]\n }";

            return output;
        }   
    }
}
