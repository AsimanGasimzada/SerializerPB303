using AutoMapper;
using Serializer.Dtos;
using Serializer.Exceptions;
using Serializer.Models;
using Serializer.Services.Abstractions;

namespace Serializer.Services.Implementations;

public class PersonService : IPersonService
{
    private readonly ISerializeService<Person> _serializer;
    private readonly IWebHostEnvironment _hostEnvironment;
    private string _folderPath;
    private readonly IMapper _mapper;

    public PersonService(ISerializeService<Person> serializer, IWebHostEnvironment hostEnvironment, IMapper mapper)
    {
        _serializer = serializer;
        _hostEnvironment = hostEnvironment;
        _folderPath = Path.Combine(_hostEnvironment.WebRootPath, "document", "people.txt");
        _mapper = mapper;
    }

    public ResultDto Create(PersonPostDto dto)
    {
        var people = GetAll();


        var person = _mapper.Map<Person>(dto);

        people.Add(person);

        _serializer.WriteFile(people, _folderPath);

        return new("successfully");
    }

    public ResultDto Delete(int id)
    {
        var people = GetAll();

        var person = people.FirstOrDefault(x => x.Id == id);

        if (person is null)
            throw new NotFoundException("Not found");

        people.Remove(person);

        _serializer.WriteFile(people, _folderPath);

        return new("successfully");

    }

    public PersonGetDto Get(int id)
    {
        var people = GetAll();

        var person = people.FirstOrDefault(x => x.Id == id);

        if (person is null)
            throw new NotFoundException("Not found");

        var dto = _mapper.Map<PersonGetDto>(person);

        return dto;
    }

    public List<Person> GetAll()
    {
        var result = _serializer.ReadFile(_folderPath);

        return result;
    }

    public ResultDto Update(PersonPutDto dto)
    {
        var people = GetAll();

        var exitsPerson = people.FirstOrDefault(x => x.Id == dto.Id);

        if (exitsPerson is null)
            throw new NotFoundException("Not found");

        exitsPerson = _mapper.Map(dto, exitsPerson);

        _serializer.WriteFile(people, _folderPath);

        return new("successfully");

    }
}
