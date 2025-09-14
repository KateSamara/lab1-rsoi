using Person.Domain.PersonModels;

namespace Person.Domain.Interfaces;

public interface IPersonRepository
{
    Task<int> AddPersonAsync(PersonRequest personResponse);
    
    Task<List<PersonResponse>> GetAllPersonAsync();
    
    Task<PersonResponse?> GetPersonByIdAsync(int id);
    
    Task DeletePersonByIdAsync(int id);
}