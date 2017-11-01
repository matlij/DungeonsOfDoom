using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Items
{
    public class Potion : Item
    {
        public Potion() : base("Potion", Utils.Randomizer.GetRandVal(10, 20))
        {
        }
    }
}
