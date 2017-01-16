using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Review_2017_3.StrategyPattern
{
    class Default : Armor
    {
        public override int ArmorPoint { get; set; } = 1;

        public override void Wear()
        {
            Console.WriteLine("Default armor");
        }
    }
}
