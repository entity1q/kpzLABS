using Flyweight.Visitor;

namespace Flyweight.FlyweightClasses;

public class NodeCounter : ILightNodeVisitor
{
    public int ElementCount { get; private set; }
    public int TextCount { get; private set; }
    public Dictionary<string, int> ElementTypeCounts { get; } = new();

    public void Visit(LightElementNode node)
    {
        ElementCount++;
        string tag = node.TagName.ToLower();
        ElementTypeCounts[tag] = ElementTypeCounts.GetValueOrDefault(tag, 0) + 1;
    }

    public void Visit(LightTextNode node)
    {
        TextCount++;
    }

    public static int CountNodes(LightNode node)
    {
        var counter = new NodeCounter();
        node.Accept(counter);
        return counter.ElementCount + counter.TextCount;
    }

    public string GetTypeBreakdown()
    {
        return string.Join(", ", ElementTypeCounts.Select(kv => $"{kv.Key}: {kv.Value}"));
    }
}