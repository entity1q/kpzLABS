using Bridge.Interfaces;

namespace Bridge.Renderers;

public class RasterRenderer : IRenderer
{
    public void RenderShape(string shapeName)
    {
        Console.WriteLine($"[RASTER] Drawing {shapeName} as raster pixels at {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
    }
}