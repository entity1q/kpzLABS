using Bridge.Interfaces;

namespace Bridge.Figures;

public class Square : Shape
{
    public Square(IRenderer renderer) : base(renderer, "Square #1") { }

    public override void Draw()
    {
        Renderer.RenderShape(Name);
    }
}