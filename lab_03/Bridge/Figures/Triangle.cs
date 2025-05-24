using Bridge.Interfaces;

namespace Bridge.Figures;

public class Triangle : Shape
{
    public Triangle(IRenderer renderer) : base(renderer, "Triangle #1") { }

    public override void Draw()
    {
        Renderer.RenderShape(Name);
    }
}