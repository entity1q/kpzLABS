using System.Text;
using Proxy;

Console.OutputEncoding = Encoding.UTF8;

var projectRoot = Path.Combine("files"); 
Directory.CreateDirectory(projectRoot); 
var normalFilePath = Path.Combine(projectRoot, "normal.txt");
var restrictedFilePath = Path.Combine(projectRoot, "secret.txt");

File.WriteAllText(normalFilePath, "Hello\nWorld\nTest");
File.WriteAllText(restrictedFilePath, "Top\nSecret\nData");

Console.WriteLine($"=== Basic SmartTextReader at {DateTime.Now:yyyy-MM-dd HH:mm:ss} ===");
ISmartTextReader basicReader = new SmartTextReader();
var basicResult = basicReader.ReadText(normalFilePath);
PrintArray(basicResult);

Console.WriteLine($"\n=== SmartTextChecker Test at {DateTime.Now:yyyy-MM-dd HH:mm:ss} ===");
ISmartTextReader checker = new SmartTextChecker();
var checkedResult = checker.ReadText(normalFilePath);
PrintArray(checkedResult);

Console.WriteLine($"\n=== SmartTextReaderLocker Test (Allowed File) at {DateTime.Now:yyyy-MM-dd HH:mm:ss} ===");
ISmartTextReader locker = new SmartTextReaderLocker("secret");
var allowedResult = locker.ReadText(normalFilePath);
PrintArray(allowedResult);

Console.WriteLine($"\n=== SmartTextReaderLocker Test (Restricted File) at {DateTime.Now:yyyy-MM-dd HH:mm:ss} ===");
var restrictedResult = locker.ReadText(restrictedFilePath);
PrintArray(restrictedResult);

return;

static void PrintArray(char[][] array)
{
    if (array.Length == 0)
    {
        Console.WriteLine("Array is empty.");
        return;
    }

    Console.WriteLine("Content:");
    for (var i = 0; i < array.Length; i++)
    {
        Console.WriteLine($"Row {i + 1}: {new string(array[i])}");
    }
    Console.WriteLine($"Total Characters: {array.Sum(line => line.Length)}"); // Added
}