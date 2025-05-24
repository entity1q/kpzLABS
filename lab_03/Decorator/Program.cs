using System.Text;
using Decorator.Characters;
using Decorator.Equipment.Armor;
using Decorator.Equipment.Jewelry;
using Decorator.Equipment.Weapon;
using Decorator.Interfaces;

Console.OutputEncoding = Encoding.UTF8;

var characterDecorators = new Dictionary<Type, List<Func<ICharacter, ICharacter>>>
{
    {
        typeof(Warrior), [
            character => new Sword(character),
            character => new HeavyArmor(character),
            character => new Ring(character),
            character => new Ring(character),
            character => new Earring(character),
            character => new Earring(character),
            character => new Necklace(character)
        ]
    },
    {
        typeof(Mage), [
            character => new MagicWand(character),
            character => new Robe(character),
            character => new Ring(character),
            character => new Ring(character),
            character => new Earring(character),
            character => new Earring(character),
            character => new Necklace(character)
        ]
    },
    {
        typeof(Paladin), [
            character => new Mace(character),
            character => new HeavyArmor(character),
            character => new Ring(character),
            character => new Ring(character),
            character => new Earring(character),
            character => new Earring(character),
            character => new Necklace(character)
        ]
    }
};

ICharacter warrior = new Warrior();
ICharacter mage = new Mage();
ICharacter paladin = new Paladin();

PrintCharInfo(EquipCharacter(warrior));
PrintCharInfo(EquipCharacter(mage));
PrintCharInfo(EquipCharacter(paladin));

ICharacter EquipCharacter(ICharacter character)
{
    var decorators = characterDecorators[character.GetType()];
    return decorators.Aggregate(character, (current, decorator) => decorator(current));
}

static void PrintCharInfo(ICharacter character)
{
    Console.WriteLine($"Class: {character.GetCharClass()}");
    Console.WriteLine(
        $"Equipment: {(character.GetEquipment().Count > 0 ? string.Join(", ", character.GetEquipment()) : "empty")}");
    Console.WriteLine($"P.Attack: {character.GetPAttack()}");
    Console.WriteLine($"M.Attack: {character.GetMAttack()}");
    Console.WriteLine($"P.Def: {character.GetPDef()}");
    Console.WriteLine($"M.Def: {character.GetMDef()}");
    Console.WriteLine();
}