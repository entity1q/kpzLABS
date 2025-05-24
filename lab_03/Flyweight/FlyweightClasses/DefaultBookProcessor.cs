namespace Flyweight.FlyweightClasses;

public class DefaultBookProcessor
{
    public LightElementNode ProcessBook(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var book = new LightElementNode("div", "block", "closing", ["book"]);

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].TrimEnd();
            if (string.IsNullOrEmpty(line)) continue;

            LightElementNode element;
            if (i == 0)
            {
                element = new LightElementNode("h1", "block", "closing", []);
            }
            else if (line.Length < 20)
            {
                element = new LightElementNode("h2", "block", "closing", []);
            }
            else if (line.StartsWith(" "))
            {
                element = new LightElementNode("blockquote", "block", "closing", []);
                line = line.TrimStart();
            }
            else
            {
                element = new LightElementNode("p", "block", "closing", []);
            }
            element.AddChild(new LightTextNode(line));
            book.AddChild(element);
        }
        return book;
    }
}