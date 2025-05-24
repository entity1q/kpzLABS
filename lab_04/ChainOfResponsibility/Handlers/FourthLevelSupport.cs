using ChainOfResponsibility.Abstract;

namespace ChainOfResponsibility.Handlers;

public class FourthLevelSupport : SupportHandler
{
    public FourthLevelSupport()
    {
        Level = 4;
    }

    public override void ShowMenu()
    {
        Console.WriteLine("\nОберіть тип проблеми (рівень 4):");
        Console.WriteLine("1. Складні мережеві проблеми");
        Console.WriteLine("2. Проблеми з сервером");
        Console.WriteLine("3. Інші складні технічні проблеми");
    }

    protected override bool TryHandleChoice(int choice)
    {
        if (choice is < 1 or > 3) return false;
        DisplaySolution(
            $"Вирішення складних технічних проблем (варіант {choice})",
            "Наш інженер зв'яжеться з вами протягом 24 годин"
        );
        return true;
    }
}