using Moq;
using Moq.EntityFrameworkCore;
using Person.DataAccess.Context;
using Person.DataAccess.PersonModels;
using Person.DataAccess.Repositories;
using Person.Domain.Interfaces;
using Person.Domain.PersonModels;
using Person.UnitTests.Factories;

namespace Person.UnitTests;

public class PersonRepositoryUnitTests
{
    private readonly IPersonRepository _personRepository;
    private readonly Mock<PersonContext> _mockPersonContext = new();

    public PersonRepositoryUnitTests()
    {
        _personRepository = new PersonRepository(_mockPersonContext.Object);
    }
    
    [Fact]
    public async Task GetAllPersonAsync_Basic_Ok()
    {
        // Arrange
        List<PersonDb> persons = [PersonDbFactory.Create(id: 1), PersonDbFactory.Create(id: 2)];

        _mockPersonContext.Setup(c => c.Persons).ReturnsDbSet(persons);
        
        List<PersonResponse> expectedPersons = [PersonResponseFactory.Create(id: 1), PersonResponseFactory.Create(id: 2)];
        
        // Act
        var actualPersons = await _personRepository.GetAllPersonAsync();
        
        // Assert
        Assert.Equal(expectedPersons, actualPersons);
    }

    [Fact]
    public async Task AddPersonAsync_Basic_Success()
    {
        // Arrange
        List<PersonDb> persons = [PersonDbFactory.Create(id: 1), PersonDbFactory.Create(id: 2)];

        _mockPersonContext.Setup(c => c.Persons).ReturnsDbSet(persons);
        
        var expectedId = persons.Max(p => p.Id) + 1;
        
        // Act
        var actualId = await _personRepository.AddPersonAsync(PersonRequestFactory.Create());
        
        // Assert
        Assert.Equal(expectedId, actualId);
    }

    [Fact]
    public async Task GetPersonByIdAsync_Basic_Success()
    {
        // Arrange
        List<PersonDb> persons = [PersonDbFactory.Create(id: 1), PersonDbFactory.Create(id: 2)];

        _mockPersonContext.Setup(c => c.Persons).ReturnsDbSet(persons);

        var id = 2;
        
        var expectedPersonResponse = PersonResponseFactory.Create(id: 2);
        
        // Act
        var actualPersonResponse = await _personRepository.GetPersonByIdAsync(id);
        
        // Assert
        Assert.Equal(expectedPersonResponse, actualPersonResponse);
    }

    [Fact]
    public async Task UpdatePersonByIdAsync_Basic_Success()
    {
        var personDb = PersonDbFactory.Create(id: 1);
        
        _mockPersonContext.Setup(c => c.Persons)
            .ReturnsDbSet([personDb]);
        
        var personRequest = PersonRequestFactory.Create(name: "Kate", age: 10, address: "Moscow", work: "programmer");
        
        var expectedPersonResponse = PersonResponseFactory.Create(id: 1, name: "Kate", age: 10, address: "Moscow", work: "programmer");
        
        // Act
        var actualPersonResponse = await _personRepository.UpdatePersonByIdAsync(1, personRequest);
        
        // Assert
        Assert.NotNull(actualPersonResponse);
        Assert.Equal(expectedPersonResponse, actualPersonResponse);
    }
}