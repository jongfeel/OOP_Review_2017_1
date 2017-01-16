using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Review_2017_3.StrategyPattern
{
    abstract class Armor
    {
        public abstract int ArmorPoint { set; get; }
        public abstract void Wear();
    }
}
