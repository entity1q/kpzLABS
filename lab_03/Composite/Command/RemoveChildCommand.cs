namespace Composite.Command;

public class RemoveChildCommand(LightElementNode parent, LightNode child) : ICommand
{
    public void Execute()
    {
        parent.RemoveChild(child);
    }

    public void Undo()
    {
        parent.AddChild(child);
    }
}