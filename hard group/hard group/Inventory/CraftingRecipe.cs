using System.Collections.Generic;

public class CraftingRecipe
{
    public string Name { get; set; }
    public List<CraftingRequirement> Requirements { get; set; }
    public Item Result { get; set; }

    public CraftingRecipe(string name, List<CraftingRequirement> requirements, Item result)
    {
        Name = name;
        Requirements = requirements;
        Result = result;
    }
}