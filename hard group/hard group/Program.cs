using hard_group.NPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hard_group.Inventory.Character1;
namespace hard_group
{
    class Program
    {
      
    public class GameSimulator // создает поле
        {
        private const int Width = 10;  // Ширина игрового поля
        private const int Height = 5;   // Высота игрового поля

        // Метод для создания игрового поля
        public static char[,] CreateGameField()
        {
            char[,] field = new char[Height, Width];

            // Заполняем поле пробелами
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    field[y, x] = ' ';  // Пустая ячейка
                }
            }

            // Пример размещения некоторых объектов на полу
            field[1, 1] = 'P'; // Игрок
            field[3, 4] = 'B'; // NPC Bob
            field[2, 6] = 'C'; // NPC Charlie
            field[4, 8] = 'W'; // Какой-нибудь предмет или стенка

            return field;
        }

        // Метод для отображения игрового поля
        public static void DisplayGameField(char[,] field)
        {
            for (int y = 0; y < field.GetLength(0); y++)
            {
                for (int x = 0; x < field.GetLength(1); x++)
                {
                    Console.Write(field[y, x]);
                }
                Console.WriteLine(); // Переход на новую строку
            }
        }

        public static void Main(string[] args)
        {
            // Создание игрового поля
            char[,] gameField = CreateGameField();

            // Отображение игрового поля
            DisplayGameField(gameField);

                // Здесь можно добавить взаимодействие с игрой
                Character player = new Character(name: "Alice", 0);
                Npc npc1 = new Npc("Bob");
                Npc npc2 = new Npc("Charlie");

                // Взаимодействие между двумя NPC
                NPCInteraction.NPCChat(npc1, npc2);

                // Триггеры для игрока
                npc1.TriggerEvent(player, "help");
                npc1.TriggerEvent(player, "insult");
                npc1.TriggerEvent(player, "studyTogether");
            }
    } 

    }   
}
