﻿using System;
using System.Collections.Generic;
using System.Linq;
//using static hard_group.Inventory.item;

public class Inventory
{
    public int MaxWeight { get; private set; } // Максимальный вес инвентаря
    private List<InventorySlot> Slots { get; set; } // Список ячеек инвентаря
    private Dictionary<string, hard_group.Inventory.CraftingRecipe> CraftingRecipes { get; set; } // Рецепты крафта

    public Inventory(int maxWeight)
    {
        MaxWeight = maxWeight;
        Slots = new List<InventorySlot>();
        CraftingRecipes = new Dictionary<string, hard_group.Inventory.CraftingRecipe>();
    }

    public void AddItem(Item item)
    {
        if (GetTotalWeight() + item.Weight <= MaxWeight && GetAvailableSlots() >= item.Slots)
        {
            Slots.Add(new InventorySlot(item));
            Console.WriteLine($"Добавлен предмет: {item.Name}");
        }
        else
        {
            Console.WriteLine("Недостаточно места или превышен максимальный вес!");
        }
    }

    public void RemoveItem(Item item)
    {
        var removed = Slots.RemoveAll(slot => slot.Item == item);
        if (removed > 0)
        {
            Console.WriteLine($"Удален предмет: {item.Name}");
        }
        else
        {
            Console.WriteLine("Предмет не найден в инвентаре!");
        }
    }

    public int GetTotalWeight()
    {
        return Slots.Sum(slot => slot.Item.Weight);
    }

    public int GetAvailableSlots()
    {
        return Slots.Count(slot => slot.Item != null);
    }

    public void CraftItem(string recipeName)
    {
        if (CraftingRecipes.TryGetValue(recipeName, out var recipe))
        {
            if (HasIngredients(recipe.Ingredients))
            {
                AddItem(recipe.Result);
                foreach (var ingredient in recipe.Ingredients)
                {
                    RemoveItem(ingredient);
                }
                Console.WriteLine($"Скрафтил: {recipe.Result.Name}");
            }
            else
            {
                Console.WriteLine("Недостаточно ингредиентов для крафта!");
            }
        }
        else
        {
            Console.WriteLine("Рецепт не найден!");
        }
    }

    private bool HasIngredients(List<Item> ingredients)
    {
        return ingredients.All(ingredient => Slots.Any(slot => slot.Item == ingredient));
    }

    public void AddCraftingRecipe(string name, List<Item> ingredients, Item result)
    {
        CraftingRecipes[name] = new hard_group.Inventory.CraftingRecipe(name, ingredients, result);
        Console.WriteLine($"Добавлен рецепт: {name}");
    }
}


public class EquipmentSlot
{
    public string Name { get; private set; }
    public Item EquippedItem { get; private set; }

    public EquipmentSlot(string name)
    {
        Name = name;
    }

    public void EquipItem(Item item)
    {
        EquippedItem = item;
        Console.WriteLine($"Предмет {item.Name} надет на слот {Name}");
    }
    public void UnequipItem()
    {
        Console.WriteLine($"Предмет {EquippedItem.Name} снят со слота {Name}");
        EquippedItem = null;
    }
}

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