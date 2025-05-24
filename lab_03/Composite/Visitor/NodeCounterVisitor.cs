namespace Composite.Visitor;

public class NodeCounterVisitor : ILightNodeVisitor
{
    public int ElementCount { get; set; }
    public int TextCount { get; set; }

    public void Visit(LightElementNode element)
    {
        ElementCount++;
    }

    public void Visit(LightTextNode text)
    {
        TextCount++;
    }

    public void Reset()
    {
        ElementCount = 0;
        TextCount = 0;
    }
}