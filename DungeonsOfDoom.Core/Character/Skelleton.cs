using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Character
{
    public class Skelleton : Monster
    {
        public Skelleton() : base(10, Utils.Randomizer.GetRandVal(4, 7), "Skelleton")
        {

        }

        public override string Fight(Character opponent)
        {
            string battleMessage = "";

            if (opponent.Health > 2 * Health)
            {
                Health = 0;
                battleMessage = $"{Name} dog av skräck då du var så stark \n";
            }
            else
            {
                opponent.Health -= Strength;
                if (opponent.Health > 0)
                    battleMessage = $"{opponent.Name} har {opponent.Health} kvar i hälsa \n";
            }
            return battleMessage;
        }
    }
}
