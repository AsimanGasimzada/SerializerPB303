namespace Serializer.Dtos;

public class PersonPostDto : IDto
{
    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;
    public int Age { get; set; }
}

