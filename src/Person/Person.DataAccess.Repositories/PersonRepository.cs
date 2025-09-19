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
            int id;
            if (await _personContext.Persons.CountAsync() == 0)
                id = 1;
            else
                id = await _personContext.Persons.MaxAsync(p => p.Id) + 1;
            
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

    public async Task<PersonResponse?> GetPersonByIdAsync(int id)
    {
        try
        {
            var personDb = await _personContext.Persons
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            return personDb.ToDomain();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task DeletePersonByIdAsync(int id)
    {
        try
        {
            await _personContext.Persons
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<PersonResponse?> UpdatePersonByIdAsync(int id, PersonRequest personRequest)
    {
        try
        {
            var personDb = await _personContext.Persons
                .FirstOrDefaultAsync(p => p.Id == id);
            if (personDb is null)
                return null;
            
            personDb.Name = personRequest.Name;
            personDb.Age = personRequest.Age;
            personDb.Address = personRequest.Address;
            personDb.Work = personRequest.Work;

            await _personContext.SaveChangesAsync();

            return personDb.ToDomain();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}