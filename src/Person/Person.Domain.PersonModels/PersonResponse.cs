namespace Person.Domain.PersonModels;

public record PersonResponse
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required int Age { get; init; }
    public required string Address { get; init; }
    public required string Work { get; init; }

    public virtual bool Equals(PersonResponse? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id && Name == other.Name && Age == other.Age && Address == other.Address && Work == other.Work;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Age, Address, Work);
    }
}