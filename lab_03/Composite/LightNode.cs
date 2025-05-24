using Composite.Visitor;

namespace Composite;

public abstract class LightNode
{
    public string Id { get; } = Guid.NewGuid().ToString("N").Substring(0, 8);

    public abstract string OuterHtml { get; }
    public abstract string InnerHtml { get; }
    public abstract void Accept(ILightNodeVisitor visitor);

    public string Render()
    {
        OnBeforeRender();
        var result = OuterHtml;
        OnAfterRender();
        return result;
    }

    protected virtual void OnCreated() { }
    protected virtual void OnBeforeRender() { }
    protected virtual void OnAfterRender() { }
    protected virtual void OnRemoved() { }

    public void Remove()
    {
        OnRemoved();
    }

    public virtual List<LightNode> GetChildren() => [];
}