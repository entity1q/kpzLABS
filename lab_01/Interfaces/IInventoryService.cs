namespace lab_1.Interfaces;

public interface IInventoryService
{
    void AddItem(IInventoryable item);
    void RemoveItem(IInventoryable item);
    IReadOnlyList<IInventoryable> GetItems();
}