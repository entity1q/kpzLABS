using Decorator.Interfaces;

namespace Decorator.Equipment.Armor;

public class Robe : EquipmentDecorator
{
    public Robe(ICharacter character) : base(character) { }

    public override int GetMDef() => Character.GetMDef() + 4;
}