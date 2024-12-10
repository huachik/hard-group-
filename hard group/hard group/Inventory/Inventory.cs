using System;
using System.Collections.Generic;

public class Inventory
{
    private List<Item> items;
    private int maxWeight;
    private int currentWeight;
    private Dictionary<string, CraftingRecipe> craftingRecipes;
    private int strenght;

    public Inventory(int strength)
    {
        maxWeight = strength * 10; // Максимальный вес равен силе игрока, умноженной на 10
        items = new List<Item>();
        currentWeight = 0;
        craftingRecipes = new Dictionary<string, CraftingRecipe>();
        this.strenght = strenght;
    }

    public bool AddItem(Item item)
    {
        if (currentWeight + item.Weight <= maxWeight && items.Count < 20) // Максимум 20 слотов
        {
            items.Add(item);
            currentWeight += item.Weight;
            return true;
        }
        return false;
    }

    public bool RemoveItem(Item item)
    {
        if (items.Remove(item))
        {
            currentWeight -= item.Weight;
            return true;
        }
        return false;
    }

    public void CraftItem(string recipeName)
    {
        if (craftingRecipes.TryGetValue(recipeName, out CraftingRecipe recipe))
        {
            if (HasRequiredItems(recipe))
            {
                foreach (var requirement in recipe.Requirements)
                {
                    RemoveItem(requirement.Item);
                }
                AddItem(recipe.Result);
                Console.WriteLine($"Собрали {recipe.Result.Name}");
            }
            else
            {
                Console.WriteLine("Недостаточно материалов для крафта.");
            }
        }
        else
        {
            Console.WriteLine("Рецепт не найден.");
        }
    }

    private bool HasRequiredItems(CraftingRecipe recipe)
    {
        foreach (var requirement in recipe.Requirements)
        {
            var itemCount = items.FindAll(i => i.Name == requirement.Item.Name).Count;
            if (itemCount < requirement.Count)
            {
                return false;
            }
        }
        return true;
    }

    public void AddCraftingRecipe(CraftingRecipe recipe)
    {
        craftingRecipes[recipe.Name] = recipe;
    }

    public void DisplayInventory()
    {
        Console.WriteLine("Инвентарь:");
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Name} (Вес: {item.Weight})");
        }
        Console.WriteLine($"Текущий вес: {currentWeight}/{maxWeight}");
    }
}
