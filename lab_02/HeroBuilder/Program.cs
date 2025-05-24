using System;
using System.Collections.Generic;
using System.Reflection.Emit;

class Program
{
    static void Main()
    {
        ICharacterBuilder heroBuilder = new HeroBuilder();
        CharacterDirector heroDirector = new CharacterDirector(heroBuilder);
        Character hero = heroDirector.ConstructCharacter();
        Console.WriteLine("Hero Info:");
        hero.DisplayCharacterInfo();

        ICharacterBuilder enemyBuilder = new EnemyBuilder();
        CharacterDirector enemyDirector = new CharacterDirector(enemyBuilder);
        Character enemy = enemyDirector.ConstructCharacter();
        Console.WriteLine("\nEnemy Info:");
        enemy.DisplayCharacterInfo();
        Console.ReadLine();

    }
}
