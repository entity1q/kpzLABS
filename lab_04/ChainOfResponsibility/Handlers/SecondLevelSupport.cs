using ChainOfResponsibility.Abstract;

namespace ChainOfResponsibility.Handlers;

public class SecondLevelSupport : SupportHandler
{
    public SecondLevelSupport()
    {
        Level = 2;
    }

    public override void ShowMenu()
    {
        Console.WriteLine("\nОберіть тип проблеми (рівень 2):");
        Console.WriteLine("1. Програма не запускається");
        Console.WriteLine("2. Програма зависає");
        Console.WriteLine("3. Інша проблема з програмним забезпеченням");
        Console.WriteLine("0. Моя проблема не стосується програмного забезпечення");
    }

    protected override bool TryHandleChoice(int choice)
    {
        if (choice is < 1 or > 3) return false;
        DisplaySolution(
            $"Вирішення проблеми з програмним забезпеченням (варіант {choice})",
            "Перевстановіть Windows!"
        );
        return true;
    }
}