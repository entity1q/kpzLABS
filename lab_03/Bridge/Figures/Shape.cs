using Bridge.Interfaces;

namespace Bridge.Figures;

public abstract class Shape
{
    protected IRenderer Renderer;
    protected string Name { get; }

    protected Shape(IRenderer renderer, string name)
    {
        Renderer = renderer;
        Name = name;
    }

    public abstract void Draw();
}