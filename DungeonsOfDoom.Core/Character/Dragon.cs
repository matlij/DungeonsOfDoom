using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Character
{
    public class Dragon : Monster
    {

        public Dragon() : base(50, Utils.Randomizer.GetRandVal(10,20), "Dragon")
        {

        }
    }
}
