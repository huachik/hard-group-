public class CraftingRequirement
{
    public Item Item { get; set; }
    public int Count { get; set; }

    public CraftingRequirement(Item item, int count)
    {
        Item = item;
        Count = count;
    }
}