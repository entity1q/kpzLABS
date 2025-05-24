using Decorator.Interfaces;

namespace Decorator.Equipment.Jewelry;

public class Ring : EquipmentDecorator
{
    public Ring(ICharacter character) : base(character) { }

    public override int GetPAttack() => Character.GetPAttack() + 2;
    public override int GetMAttack() => Character.GetMAttack() + 2;
}