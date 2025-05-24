using Decorator.Interfaces;

namespace Decorator.Equipment.Armor;

public class HeavyArmor : EquipmentDecorator
{
    public HeavyArmor(ICharacter character) : base(character) { }

    public override int GetPDef() => Character.GetPDef() + 6;
}