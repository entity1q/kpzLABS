namespace Adapter;

public class FileWriter(string path)
{
    public void Write(string content)
    {
        File.AppendAllText(path, content);
    }

    public void WriteLine(string content)
    {
        File.AppendAllText(path, content + Environment.NewLine);
    }
}