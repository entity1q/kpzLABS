using System.Text;
using ChainOfResponsibility.Abstract;
using ChainOfResponsibility.Handlers;

Console.OutputEncoding = Encoding.UTF8;

var level1 = new FirstLevelSupport();
var level2 = new SecondLevelSupport();
var level3 = new ThirdLevelSupport();
var level4 = new FourthLevelSupport();

level1.NextHandler = level2;
level2.NextHandler = level3;
level3.NextHandler = level4;

Console.WriteLine("Вітаємо в системі підтримки користувачів!");

while (true)
{
    ISupportHandler? currentHandler = level1;
    var problemResolved = false;

    while (!problemResolved && currentHandler != null)
    {
        currentHandler.ShowMenu();
        problemResolved = currentHandler.HandleRequest();

        if (!problemResolved)
        {
            currentHandler = currentHandler.NextHandler;
        }
    }

    if (!problemResolved)
    {
        Console.WriteLine("На жаль, ми не змогли визначити вашу проблему.");
        Console.WriteLine("Будь ласка, зв'яжіться з нами по телефону.");
    }

    Console.WriteLine("\nБажаєте звернутися з іншою проблемою? (y/n)");
    var answer = Console.ReadLine()?.Trim().ToLower();

    if (answer != "y")
    {
        Console.WriteLine("Дякуємо за звернення. Гарного дня!");
        break;
    }
}