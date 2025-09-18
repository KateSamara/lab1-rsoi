using Person.DataAccess.PersonModels;

namespace Person.UnitTests.Factories;

public static class PersonDbFactory
{
    public static PersonDb Create(int id = 0,
        string name = "Екатерина",
        int age = 20,
        string address = "Москва",
        string work = "Программист")
    {
        return new PersonDb(id: id, name: name, age: age, address: address, work: work);
    }
}