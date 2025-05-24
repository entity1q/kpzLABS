namespace Flyweight.FlyweightClasses;

public class BookProcessorWithFlyweight
{
    private readonly FlyweightFactory _flyweightFactory = new();

    public LightElementNode ProcessBook(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var book = _flyweightFactory.GetElement("div", "block", "closing", ["book"]);

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].TrimEnd();
            if (string.IsNullOrEmpty(line)) continue;

            LightElementNode element;
            if (i == 0)
            {
                element = _flyweightFactory.GetElement("h1", "block", "closing", []);
            }
            else if (line.Length < 20)
            {
                element = _flyweightFactory.GetElement("h2", "block", "closing", []);
            }
            else if (line.StartsWith(" "))
            {
                element = _flyweightFactory.GetElement("blockquote", "block", "closing", []);
                line = line.TrimStart();
            }
            else
            {
                element = _flyweightFactory.GetElement("p", "block", "closing", []);
            }
            element.AddChild(new LightTextNode(line));
            book.AddChild(element);
        }
        return book;
    }

    public void ShowStats()
    {
        Console.WriteLine($"Flyweight factory stats: {_flyweightFactory.GetStats()}");
    }
}