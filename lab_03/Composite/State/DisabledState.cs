namespace Composite.State;

public class DisabledState : IElementState
{
    public string ModifyOuterHtml(LightElementNode node, string rawHtml) => rawHtml.Replace($"<{node.TagName}", $"<{node.TagName} disabled");  
}