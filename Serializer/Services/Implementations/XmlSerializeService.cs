using Serializer.Services.Abstractions;
using System.Xml.Serialization;

namespace Serializer.Services.Implementations;

public class XmlSerializeService<T> : ISerializeService<T> where T : class
{
    private readonly XmlSerializer _serializer;
    public XmlSerializeService()
    {
        _serializer = new XmlSerializer(typeof(List<T>));
    }

    public List<T> ReadFile(string path)
    {
        using (StreamReader reader = new(path))
        {
            var result = (List<T>)_serializer.Deserialize(reader);

            return result;
        }
    }

    public void WriteFile(List<T> items, string path)
    {
        using (StreamWriter writer = new(path))
        {
            _serializer.Serialize(writer, items);
        }
    }
}
