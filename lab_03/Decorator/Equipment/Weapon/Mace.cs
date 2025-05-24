using Decorator.Interfaces;

namespace Decorator.Equipment.Weapon;

public class Mace : EquipmentDecorator
{
    public Mace(ICharacter character) : base(character) { }

    public override int GetPAttack() => Character.GetPAttack() + 4;
    public override int GetMAttack() => Character.GetMAttack() + 2;
}