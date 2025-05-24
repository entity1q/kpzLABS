namespace Proxy;

public class SmartTextReader : ISmartTextReader
{
    public char[][] ReadText(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File {filePath} not found.");
        }

        var rows = File.ReadAllLines(filePath);
        var result = new char[rows.Length][];

        for (var i = 0; i < rows.Length; i++)
        {
            result[i] = rows[i].ToCharArray();
        }

        return result;
    }
}