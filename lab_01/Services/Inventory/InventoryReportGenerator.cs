using System.Text;
using lab_1.Entities.Abstract;
using lab_1.Interfaces;

namespace lab_1.Services.Inventory;

public class InventoryReportGenerator(IInventoryService inventoryService)
{
    public string GenerateInventoryReport()
    {
        var items = inventoryService.GetItems();

        if (items.Count == 0)
            return "Inventory is empty";

        var reportBuilder = new StringBuilder("=== ZOO INVENTORY REPORT ===\n");
        reportBuilder.AppendLine($"Total items: {items.Count}");

        var groupedItems = items
            .GroupBy(GetBaseType)
            .OrderBy(group => group.Key.Name);

        foreach (var group in groupedItems)
        {
            reportBuilder.AppendLine($"\n--- {group.Key.Name.ToUpper()} ---");
            foreach (var item in group)
            {
                reportBuilder.AppendLine(item.GetInventoryInfo() ?? "No info available");
            }
        }

        return reportBuilder.ToString();
    }

    private static Type GetBaseType(object item)
    {
        var type = item.GetType();
        while (type != null && type != typeof(object))
        {
            if ((type.IsAbstract || type.IsInterface) && type != typeof(Entity))
                return type;
            type = type.BaseType;
        }
        return item.GetType();
    }
}