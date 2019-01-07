using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Seldino.CrossCutting.Web.Helpers
{
   public static class JsonHelper
    {
        public static string Serialize(object obj, bool enableCamelCase = true)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            if (enableCamelCase)
            {
                return JsonConvert.SerializeObject(obj, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            }

            return JsonConvert.SerializeObject(obj);
        }

        public static T Deserialize<T>(string serializedValue)
        {
            return string.IsNullOrEmpty(serializedValue)
                ? default(T)
                : JsonConvert.DeserializeObject<T>(serializedValue);
        }
    }
}
