namespace Proxy;

public class SmartTextChecker : ISmartTextReader
{
    private readonly SmartTextReader _reader = new();
    private static int _operationId = 0; 

    public char[][] ReadText(string filePath)
    {
        var operationId = ++_operationId; 
        var fileName = Path.GetFileName(filePath);
        Console.WriteLine($"[Operation {operationId}] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - Trying to open file: {fileName}");

        char[][] textArray;

        try
        {
            textArray = _reader.ReadText(filePath);
            Console.WriteLine($"[Operation {operationId}] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - File has been read successfully.");

            var rowCount = textArray.Length;
            var charCount = textArray.Sum(line => line.Length);

            Console.WriteLine($"[Operation {operationId}] Rows: {rowCount}");
            Console.WriteLine($"[Operation {operationId}] Characters: {charCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Operation {operationId}] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - File reading error: {ex.Message}");
            throw;
        }
        finally
        {
            Console.WriteLine($"[Operation {operationId}] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - Closing file: {fileName}");
        }

        return textArray;
    }
}