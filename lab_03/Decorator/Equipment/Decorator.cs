using Decorator.Interfaces;

namespace Decorator.Equipment;

public abstract class EquipmentDecorator : ICharacter
{
    protected ICharacter Character;
    protected string EquipmentName;
    protected string EquipmentId { get; } = Guid.NewGuid().ToString("N").Substring(0, 8); // Added unique ID

    protected EquipmentDecorator(ICharacter character)
    {
        Character = character;
        EquipmentName = GetType().Name.SplitPascalCase();
    }

    public virtual string GetCharClass() => Character.GetCharClass();
    public virtual List<string> GetEquipment() => [.. Character.GetEquipment(), $"{EquipmentName} #{EquipmentId}"];
    public virtual int GetPAttack() => Character.GetPAttack();
    public virtual int GetMAttack() => Character.GetMAttack();
    public virtual int GetPDef() => Character.GetPDef();
    public virtual int GetMDef() => Character.GetMDef();
}