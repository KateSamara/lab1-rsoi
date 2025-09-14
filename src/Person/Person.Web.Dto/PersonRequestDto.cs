using System.Text.Json.Serialization;

namespace Person.Web.Dto;

public class PersonRequestDto
{
    [JsonRequired]
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonRequired]
    [JsonPropertyName("age")]
    public int Age { get; set; }
    
    [JsonRequired]
    [JsonPropertyName("address")]
    public string Address { get; set; }
    
    [JsonRequired]
    [JsonPropertyName("work")]
    public string Work { get; set; }

    public PersonRequestDto(string name, int age, string address, string work)
    {
        Name = name;
        Age = age;
        Address = address;
        Work = work;
    }
}