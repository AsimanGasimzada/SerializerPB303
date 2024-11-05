using Microsoft.AspNetCore.Mvc;
using Serializer.Models;
using Serializer.Services.Abstractions;
using System.IO.Pipes;

namespace Serializer.Controllers;

[Route("[controller]")]
[ApiController]
public class PeopleController : ControllerBase
{
    private readonly IPersonService _service;

    public PeopleController(IPersonService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _service.GetAll();

        return Ok(result);
    }


    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _service.Get(id);

        return Ok(result);
    }


    [HttpPut]
    public IActionResult Put(PersonPutDto person)
    {
        var result = _service.Update(person);

        return Ok(result);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var result = _service.Delete(id);

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Post(PersonPostDto person)
    {
        var result = _service.Create(person);

        return Ok(result);
    }
}
