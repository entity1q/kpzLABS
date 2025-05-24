using Decorator.Interfaces;

namespace Decorator.Equipment.Weapon;

public class Sword : EquipmentDecorator
{
    public Sword(ICharacter character) : base(character) { }

    public override int GetPAttack() => Character.GetPAttack() + 5;
}