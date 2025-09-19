using System.Diagnostics.CodeAnalysis;
using Person.Domain.PersonModels;

namespace Person.DataAccess.PersonModels.Converters;

public static class PersonConverter
{
    public static PersonDb ToDb(this PersonRequest personRequest, int id)
    {
        return new PersonDb(id: id,
            name: personRequest.Name,
            age: personRequest.Age.Value,
            address: personRequest.Address,
            work: personRequest.Work);
    }

    [return: NotNullIfNotNull(nameof(personDb))]
    public static PersonResponse? ToDomain(this PersonDb? personDb)
    {
        if (personDb is null)
            return null;
        
        return new PersonResponse
        {
            Id = personDb.Id,
            Name = personDb.Name,
            Age = personDb.Age,
            Address = personDb.Address,
            Work = personDb.Work
        };
    }
}