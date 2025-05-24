using Decorator.Interfaces;

namespace Decorator.Equipment.Jewelry;

public class Necklace : EquipmentDecorator
{
    public Necklace(ICharacter character) : base(character) { }

    public override int GetPAttack() => Character.GetPAttack() + 1;
    public override int GetMAttack() => Character.GetMAttack() + 1;
    public override int GetPDef() => Character.GetPDef() + 1;
    public override int GetMDef() => Character.GetMDef() + 1;
}