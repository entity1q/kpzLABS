using Flyweight.Visitor;

namespace Flyweight.FlyweightClasses;

public class LightTextNode : LightNode
{
    private readonly string _text;

    public override string OuterHtml => _text;
    public override string InnerHtml => _text;

    public LightTextNode(string text)
    {
        _text = text;
    }

    public override void Accept(ILightNodeVisitor visitor)
    {
        visitor.Visit(this);
    }
}