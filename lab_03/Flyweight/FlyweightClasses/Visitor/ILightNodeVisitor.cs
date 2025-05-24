using Flyweight.FlyweightClasses;

namespace Flyweight.Visitor;

public interface ILightNodeVisitor
{
    void Visit(LightElementNode node);
    void Visit(LightTextNode node);
}