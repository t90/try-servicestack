using System;
using System.IO;
using Newtonsoft.Json;
using ServiceStack.DesignPatterns.Serialization;

namespace try_servicestack
{
    public class JsonNetSerializer : ITextSerializer
    {
        #region ITextSerializer Members

        public object DeserializeFromString(string json, Type returnType)
        {
            return JsonConvert.DeserializeObject(json, returnType);
        }

        public T DeserializeFromString<T>(string json)
        {
            return (T) DeserializeFromString(json, typeof (T));
        }

        public T DeserializeFromStream<T>(Stream stream)
        {
            return (T) DeserializeFromStream(typeof (T), stream);
        }

        public object DeserializeFromStream(Type type, Stream stream)
        {
            var jsonSerializer = new JsonSerializer();
            using(var sr = new StreamReader(stream))
            using(var r = new JsonTextReader(sr))
            {
                return jsonSerializer.Deserialize(r, type);
            }
        }

        public string SerializeToString<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public void SerializeToStream<T>(T obj, Stream stream)
        {
            var jsonSerializer = new JsonSerializer();
            using (var streamWriter = new StreamWriter(stream))
            using(var w = new JsonTextWriter(streamWriter))
            {
                jsonSerializer.Serialize(w, obj);
            }
        }

        #endregion
    }
}