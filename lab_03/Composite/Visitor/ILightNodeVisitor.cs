namespace Composite.Visitor;

public interface ILightNodeVisitor
{
    void Visit(LightElementNode element);
    void Visit(LightTextNode text);
}