using lab_1.Enums;

namespace lab_1.Interfaces;

public interface IFood : IEntity
{
    FoodType Type { get; }
    double Quantity { get; }
    DateTime ExpirationDate { get; }
    void Consume(double amount);
    string? GetInventoryInfo();
}