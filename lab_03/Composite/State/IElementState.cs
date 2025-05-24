namespace Composite.State;

public interface IElementState
{
    string ModifyOuterHtml(LightElementNode node, string rawHtml);
}