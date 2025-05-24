using Decorator.Interfaces;

namespace Decorator.Equipment.Jewelry;

public class Earring : EquipmentDecorator
{
    public Earring(ICharacter character) : base(character) { }

    public override int GetPDef() => Character.GetPDef() + 1;
    public override int GetMDef() => Character.GetMDef() + 1;
}