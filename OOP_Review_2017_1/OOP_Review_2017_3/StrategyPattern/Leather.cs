using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Review_2017_3.StrategyPattern
{
    class Leather : Armor
    {
        public override int ArmorPoint { get; set; } = 10;

        public override void Wear()
        {
            Console.WriteLine("Leather armor");
        }
    }
}
