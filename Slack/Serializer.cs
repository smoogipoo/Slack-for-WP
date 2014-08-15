using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Slack_for_WP.Slack
{
    class Serializer
    {
        internal static string Serialize<T>(T data)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                serializer.WriteObject(ms, data);
                return Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
            }
        }

        internal static T Deserialize<T>(string data)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                T ret = (T)serializer.ReadObject(ms);
                return ret;
            }
        }
    }
}
