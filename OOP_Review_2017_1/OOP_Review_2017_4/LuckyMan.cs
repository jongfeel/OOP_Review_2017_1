using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Review_2017_4
{
    class LuckyMan
    {
        public int Count { private set; get; }
        public uint Age { get; set; }
        public string Name { get; set; }

        public bool DoLuckyDraw(uint number)
        {
            int luckyNumber = new Random().Next(0, 10);
            Console.WriteLine("LuckyNumber is " + luckyNumber);

            return luckyNumber == number ? true : false;
        }
    }
}
