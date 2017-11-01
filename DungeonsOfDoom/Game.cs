using DungeonsOfDoom.Core;
using DungeonsOfDoom.Core.Character;
using DungeonsOfDoom.Core.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace DungeonsOfDoom
{
    class Game
    {
        Player player;
        Room[,] world;
        Random random = new Random();
        string gameMessage = "";

        public void Play()
        {
            CreatePlayer();
            CreateWorld();

            do
            {
                Console.Clear();
                DisplayStats();
                DisplayWorld();
                AskForMovement();
            } while (player.Health > 0);

            GameOver();
        }

        void DisplayStats()
        {
            Console.WriteLine("---- STATS ----");
            Console.WriteLine($"Health: {player.Health}");
            Console.WriteLine($"Attack: {player.Strength}");
            Console.WriteLine($"Weapon: {player.EquippedWeapon.Name}");
            Console.WriteLine($"Monsters left: {Monster.Counter}");
            Console.WriteLine(player.DisplayBackPack());
        }

        private void AskForMovement()
        {
            gameMessage = "";
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            int newX = player.X;
            int newY = player.Y;
            bool isValidMove = true;

            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow: newX++; break;
                case ConsoleKey.LeftArrow: newX--; break;
                case ConsoleKey.UpArrow: newY--; break;
                case ConsoleKey.DownArrow: newY++; break;
                case ConsoleKey.D1: gameMessage = player.UseItem(0); break;
                case ConsoleKey.D2: gameMessage = player.UseItem(1); break;
                case ConsoleKey.D3: gameMessage = player.UseItem(2); break;
                case ConsoleKey.D4: gameMessage = player.UseItem(3); break;
                case ConsoleKey.D5: gameMessage = player.UseItem(4); break;

                default: isValidMove = false; break;
            }

            if (isValidMove &&
                newX >= 0 && newX < world.GetLength(0) &&
                newY >= 0 && newY < world.GetLength(1))
            {
                player.X = newX;
                player.Y = newY;

                //Om spelaren går på ett Item
                if (world[player.X, player.Y].Item != null)
                {
                    gameMessage += $"Du hittade: {world[player.X, player.Y].Item.Name}";
                    Item newItem = world[player.X, player.Y].Item;
                    player.AddToBackpack(newItem);
                    world[player.X, player.Y].Item = null;
                }

                //Om spelaren går på ett monster
                if (world[player.X, player.Y].Monster != null)
                {
                    Monster monster = world[player.X, player.Y].Monster;

                    gameMessage += $"Fight! {monster.Name} \n" + player.Fight(monster);
                    if (monster.Health > 0)
                        gameMessage += monster.Fight(player);
                    else if (monster.Health <= 0)
                    {
                        player.AddToBackpack(monster);
                        world[player.X, player.Y].Monster = null;
                        Monster.Counter--;
                        if (Monster.Counter <= 0)
                            GameOver();
                    }
                }

                player.Health--;
            }
        }

        private void DisplayWorld()
        {
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    Room room = world[x, y];
                    if (player.X == x && player.Y == y)
                        Console.Write(player.BoardSymbol);
                    else if (room.Monster != null)
                        Console.Write(room.Monster.BoardSymbol);
                    else if (room.Item != null)
                        Console.Write(room.Item.BoardSymbol);
                    else
                        Console.Write(".");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine(gameMessage);
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game over...");
            Console.ReadKey();
            Play();
        }

        private void CreateWorld()
        {
            world = new Room[20, 5];
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    world[x, y] = new Room();

                    if (player.X != x || player.Y != y)
                    {
                        if (Randomizer.Chance(5))
                            world[x, y].Monster = new Skelleton();
                        else if (Randomizer.Chance(5))
                            world[x, y].Monster = new Dragon();
                        if (Randomizer.Chance(5))
                            world[x, y].Item = new Axe();
                        if (Randomizer.Chance(5))
                            world[x, y].Item = new Sword();
                        if (Randomizer.Chance(5))
                            world[x, y].Item = new Potion();
                    }
                }
            }
            Console.WriteLine(gameMessage);
        }

        private void CreatePlayer()
        {
            player = new Player(30, 0, 0, 5);
        }
    }
}
