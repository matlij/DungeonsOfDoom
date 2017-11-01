using DungeonsOfDoom.Core.Interface;
using DungeonsOfDoom.Core.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Character
{
    public class Player : Character
    {
        public Player(int health, int x, int y, int maxItemsInBackpack) : base(health, 'P', 10, "Matte", 5)
        {
            X = x;
            Y = y;
            EquippedWeapon = new Cane();
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
