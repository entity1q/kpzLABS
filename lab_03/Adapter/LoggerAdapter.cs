using Adapter.Enums;
using Adapter.Interfaces;

namespace Adapter;

public class LoggerAdapter(FileWriter writer) : ILogger
{
    public void Log(string message) => WriteLog(LogLevels.Log, message);
    public void Warn(string message) => WriteLog(LogLevels.Warn, message);
    public void Error(string message) => WriteLog(LogLevels.Error, message);

    private void WriteLog(LogLevels level, string message)
    {
        writer.Write($"[{level.ToString().ToUpper()}] {DateTime.Now:yyyy-MM-dd HH:mm:ss}: ");
        writer.WriteLine(message);
    }
}