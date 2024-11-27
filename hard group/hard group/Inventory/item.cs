using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hard_group.Inventory
{
    internal class item
    {
        public class Item
        {
            public string Name { get; private set; }
            public int Weight { get; private set; }
            public int Slots { get; private set; } // Количество ячеек, занимаемых предметом

            public Item(string name, int weight, int slots)
            {
                Name = name;
                Weight = weight;
                Slots = slots;
            }
        }
        public class InventorySlot
        {
            public Item Item { get; private set; }

            public InventorySlot(Item item)
            {
                Item = item;
            }
        }

    }
}
