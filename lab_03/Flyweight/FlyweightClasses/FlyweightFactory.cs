namespace Flyweight.FlyweightClasses;

public class FlyweightFactory
{
    private readonly Dictionary<string, LightElementNode> _flyweights = new();

    public LightElementNode GetElement(string tagName, string displayType, string closingType, List<string> cssClasses)
    {
        string key = $"{tagName}_{displayType}_{closingType}_{string.Join(",", cssClasses)}";
        if (!_flyweights.ContainsKey(key))
        {
            _flyweights[key] = new LightElementNode(tagName, displayType, closingType, cssClasses);
        }
        var element = _flyweights[key];
        element.ResetChildren();
        return element;
    }

    public string GetStats()
    {
        return $"Created {_flyweights.Count} unique flyweight objects";
    }
}