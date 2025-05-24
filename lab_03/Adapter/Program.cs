using Adapter;
using Adapter.Interfaces;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var logFilePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "logs", "log.txt"));

var consoleLogger = new Logger();
var fileWriter = new FileWriter(logFilePath);
ILogger fileLogger = new LoggerAdapter(fileWriter);

consoleLogger.Log("Program start.");
consoleLogger.Warn("Some warning.");
consoleLogger.Error("Some error.");

fileLogger.Log("Program start.");
fileLogger.Warn("Some warning.");
fileLogger.Error("Some error.");