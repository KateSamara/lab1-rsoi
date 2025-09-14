using Person.Domain.PersonModels;

namespace Person.DataAccess.PersonModels.Converters;

public static class PersonConverter
{
    public static PersonDb ToDb(this PersonRequest personRequest, int id)
    {
        return new PersonDb(id: id,
            name: personRequest.Name,
            age: personRequest.Age,
            address: personRequest.Address,
            work: personRequest.Work);
    }

    public static PersonResponse ToDomain(this PersonDb personDb)
    {
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