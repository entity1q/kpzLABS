using ChainOfResponsibility.Abstract;

namespace ChainOfResponsibility.Handlers;

public class FirstLevelSupport : SupportHandler
{
    public FirstLevelSupport()
    {
        Level = 1;
    }

    public override void ShowMenu()
    {
        Console.WriteLine("Оберіть тип проблеми (рівень 1):");
        Console.WriteLine("1. Не можу увійти в систему");
        Console.WriteLine("2. Проблема з паролем");
        Console.WriteLine("3. Інша проблема з обліковим записом");
        Console.WriteLine("0. Моя проблема не стосується облікових записів");
    }

    protected override bool TryHandleChoice(int choice)
    {
        if (choice is < 1 or > 3) return false;
        DisplaySolution(
            $"Вирішення проблеми з обліковим записом (варіант {choice})",
            "Спробуйте скинути пароль або зверніться до адміністратора"
        );
        return true;
    }
}