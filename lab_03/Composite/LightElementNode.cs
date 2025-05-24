using Composite.Iterator;
using Composite.State;
using Composite.Visitor;

namespace Composite;

public class LightElementNode : LightNode
{
    public string TagName { get; }
    private string DisplayType { get; } 
    public string ClosingType { get; } 
    public List<string> CssClasses { get; } 
    public List<LightNode> Children { get; }

    public IElementState State { get; private set; } = new VisibleState();

    public override string OuterHtml
    {
        get
        {
            var rawHtml = GenerateRawHtml();
            return State.ModifyOuterHtml(this, rawHtml);
        }
    }

    public override string InnerHtml
    {
        get
        {
            return Children.Aggregate("", (current, child) => current + child.OuterHtml);
        }
    }

    private string GenerateRawHtml()
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

    public LightElementNode(string tagName, string displayType, string closingType, List<string> cssClasses)
    {
        TagName = tagName;
        DisplayType = displayType;
        ClosingType = closingType;
        CssClasses = cssClasses;
        Children = [];
        OnCreated();
    }

    public void AddChild(LightNode child)
    {
        Children.Add(child);
        Console.WriteLine($"Added child (ID: {child.Id}) to {TagName} (ID: {Id})");
    }

    public void RemoveChild(LightNode child)
    {
        if (!Children.Contains(child)) return;
        child.Remove();
        Children.Remove(child);
        Console.WriteLine($"Removed child (ID: {child.Id}) from {TagName} (ID: {Id})");
    }

    protected override void OnCreated()
    {
        Console.WriteLine($"ElementNode created: <{TagName}> (ID: {Id})");
    }

    protected override void OnBeforeRender()
    {
        Console.WriteLine($"ElementNode preparing to render: <{TagName}> (ID: {Id})");
    }

    protected override void OnAfterRender()
    {
        Console.WriteLine($"ElementNode render completed: <{TagName}> (ID: {Id})");
    }

    protected override void OnRemoved()
    {
        Console.WriteLine($"ElementNode removed: <{TagName}> (ID: {Id})");
        foreach (var child in Children.ToList())
        {
            RemoveChild(child);
        }
    }

    public override List<LightNode> GetChildren() => Children;

    public ILightNodeIterator CreateDepthFirstIterator() => new DepthFirstIterator(this);
    public ILightNodeIterator CreateBreadthFirstIterator() => new BreadthFirstIterator(this);

    public void SetState(IElementState state)
    {
        State = state;
        Console.WriteLine($"State of <{TagName}> (ID: {Id}) changed to {state.GetType().Name}.");
    }

    public override void Accept(ILightNodeVisitor visitor)
    {
        visitor.Visit(this);
        foreach (var child in Children)
        {
            child.Accept(visitor);
        }
    }
}