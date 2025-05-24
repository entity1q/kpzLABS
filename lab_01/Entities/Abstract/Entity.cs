using lab_1.Interfaces;

namespace lab_1.Entities.Abstract;

public abstract class Entity : IEntity
{
    public Guid Id { get; }
    public string Name { get; }

    protected Entity(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
            throw new ArgumentException("Name must be at least 2 characters long", nameof(name));

        Name = name;
        Id = Guid.NewGuid();
    }

    public override string ToString() => Name;
}