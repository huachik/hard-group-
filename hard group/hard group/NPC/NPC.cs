using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hard_group.Inventory.Character1;

namespace hard_group.NPC
{
    internal class Npc
    {
        public string Name { get; set; }
        public int Relationship { get; set; }

        public Npc(string name)
        {
            Name = name;
            Relationship = 50; // Нейтральное отношение
        }

        private static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
        public void ChangeRelationship(int amount)
        {
            Relationship += amount;
            Relationship = Clamp(Relationship, 0, 100); // Ограничение от 0 до 100
            Console.WriteLine($"{Name}'s relationship changed to {Relationship}");
        }

        public void TriggerEvent( Character player, string eventType)
        {
            switch (eventType)
            {
                case "help":
                    ChangeRelationship(10);
                    Console.WriteLine($"{Name} is grateful for {player.Name}'s help!");
                    break;
                case "insult":
                    ChangeRelationship(-10);
                    Console.WriteLine($"{Name} is upset with {player.Name}.");
                    break;
                case "studyTogether":
                    ChangeRelationship(5);
                    player.KnowledgeLevel += 1;
                    Console.WriteLine($"{Name} studied with {player.Name}. Friendship increased!");
                    break;
                // Добавьте другие триггеры по необходимости
                default:
                    break;
            }
        }
    }
}

