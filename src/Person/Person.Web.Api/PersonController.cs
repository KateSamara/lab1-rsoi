using Microsoft.AspNetCore.Mvc;
using Person.Domain.Interfaces;
using Person.Domain.PersonModels;
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
        var person = personDto.ToDomain();
            
        var id = await _personRepository.AddPersonAsync(person);
            
        var locationUri = $"{Request.Scheme}://{Request.Host}/api/persons/{id}";
        Response.Headers.Location = locationUri;
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<PersonResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllPersonAsync()
    {
        var persons = await _personRepository.GetAllPersonAsync();
        
        return Ok(persons.ConvertAll(person => person.ToDto()));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PersonResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPersonByIdAsync([FromRoute] int id)
    {
        var person = await _personRepository.GetPersonByIdAsync(id);
        if (person is null)
        {
            return NotFound(new { message = "Person not found." });
        }
        
        return Ok(person.ToDto());
    }
}