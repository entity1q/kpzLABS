using lab_1.Enums;

namespace lab_1.Interfaces;

public interface IEnclosure : IEntity
{
    double Area { get; }
    EnclosureType Type { get; }
    int MaxCapacity { get; }
    bool AddAnimal(IAnimal animal);
    bool RemoveAnimal(IAnimal animal);
    string? GetInventoryInfo();
}