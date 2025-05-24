using lab_1.Entities.Abstract;
using lab_1.Enums;
using lab_1.Interfaces;

namespace lab_1.Entities.Animal.Abstract;

public abstract class Animal : Entity, IAnimal, IFeedable, IInventoryable
{
    public string Species { get; }
    public FoodType Diet { get; }
    public IEnclosure Enclosure { get; set; }
    public bool IsHealthy { get; private set; }
    private bool IsFed { get; set; }

    protected Animal(string name, string species, FoodType diet, IEnclosure enclosure)
        : base(name)
    {
        if (string.IsNullOrWhiteSpace(species))
            throw new ArgumentException("Species cannot be empty", nameof(species));

        Species = species;
        Diet = diet;
        Enclosure = enclosure;
        IsHealthy = true;
        IsFed = false;
    }

    public virtual void Feed(IFood food)
    {
        if (food.Type != Diet)
            throw new ArgumentException($"Cannot feed {food.Type} to {Name} (requires {Diet})", nameof(food));
        if (food.ExpirationDate <= DateTime.Now)
            throw new ArgumentException("Cannot feed expired food", nameof(food));

        IsFed = true;
        IsHealthy = true;
    }

    public void PerformHealthCheck()
    {
        IsHealthy = IsFed;
    }

    public string? GetInventoryInfo() =>
        $"{Name}, Species: {Species}, Diet: {Diet}, Enclosure: {Enclosure?.Name ?? "None"}, Health: {(IsHealthy ? "Good" : "Needs attention")}";
}