namespace Composite.Iterator;

public class BreadthFirstIterator : ILightNodeIterator
{
    private readonly LightNode _root;
    private readonly Queue<LightNode> _queue;
    private readonly HashSet<LightNode> _visited;
    
    public BreadthFirstIterator(LightNode root)
    {
        _root = root;
        _queue = new Queue<LightNode>();
        _visited = [];
        Reset();
    }
    
    public bool HasNext() => _queue.Count > 0;
    
    public LightNode Next()
    {
        if (!HasNext())
        {
            throw new InvalidOperationException("No more elements");
        }
        
        var current = _queue.Dequeue();
        _visited.Add(current);
        
        foreach (var child in current.GetChildren().Where(child => !_visited.Contains(child) && !_queue.Contains(child)))
        {
            _queue.Enqueue(child);
        }
        
        return current;
    }
    
    public void Reset()
    {
        _queue.Clear();
        _visited.Clear();
        _queue.Enqueue(_root);
    }
}