using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Interface
{
    public interface IPickupAble
    {
        string Name { get; }
        int Strength { get; set; }
    }
}
