using Decorator.Interfaces;

namespace Decorator.Characters;

public class Mage : Character
{
    public override int GetMAttack() => 15;
    public override int GetMDef() => 3;
}