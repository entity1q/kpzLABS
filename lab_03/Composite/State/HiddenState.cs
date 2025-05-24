namespace Composite.State;

public class HiddenState : IElementState
{
    public string ModifyOuterHtml(LightElementNode node, string rawHtml) => string.Empty;
}