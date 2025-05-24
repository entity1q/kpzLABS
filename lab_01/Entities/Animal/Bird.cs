using lab_1.Enums;
using lab_1.Interfaces;

namespace lab_1.Entities.Animal;

public class Bird(string name, string species, FoodType diet, IEnclosure enclosure, bool canFly)
    : Abstract.Animal(name, species, diet, enclosure)
{
    public bool CanFly { get; } = canFly;
}