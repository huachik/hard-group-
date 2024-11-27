using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hard_group
{
    internal class EquipmentSlot
    {
        public class EquipmentSl
        {
            public string Name { get; private set; }
            public Item EquippedItem { get; private set; }

            public EquipmentSl(string name)
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
    }
}
