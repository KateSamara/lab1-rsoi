using Person.Domain.PersonModels;

namespace Person.UnitTests.Factories;

public static class PersonRequestFactory
{
    public static PersonRequest Create(string name = "Екатерина",
        int age = 20,
        string address = "Москва",
        string work = "Программист")
    {
        return new PersonRequest
        {
            Name = name,
            Age = age,
            Address = address,
            Work = work
        };
    }
}