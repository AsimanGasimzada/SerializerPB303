namespace Serializer.Services.Abstractions;

public interface ISerializeService<T> where T : class
{
    List<T> ReadFile(string path);
    void WriteFile(List<T> items, string path);
}
