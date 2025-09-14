using Person.Domain.PersonModels;

namespace Person.Domain.Interfaces;

public interface IPersonRepository
{
    Task<int> AddPersonAsync(PersonRequest personResponse);
}