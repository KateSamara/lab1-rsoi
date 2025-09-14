namespace Person.Domain.PersonModels;

public record PersonResponse
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required int Age { get; init; }
    public required string Address { get; init; }
    public required string Work { get; init; }
}