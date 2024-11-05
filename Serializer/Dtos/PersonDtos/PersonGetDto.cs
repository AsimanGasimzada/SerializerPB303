namespace Serializer.Dtos;

public class PersonGetDto : IDto
{
    public int Id { get; set; }
    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;
    public int Age { get; set; }
}

