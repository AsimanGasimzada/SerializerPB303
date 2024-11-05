using Newtonsoft.Json;
using Serializer.Services.Abstractions;

namespace Serializer.Services.Implementations;

public class JsonSerializerService<T> : ISerializeService<T> where T : class
{
    public List<T> ReadFile(string path)
    {
        using(StreamReader reader=new (path))
        {
            string data=reader.ReadToEnd();

            var result=JsonConvert.DeserializeObject<List<T>>(data);

            return result ?? new();
        }
    }

    public void WriteFile(List<T> items, string path)
    {
       var json=JsonConvert.SerializeObject(items);

        using(StreamWriter writer=new(path))
        {
            writer.Write(json);
        }
    }
}
