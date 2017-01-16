using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Review_2017_3.StrategyPattern
{
    class Plate : Armor
    {
        public override int ArmorPoint { get; set; } = 20;

        public override void Wear()
        {
            Console.WriteLine("Plate armor");
        }
    }
}
