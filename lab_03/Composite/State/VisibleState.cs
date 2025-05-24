namespace Composite.State;

public class VisibleState : IElementState
{
    public string ModifyOuterHtml(LightElementNode node, string rawHtml) => rawHtml;
}