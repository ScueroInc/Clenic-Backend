using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyE.Business.Component.Helpers
{
    public static class ConvertHelper
    {
        public static byte[] ToByteArray(object obj)
        {
            var bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        public static T FromByteArray<T>(byte[] data)
        {
            var bf = new BinaryFormatter();
            using (var ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }
    }
}
