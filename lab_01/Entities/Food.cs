using lab_1.Entities.Abstract;
using lab_1.Enums;
using lab_1.Interfaces;

namespace lab_1.Entities;

public class Food : Entity, IFood, IInventoryable
{
    public FoodType Type { get; }
    public double Quantity { get; private set; }
    public DateTime ExpirationDate { get; }

    public Food(string name, FoodType type, double quantity, DateTime expirationDate)
        : base(name)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be positive", nameof(quantity));
        if (expirationDate <= DateTime.Now)
            throw new ArgumentException("Expiration date must be in the future", nameof(expirationDate));

        Type = type;
        Quantity = quantity;
        ExpirationDate = expirationDate;
    }

    public void Consume(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive", nameof(amount));
        if (amount > Quantity)
            throw new ArgumentException("Insufficient food quantity", nameof(amount));

        Quantity -= amount;
    }

    public string? GetInventoryInfo() =>
        $"{Name}, Type: {Type}, Quantity: {Quantity}kg, {(ExpirationDate <= DateTime.Now ? "Expired" : $"Expires: {ExpirationDate.ToShortDateString()}")}";
}