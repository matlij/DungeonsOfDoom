using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Character
{
    public abstract class Monster : Character
    {
        public static int Counter { get; set; }
        public Monster(int health, int strength, string name) : base(health, 'M', strength, name, 5)
        {
            Counter++;
        }
    }
}
