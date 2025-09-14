using Microsoft.AspNetCore.Mvc;
using Person.Domain.Interfaces;
using Person.Web.Dto;
using Person.Web.Dto.Converters;

namespace Person.Web.Api;

[ApiController]
[Route("/api/v1/persons")]
[ServiceFilter(typeof(ValidationFilterAttribute))]
public class PersonController : ControllerBase
{
    private readonly IPersonRepository _personRepository;

    public PersonController(IPersonRepository personRepository)
    {
        _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddPersonAsync([FromBody] PersonRequestDto personDto)
    {
        try
        {
            var person = personDto.ToDomain();
            
            var id = await _personRepository.AddPersonAsync(person);
            
            var locationUri = $"{Request.Scheme}://{Request.Host}/api/persons/{id}";
            Response.Headers.Location = locationUri;
            return StatusCode(StatusCodes.Status201Created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}