namespace Composite.Iterator;

public class DepthFirstIterator : ILightNodeIterator
{
    private readonly LightNode _root;
    private readonly Stack<LightNode> _stack;
    private readonly HashSet<LightNode> _visited;
    
    public DepthFirstIterator(LightNode root)
    {
        _root = root;
        _stack = new Stack<LightNode>();
        _visited = [];
        Reset();
    }
    
    public bool HasNext() => _stack.Count > 0;
    
    public LightNode Next()
    {
        if (!HasNext())
        {
            throw new InvalidOperationException("No more elements");
        }
        
        var current = _stack.Pop();
        _visited.Add(current);
        
        foreach (var child in current.GetChildren().AsEnumerable().Reverse())
        {
            if (!_visited.Contains(child))
            {
                _stack.Push(child);
            }
        }
        
        return current;
    }
    
    public void Reset()
    {
        _stack.Clear();
        _visited.Clear();
        _stack.Push(_root);
    }
}