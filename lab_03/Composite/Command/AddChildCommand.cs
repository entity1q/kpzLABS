namespace Composite.Command;

public class AddChildCommand(LightElementNode parent, LightNode child) : ICommand
{
    public void Execute()
    {
        parent.AddChild(child);
    }

    public void Undo()
    {
        parent.RemoveChild(child);
    }
}