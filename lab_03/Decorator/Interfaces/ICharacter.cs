namespace Decorator.Interfaces;

public interface ICharacter
{
    string GetCharClass();
    List<string> GetEquipment();
    int GetPAttack();
    int GetMAttack();
    int GetPDef();
    int GetMDef();
}