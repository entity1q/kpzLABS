namespace ChainOfResponsibility.Abstract;

public interface ISupportHandler
{
    ISupportHandler? NextHandler { get; }
    int Level { get; }
    void ShowMenu();
    bool HandleRequest();
}