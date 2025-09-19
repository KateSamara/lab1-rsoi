namespace Person.Domain.PersonModels;

public record PersonRequest
{
    public required string? Name { get; init; }
    public required int? Age { get; init; }
    public required string? Address { get; init; }
    public required string? Work { get; init; }
}