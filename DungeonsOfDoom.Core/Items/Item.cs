using DungeonsOfDoom.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Items
{
    public abstract class Item : GamePiece, IPickupAble
    {
        public Item(string name, int strength) : base('I')
        {
            Name = name;
            Strength = strength;
        }
        public int Strength { get; set; }
        public string Name { get; }
    }
}
