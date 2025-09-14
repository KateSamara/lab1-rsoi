using System.Text.Json.Serialization;

namespace Person.Web.Dto;

public class PersonResponseDto
{
    [JsonRequired]
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
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

    public PersonResponseDto(int id, string name, int age, string address, string work)
    {
        Id = id;
        Name = name;
        Age = age;
        Address = address;
        Work = work;
    }
}