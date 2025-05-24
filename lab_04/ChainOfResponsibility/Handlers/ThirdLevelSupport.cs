using ChainOfResponsibility.Abstract;

namespace ChainOfResponsibility.Handlers;

public class ThirdLevelSupport : SupportHandler
{
    public ThirdLevelSupport()
    {
        Level = 3;
    }

    public override void ShowMenu()
    {
        Console.WriteLine("\nОберіть тип проблеми (рівень 3):");
        Console.WriteLine("1. Комп'ютер не вмикається");
        Console.WriteLine("2. Проблеми з монітором");
        Console.WriteLine("3. Інша проблема з апаратним забезпеченням");
        Console.WriteLine("0. Моя проблема не стосується апаратного забезпечення");
    }

    protected override bool TryHandleChoice(int choice)
    {
        if (choice is < 1 or > 3) return false;
        DisplaySolution(
            $"Вирішення проблеми з апаратним забезпеченням (варіант {choice})",
            "Перевірте підключення або зверніться до сервісного центру"
        );
        return true;
    }
}