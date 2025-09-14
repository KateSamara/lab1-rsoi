using Person.Domain.Models;

namespace Person.Domain.Interfaces;

public interface IPersonRepository
{
    Task<int> AddPersonAsync(PersonRequest personResponse);
}