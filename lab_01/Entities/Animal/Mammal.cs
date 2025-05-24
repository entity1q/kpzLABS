using lab_1.Enums;
using lab_1.Interfaces;

namespace lab_1.Entities.Animal;

public class Mammal(string name, string species, FoodType diet, IEnclosure enclosure, bool isEndangered)
    : Abstract.Animal(name, species, diet, enclosure)
{
    public bool IsEndangered { get; } = isEndangered;

    public override void Feed(IFood food)
    {
        base.Feed(food);
        if (IsEndangered)
            Console.WriteLine($"Extra care for endangered {Name}");
    }
}