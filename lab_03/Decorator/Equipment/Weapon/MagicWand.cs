using Decorator.Interfaces;

namespace Decorator.Equipment.Weapon;

public class MagicWand : EquipmentDecorator
{
    public MagicWand(ICharacter character) : base(character) { }

    public override int GetMAttack() => Character.GetMAttack() + 7;
}