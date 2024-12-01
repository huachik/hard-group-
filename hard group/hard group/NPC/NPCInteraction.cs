using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hard_group.NPC
{
    internal class NPCInteraction // Взаимодействие между NPC
    {
         public static void NPCChat(Npc npc1, Npc npc2)
    {
        Random rand = new Random();
        int interactionOutcome = rand.Next(-15, 15); // Случайный эффект от -15 до +15

        npc1.ChangeRelationship(interactionOutcome);
        npc2.ChangeRelationship(interactionOutcome);

        Console.WriteLine($"{npc1.Name} and {npc2.Name} interacted. Their relationships are affected.");
    }
    }
}
