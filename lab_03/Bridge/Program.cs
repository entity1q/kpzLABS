using Bridge.Figures;
using Bridge.Interfaces;
using Bridge.Renderers;

Console.OutputEncoding = System.Text.Encoding.UTF8; 

IRenderer vectorRenderer = new VectorRenderer();
IRenderer rasterRenderer = new RasterRenderer();

Shape circleVector = new Circle(vectorRenderer);
Shape circleRaster = new Circle(rasterRenderer);
Shape squareVector = new Square(vectorRenderer);
Shape squareRaster = new Square(rasterRenderer);
Shape triangleVector = new Triangle(vectorRenderer);
Shape triangleRaster = new Triangle(rasterRenderer);

Console.WriteLine("=== Vector Rendering ===");
circleVector.Draw();
squareVector.Draw();
triangleVector.Draw();

Console.WriteLine("\n=== Raster Rendering ===");
circleRaster.Draw();
squareRaster.Draw();
triangleRaster.Draw();