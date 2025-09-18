using Person.Domain.PersonModels;

namespace Person.UnitTests.Factories;

public static class PersonResponseFactory
{
    public static PersonResponse Create(int id = 0,
        string name = "Екатерина",
        int age = 20,
        string address = "Москва",
        string work = "Программист")
    {
        return new PersonResponse
        {
            Id = id,
            Name = name,
            Age = age,
            Address = address,
            Work = work
        };
    }
}