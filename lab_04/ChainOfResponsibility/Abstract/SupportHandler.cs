namespace ChainOfResponsibility.Abstract;

public abstract class SupportHandler : ISupportHandler
{
    public ISupportHandler? NextHandler { get; set; }
    public int Level { get; protected init; }

    public abstract void ShowMenu();

    public virtual bool HandleRequest()
    {
        while (true)
        {
            Console.Write("Ваш вибір: ");
            if (int.TryParse(Console.ReadLine(), out var choice))
            {
                if (choice == 0)
                {
                    return false;
                }

                var result = TryHandleChoice(choice);
                if (result)
                {
                    return true;
                }
            }

            Console.WriteLine("Невірний вибір, спробуйте ще раз");
        }
    }

    protected abstract bool TryHandleChoice(int choice);

    protected void DisplaySolution(string problemDescription, string solution)
    {
        Console.WriteLine($"Рівень підтримки {Level}: {problemDescription}");
        Console.WriteLine($"Рішення: {solution}");
    }
}