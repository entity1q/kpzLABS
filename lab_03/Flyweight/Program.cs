using Flyweight.FlyweightClasses;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var bookPath = Path.Combine("data", "book.txt");
Directory.CreateDirectory("data");
Console.WriteLine($"Looking for book.txt at: {Path.GetFullPath(bookPath)}");
try
{
    if (!File.Exists(bookPath))
    {
        Console.WriteLine("Error: book.txt not found. Please create the file in the data directory.");
        return;
    }

    Console.WriteLine($"=== Standard Processing at {DateTime.Now:yyyy-MM-dd HH:mm:ss} ===");
    var standardMemory = MemoryMeasurer.MeasureMemoryUsage(() =>
    {
        var processor = new DefaultBookProcessor();
        var bookElement = processor.ProcessBook(bookPath);
        var counter = new NodeCounter();
        bookElement.Accept(counter);
        Console.WriteLine($"Standard approach created HTML with {NodeCounter.CountNodes(bookElement)} nodes");
        Console.WriteLine($"Node breakdown: {counter.GetTypeBreakdown()}");
        Console.WriteLine("Sample standard HTML output:");
        Console.WriteLine(bookElement.OuterHtml[..Math.Min(1000, bookElement.OuterHtml.Length)] + "...");
    });

    Console.WriteLine($"\n=== Flyweight Processing at {DateTime.Now:yyyy-MM-dd HH:mm:ss} ===");
    var flyweightMemory = MemoryMeasurer.MeasureMemoryUsage(() =>
    {
        try
        {
            var processor = new BookProcessorWithFlyweight();
            var bookElement = processor.ProcessBook(bookPath);
            var counter = new NodeCounter();
            bookElement.Accept(counter);
            Console.WriteLine($"Flyweight approach created HTML with {NodeCounter.CountNodes(bookElement)} nodes");
            Console.WriteLine($"Node breakdown: {counter.GetTypeBreakdown()}");
            processor.ShowStats();
            Console.WriteLine("Sample HTML output using Flyweight:");
            Console.WriteLine(bookElement.OuterHtml[..Math.Min(1000, bookElement.OuterHtml.Length)] + "...");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in Flyweight processing: {ex.Message}");
        }
    });

    Console.WriteLine("\n=== Memory Usage Comparison ===");
    Console.WriteLine($"Standard approach: {standardMemory:N0} bytes");
    Console.WriteLine($"Flyweight approach: {flyweightMemory:N0} bytes");
    Console.WriteLine($"Memory savings: {standardMemory - flyweightMemory:N0} bytes " +
                      $"({(standardMemory > 0 ? (1 - (double)flyweightMemory / standardMemory) * 100 : 0):F2}%)");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}