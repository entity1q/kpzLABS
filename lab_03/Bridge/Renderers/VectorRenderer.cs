using Bridge.Interfaces;

namespace Bridge.Renderers;

public class VectorRenderer : IRenderer
{
    public void RenderShape(string shapeName)
    {
        Console.WriteLine($"[VECTOR] Drawing {shapeName} as vector graphics at {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
    }
}