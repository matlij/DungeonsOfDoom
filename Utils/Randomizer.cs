using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    static public class Randomizer
    {
        static Random random = new Random();

        static public bool Chance(int percentage)
        {
            return random.Next(0, 99 + 1) < percentage;
        }

        static public int GetRandVal(int min, int max)
        {
            return random.Next(min, max + 1);
        }
    }
}
