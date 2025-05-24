using Adapter.Enums;
using Adapter.Interfaces;

namespace Adapter;

public class Logger : ILogger
{
    public void Log(string message) => PrintColoredMessage(LogLevels.Log, message, ConsoleColor.Green);
    public void Warn(string message) => PrintColoredMessage(LogLevels.Warn, message, ConsoleColor.Yellow);
    public void Error(string message) => PrintColoredMessage(LogLevels.Error, message, ConsoleColor.Red);

    private static void PrintColoredMessage(LogLevels level, string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"[{level.ToString().ToUpper()}]: {message}");
        Console.ResetColor();
    }
}