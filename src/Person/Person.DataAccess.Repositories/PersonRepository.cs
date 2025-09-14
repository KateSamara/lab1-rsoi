using Microsoft.EntityFrameworkCore;
using Person.DataAccess.Context;
using Person.DataAccess.PersonModels.Converters;
using Person.Domain.Interfaces;
using Person.Domain.PersonModels;

namespace Person.DataAccess.Repositories;

public class PersonRepository(PersonContext personContext) : IPersonRepository
{
    private readonly PersonContext _personContext = personContext ?? throw new ArgumentNullException(nameof(personContext));

    public async Task<int> AddPersonAsync(PersonRequest personRequest)
    {
        try
        {
            var id = await _personContext.Persons.MaxAsync(p => p.Id) + 1;
            var personDb = personRequest.ToDb(id);
            
            _personContext.Persons.Add(personDb);
            await _personContext.SaveChangesAsync();
            
            return personDb.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<PersonResponse>> GetAllPersonAsync()
    {
        try
        {
            var personsDb = await _personContext.Persons
                .AsNoTracking()
                .ToListAsync();

            return personsDb.ConvertAll(p => p.ToDomain());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}