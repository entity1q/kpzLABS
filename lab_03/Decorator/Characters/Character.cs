using Decorator.Interfaces;

namespace Decorator.Characters;

public abstract class Character : ICharacter
{
    public virtual string GetCharClass() => GetType().Name.SplitPascalCase();
    public virtual List<string> GetEquipment() => [];
    public virtual int GetPAttack() => 0;
    public virtual int GetMAttack() => 0;
    public virtual int GetPDef() => 0;
    public virtual int GetMDef() => 0;
}