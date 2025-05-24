using lab_1.Enums;

namespace lab_1.Interfaces;

public interface IAnimal : IEntity
{
    string Species { get; }
    FoodType Diet { get; }
    IEnclosure Enclosure { get; set; }
    string? GetInventoryInfo();
}