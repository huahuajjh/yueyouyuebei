using Newtonsoft.Json;

namespace TravelAgent.Tool
{
    public static class SerializationUtil
    {
        public static string ToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T ToObj<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
