using Composite;
using Composite.Command;
using Composite.State;
using Composite.Visitor;

Console.OutputEncoding = System.Text.Encoding.UTF8; 

var header = new LightElementNode("h1", "block", "closing", ["header"]);
header.AddChild(new LightTextNode("Welcome to LightHTML!"));

var paragraph = new LightElementNode("p", "block", "closing", ["text"]);
paragraph.AddChild(new LightTextNode("Lorem ipsum dolor sit amet."));

var list = new LightElementNode("ul", "block", "closing", ["list"]);

var item1 = new LightElementNode("li", "block", "closing", []);
item1.AddChild(new LightTextNode("First item"));

var item2 = new LightElementNode("li", "block", "closing", []);
item2.AddChild(new LightTextNode("Second item"));

var item3 = new LightElementNode("li", "block", "closing", []);
item3.AddChild(new LightTextNode("Third item"));

list.AddChild(item1);
list.AddChild(item2);
list.AddChild(item3);

var image = new LightElementNode("img", "inline", "self-closing", ["image"]);

var page = new LightElementNode("div", "block", "closing", ["container"]);
page.AddChild(header);
page.AddChild(paragraph);
page.AddChild(list);
page.AddChild(image);

Console.WriteLine("\n=== Node Count ===");
var counter = new NodeCounterVisitor();
page.Accept(counter);
Console.WriteLine($"Elements: {counter.ElementCount}, Text Nodes: {counter.TextCount}");

Console.WriteLine("\n=== Page Rendering ===");
var renderedPage = page.Render();
Console.WriteLine("\n=== OuterHTML ===");
Console.WriteLine(renderedPage);
Console.WriteLine("\n=== InnerHTML ===");
Console.WriteLine(page.InnerHtml);

Console.WriteLine("\n=== Page Structure ===");
PrintNode(page, 0);

return;

static void PrintNode(LightNode node, int indent)
{
    var indentStr = new string(' ', indent * 2);

    if (node is LightElementNode elementNode)
    {
        var cssClasses = elementNode.CssClasses.Any() ? $" class=\"{string.Join(" ", elementNode.CssClasses)}\"" : "";
        Console.WriteLine($"{indentStr}<{elementNode.TagName} id=\"{node.Id}\"{cssClasses}>");
        foreach (var child in elementNode.Children)
        {
            PrintNode(child, indent + 1);
        }
        if (elementNode.ClosingType == "closing")
        {
            Console.WriteLine($"{indentStr}</{elementNode.TagName}>");
        }
    }
    else if (node is LightTextNode textNode)
    {
        Console.WriteLine($"{indentStr}\"{textNode.OuterHtml}\" (ID: {node.Id})");
    }
}