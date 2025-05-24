using Flyweight.Visitor;

namespace Flyweight.FlyweightClasses;

public class LightElementNode : LightNode
{
    public string TagName { get; }
    public string DisplayType { get; }
    public string ClosingType { get; }
    public List<string> CssClasses { get; }
    public List<LightNode> Children { get; private set; }

    public override string OuterHtml
    {
        get
        {
            var result = $"<{TagName} id=\"{Id}\" class=\"{string.Join(" ", CssClasses)}\" display=\"{DisplayType}\">";
            if (ClosingType == "closing")
            {
                result += InnerHtml;
                result += $"</{TagName}>";
            }
            else
            {
                result = $"<{TagName} id=\"{Id}\" class=\"{string.Join(" ", CssClasses)}\" display=\"{DisplayType}\" />";
            }
            return result;
        }
    }

    public override string InnerHtml
    {
        get => Children.Aggregate("", (current, child) => current + child.OuterHtml);
    }

    public LightElementNode(string tagName, string displayType, string closingType, List<string> cssClasses)
    {
        TagName = tagName;
        DisplayType = displayType;
        ClosingType = closingType;
        CssClasses = cssClasses;
        Children = [];
    }

    public void AddChild(LightNode child)
    {
        Children.Add(child);
    }

    public void ResetChildren()
    {
        Children = [];
    }

    public override List<LightNode> GetChildren() => Children;

    public override void Accept(ILightNodeVisitor visitor)
    {
        visitor.Visit(this);
        foreach (var child in Children.ToList())
        {
            child.Accept(visitor);
        }
    }
}