namespace Memento;

public class TextDocument
{
    private string Content { get; set; } = "";
    private readonly History _history = new History();

    public IMemento Save()
    {
        Console.WriteLine($"Document saved: '{Content}' at {DateTime.Now}");
        return new ConcreteMemento(Content);
    }

    private void Restore(IMemento memento)
    {
        if (memento is not ConcreteMemento concreteMemento) return;
        Content = concreteMemento.GetContent();
        Console.WriteLine($"Document restored to state at {concreteMemento.GetSaveDate()}: '{Content}'");
    }

    public void WriteText(string text)
    {
        Content += text;
        Console.WriteLine($"Text entered: '{text}'.\nCurrent document: '{Content}'");
    }

    public void Undo()
    {
        var previousState = _history.Undo();
        if (previousState != null)
        {
            Restore(previousState);
        }
    }

    public void ShowCurrentDocument() => Console.WriteLine($"Current document content: '{Content}'");
    public History GetHistory() => _history;

    private class ConcreteMemento(string content) : IMemento
    {
        private DateTime SaveDate { get; set; } = DateTime.Now;
        public DateTime GetSaveDate() => SaveDate;
        public string GetContent() => content;
    }
}