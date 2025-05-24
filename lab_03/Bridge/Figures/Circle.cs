using Bridge.Interfaces;

namespace Bridge.Figures;

public class Circle : Shape
{
    public Circle(IRenderer renderer) : base(renderer, "Circle #1") { }

    public override void Draw()
    {
        Renderer.RenderShape(Name);
    }
}