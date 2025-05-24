using Decorator.Interfaces;

namespace Decorator.Characters;

public class Paladin : Character
{
    public override int GetPAttack() => 8;
    public override int GetPDef() => 7;
    public override int GetMDef() => 2;
}