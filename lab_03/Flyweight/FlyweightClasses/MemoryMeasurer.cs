using System.Diagnostics;

namespace Flyweight.FlyweightClasses;

public static class MemoryMeasurer
{
    public static long MeasureMemoryUsage(Action action)
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        long startMemory = GC.GetTotalMemory(true);
        action();
        long endMemory = GC.GetTotalMemory(true);
        return endMemory - startMemory;
    }
}