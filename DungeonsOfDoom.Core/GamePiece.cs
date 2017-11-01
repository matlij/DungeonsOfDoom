using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core
{
    public abstract class GamePiece
    {
        public char BoardSymbol { get; }
        public GamePiece(char boardSymbol)
        {
            BoardSymbol = boardSymbol;
        }
    }
}
