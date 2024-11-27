using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace hard_group
{
    internal class Game1
    {
        

            private string[,] _field = new string[10, 10];

            private int _contOfHeal = 3;
            private Creature _player;
            private List<Creature> _enemies = new();

            public Game()
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        _field[i, j] = "#";
                    }
                }

                _player = new Creature(100, 100, "P", 5, 5, 10);
                _enemies.Add(new Creature(20, 20, "E", 1, 2, 5));
                _enemies.Add(new Creature(10, 10, "E", 3, 3, 5));
                _enemies.Add(new Creature(40, 40, "E", 6, 6, 5));
                _enemies.Add(new Creature(100, 100, "E", 7, 7, 10));
                _enemies.Add(new Creature(200, 200, "E", 8, 6, 30));
            }

            public void CheckFight()
            {
                foreach (var enemy in _enemies)
                {
                    if (enemy.IsAlive())
                    {
                        if (enemy.X == _player.X && enemy.Y == _player.Y)
                        {
                            _player.TakeDamage(enemy.Strenght);
                            enemy.TakeDamage(_player.Strenght);
                        }

                        if (!enemy.IsAlive())
                        {
                            _contOfHeal++;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.Clear();
                var printField = new string[10, 10];

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        printField[i, j] = _field[i, j];
                    }
                }

                if (_player.IsAlive())
                {
                    printField[_player.Y, _player.X] = _player.Icon;
                }
                else
                {
                    printField[_player.Y, _player.X] = "X";
                }

                foreach (var enemy in _enemies)
                {
                    if (enemy.IsAlive())
                    {
                        if (enemy.X == _player.X && enemy.Y == _player.Y)
                        {
                            printField[enemy.Y, enemy.X] = "F";
                        }
                        else
                        {
                            printField[enemy.Y, enemy.X] = enemy.Icon;
                        }
                    }
                }

                if (_player.IsAlive())
                {
                    for (int y = 0; y < 10; y++)
                    {
                        for (int x = 0; x < 10; x++)
                        {
                            Console.Write(printField[y, x] + " ");
                        }
                        Console.WriteLine();
                    }

                    Console.Write($"hp: {_player.HP()}, heals: {_contOfHeal}");
                }
                else
                {
                    Console.Write("Game Over!");
                }
            }

            public void SpawnEnemy()
            {
                var random = new Random();

                var x = random.Next(0, 9);
                var y = random.Next(0, 9);

                var flag = true;
                while (flag)
                {
                    if (_player.X == x && _player.Y == y)
                    {
                        x = random.Next(0, 9);
                        y = random.Next(0, 9);
                    }
                    else
                    {
                        flag = false;
                    }
                }

                _enemies.Add(new Creature(10, 10, "e", x, y, 30));
            }

            public void Run()
            {
                var step = 1;

                while (true)
                {
                    if (step % 5 == 0)
                    {
                        SpawnEnemy();
                    }

                    Print();
                    CheckFight();
                    var key = Console.ReadKey();

                    if (_player.IsAlive())
                    {
                        switch (key.Key)
                        {
                            case ConsoleKey.LeftArrow:
                                _player.Move(-1, 0);
                                break;
                            case ConsoleKey.RightArrow:
                                _player.Move(1, 0);
                                break;
                            case ConsoleKey.UpArrow:
                                _player.Move(0, -1);
                                break;
                            case ConsoleKey.DownArrow:
                                _player.Move(0, 1);
                                break;
                            case ConsoleKey.H:
                                if (_contOfHeal > 0 && _player.HP() != _player.LimitHP)
                                {
                                    _player.TakeHeal(30);
                                    _contOfHeal--;
                                }
                                break;
                        }
                    }

                    step++;
                }

            }
        }
    }
}
}

    }
}
