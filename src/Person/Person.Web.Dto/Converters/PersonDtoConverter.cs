using Person.Domain.PersonModels;

namespace Person.Web.Dto.Converters;

public static class PersonDtoConverter
{
    public static PersonRequest ToDomain(this PersonRequestDto personRequest)
    {
        return new PersonRequest
        {
            Age = personRequest.Age,
            Address = personRequest.Address,
            Work = personRequest.Work,
            Name = personRequest.Name
        };
    }
}