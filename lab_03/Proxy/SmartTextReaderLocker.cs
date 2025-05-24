using System.Text.RegularExpressions;

namespace Proxy;

public class SmartTextReaderLocker(string pattern) : ISmartTextReader
{
    private readonly SmartTextReader _reader = new();

    public char[][] ReadText(string filePath)
    {
        var fileName = Path.GetFileName(filePath);
        if (!Regex.IsMatch(fileName, pattern)) return _reader.ReadText(filePath);
        Console.WriteLine($"Access denied to file: {fileName}!");
        return [];
    }
}