using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hard_group.Inventory
{
    public class CraftingRecipe
    {
        public string Name { get; private set; }
        public List<Item> Ingredients { get; private set; }
        public Item Result { get; private set; }

        public CraftingRecipe(string name, List<Item> ingredients, Item result)
        {
            Name = name;
            Ingredients = ingredients;
            Result = result;
        }
    }
}
