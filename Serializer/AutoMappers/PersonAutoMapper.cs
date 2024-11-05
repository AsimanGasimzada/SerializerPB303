using AutoMapper;
using Serializer.Dtos;
using Serializer.Models;

namespace Serializer.AutoMappers;

public class PersonAutoMapper : Profile
{
    public PersonAutoMapper()
    {
        CreateMap<Person, PersonPostDto>().ReverseMap();
        CreateMap<Person, PersonPutDto>().ReverseMap();
        CreateMap<Person, PersonGetDto>().ReverseMap();
    }
}
