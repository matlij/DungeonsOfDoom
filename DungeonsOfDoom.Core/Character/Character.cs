using DungeonsOfDoom.Core.Interface;
using DungeonsOfDoom.Core.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Character
{
    public abstract class Character : GamePiece, IPickupAble
    {
        public int Health { get; set; }
        public int Strength { get; set; }
        public string Name { get; }
        public Item EquippedWeapon { get; set; }
        public int MaxItemsInBackpack { get; }
        List<IPickupAble> backPack = new List<IPickupAble>();
        public List<IPickupAble> BackPack { get => backPack; set => backPack = value; }

        public Character(int health, char boardSymbol, int strength, string name, int maxItemsInBackpack) : base(boardSymbol)
        {
            Strength = strength;
            Health = health;
            Name = name;
            MaxItemsInBackpack = maxItemsInBackpack;
        }

        public string DisplayBackPack()
        {
            string backPack = "---- BACKPACK ----";
            for (int i = 0; i < BackPack.Count; i++)
                backPack += $"{Environment.NewLine}Slot {i + 1}: {BackPack[i].Name}";
            for (int i = BackPack.Count; i < MaxItemsInBackpack; i++)
                backPack += $"{Environment.NewLine}Slot {i + 1}:";

            return backPack;
        }

        public void AddToBackpack(IPickupAble item)
        {
            if (backPack.Count < 5)
                backPack.Add(item);
            else
            {
                Console.WriteLine("Ditt backpack är fullt \n Tryck 1-5 om du vill byta ett Item.");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1: BackPack.RemoveAt(0); BackPack.Add(item); break;
                    case ConsoleKey.D2: BackPack.RemoveAt(1); BackPack.Add(item); break;
                    case ConsoleKey.D3: BackPack.RemoveAt(2); BackPack.Add(item); break;
                    case ConsoleKey.D4: BackPack.RemoveAt(3); BackPack.Add(item); break;
                    case ConsoleKey.D5: BackPack.RemoveAt(4); BackPack.Add(item); break;
                    default: break;
                }
            }
        }

        public string UseItem(int index)
        {
            if (BackPack.Count <= index)
                return "";

            var type = backPack[index].GetType();
            var basetype = type.BaseType;

            if (type == typeof(Potion))
            {
                string returnString = "Din hälsa ökade med " + backPack[index].Strength;
                Health += backPack[index].Strength;
                BackPack.RemoveAt(index);
                return returnString;
            }

            else if (basetype == typeof(Weapon))
            {
                EquippedWeapon = (Item)backPack[index];
                string returnString = $"Du böt vapen till {backPack[index].Name} med styrka {backPack[index].Strength}";
                Strength = backPack[index].Strength;
                BackPack.RemoveAt(index);
                return returnString;
            }

            else if (basetype == typeof(Monster))
            {
                string returnString = "Du åt monstret i din backpack och ökade din hälsa med " + backPack[index].Strength;
                Health += backPack[index].Strength;
                BackPack.RemoveAt(index);
                return returnString;
            }

            return "";
        }

        public virtual string Fight(Character opponent)
        {
            string battleMessage = "";
            opponent.Health -= Strength;
            if (opponent.Health > 0)
                battleMessage = $"{opponent.Name} har {opponent.Health} kvar i hälsa \n";
            else if (opponent.Health <= 0)
                battleMessage = $"Du dödade {opponent.Name}";
            return battleMessage;
        }
    }
}
