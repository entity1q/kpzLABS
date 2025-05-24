namespace Memento;

public class History
{
    private readonly List<IMemento> _history = [];

    public void Backup(IMemento memento) => _history.Add(memento);

    public IMemento Undo()
    {
        if (_history.Count == 0)
        {
            Console.WriteLine("History is empty.");
            return null!;
        }

        var lastState = _history[^1];
        _history.RemoveAt(_history.Count - 1);
        return lastState;
    }
}