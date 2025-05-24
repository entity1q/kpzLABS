using System;
public class CharacterDirector
{
    private ICharacterBuilder _builder;

    public CharacterDirector(ICharacterBuilder builder)
    {
        _builder = builder;
    }

    public Character ConstructCharacter()
    {
        return _builder.SetHeight(188)
                       .SetBuild("Athletic")
                       .SetHairColor("Blond")
                       .SetEyeColor("Blue")
                       .SetClothes("Captain America uniform")
                       .SetInventory(new List<string> { "Shield", "Super Strength", "Leadership" })
                       .Build();
    }

}