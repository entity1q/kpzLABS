using lab_1.Enums;
using lab_1.Interfaces;

namespace lab_1.Entities.Animal;

public class Reptile(string name, string species, FoodType diet, IEnclosure enclosure, bool isVenomous)
    : Abstract.Animal(name, species, diet, enclosure)
{
    public bool IsVenomous { get; } = isVenomous;

    public override void Feed(IFood food)
    {
        base.Feed(food);
        if (IsVenomous)
            Console.WriteLine($"Handle {Name} with caution due to venom");
    }
}