﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hard_group.Inventory
{
    internal class Character1
    {
        public class Character
        {
            // переменные для взаимоотношения героя с нпс
            public int FriendshipLevel { get; set; }
            public int KnowledgeLevel { get; set; }
            public int ExamSuccessRate { get; set; }

            public string Name { get; private set; }
            public int Strength { get; private set; } // Сила персонажа, определяющая максимальный вес
            public Inventory Inventory { get; private set; }

            public Character(string name, int strength)
            {
                Name = name;
                Strength = strength;
                Inventory = new Inventory(strength);
                // отношения
                FriendshipLevel = 0;
                KnowledgeLevel = 0;
                ExamSuccessRate = 0;
            }
        }

    }
}
