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
}