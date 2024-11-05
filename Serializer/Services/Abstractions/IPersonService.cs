using Serializer.Dtos;
using Serializer.Models;

namespace Serializer.Services.Abstractions;

public interface IPersonService
{
    ResultDto Create(PersonPostDto dto);
    ResultDto Update(PersonPutDto dto);
    ResultDto Delete(int id);
    List<Person> GetAll();
    PersonGetDto Get(int id);
}
