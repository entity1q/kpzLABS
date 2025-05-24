namespace Composite.Iterator;

public interface ILightNodeIterator
{
    bool HasNext();
    LightNode Next();
    void Reset();
}