using MongoDB.Bson.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ThirdParty.BouncyCastle.Utilities.IO.Pem;

namespace API.Models
{
    public class JsonLDConvertor
    {
        public String MakeStringOutput(RocketModel rocket)
        {
            var context = new JObject { { "@schema", "MongoDB" } };
            var listaProprietati = JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(rocket, Formatting.Indented));

            listaProprietati.Property("Id").Replace(new JProperty("@id", listaProprietati["Id"]));

            var obiect = new JObject
            {
                { "@context", context },
                { "@type",  "RocketScienceData"},
                { "@list",  listaProprietati}
            };

            return Newtonsoft.Json.JsonConvert.SerializeObject(obiect, Formatting.Indented);
        }

        public String MakeStringOutput(List<RocketModel> rocket)
        {
            var context = new JObject { { "@schema", "MongoDB" } };
            var listaProprietati = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(rocket, Formatting.Indented));

            foreach (JObject item in listaProprietati.Children<JObject>())
            {
                JProperty originalProperty = item.Property("Id");
                if (originalProperty != null)
                {
                    string value = originalProperty.Value.ToString();
                    item.Remove("Id");
                    item.First.AddBeforeSelf(new JProperty("@Id", value));
                }
            }  

            var obiect = new JObject
            {
                { "@context", context },
                { "@type",  "RocketScienceData"},
                { "@list",  listaProprietati}
            };

            return Newtonsoft.Json.JsonConvert.SerializeObject(obiect, Formatting.Indented);
            
        }
    }
}
