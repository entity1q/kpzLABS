using lab_1.Interfaces;

namespace lab_1.Services.Inventory;

public class InventoryService : IInventoryService
{
    private readonly List<IInventoryable> _items = [];

    public void AddItem(IInventoryable item)
    {
        ArgumentNullException.ThrowIfNull(item);
        _items.Add(item);
    }

    public void RemoveItem(IInventoryable item)
    {
        ArgumentNullException.ThrowIfNull(item);
        _items.Remove(item);
    }

    public IReadOnlyList<IInventoryable> GetItems() => _items.AsReadOnly();
}