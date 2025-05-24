using Flyweight.Visitor;

namespace Flyweight.FlyweightClasses;

public abstract class LightNode
{
    public string Id { get; } = Guid.NewGuid().ToString("N").Substring(0, 8);

    public abstract string OuterHtml { get; }
    public abstract string InnerHtml { get; }
    public abstract void Accept(ILightNodeVisitor visitor);

    public string Render()
    {
        return OuterHtml;
    }

    public virtual List<LightNode> GetChildren() => [];
}