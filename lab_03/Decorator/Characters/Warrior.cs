using Decorator.Interfaces;

namespace Decorator.Characters;

public class Warrior : Character
{
    public override int GetPAttack() => 10;
    public override int GetPDef() => 5;
}