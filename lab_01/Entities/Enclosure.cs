using lab_1.Entities.Abstract;
using lab_1.Enums;
using lab_1.Interfaces;

namespace lab_1.Entities;

public class Enclosure : Entity, IEnclosure, IMaintainable, IInventoryable
{
    public double Area { get; }
    public EnclosureType Type { get; }
    public int MaxCapacity { get; }
    private readonly List<IAnimal> _animals = [];
    public ICollection<IAnimal> Animals => _animals.AsReadOnly();
    private double CleanlinessScore { get; set; } = 100.0;

    public Enclosure(string name, double area, EnclosureType type, int maxCapacity)
        : base(name)
    {
        if (area <= 0)
            throw new ArgumentException("Area must be positive", nameof(area));
        if (maxCapacity <= 0)
            throw new ArgumentException("Maximum capacity must be positive", nameof(maxCapacity));

        Area = area;
        Type = type;
        MaxCapacity = maxCapacity;
    }

    public bool AddAnimal(IAnimal animal)
    {
        if (_animals.Count >= MaxCapacity)
            return false;

        _animals.Add(animal);
        animal.Enclosure = this;
        CleanlinessScore -= 10.0;
        return true;
    }

    public bool RemoveAnimal(IAnimal animal)
    {
        if (_animals.Remove(animal))
        {
            animal.Enclosure = null!;
            return true;
        }
        return false;
    }

    public void Maintain()
    {
        CleanlinessScore = 100.0;
    }

    public string? GetInventoryInfo() =>
        $"{Name}, Type: {Type}, Area: {Area}m², Animals: {_animals.Count}/{MaxCapacity}, Cleanliness: {CleanlinessScore}%";
}