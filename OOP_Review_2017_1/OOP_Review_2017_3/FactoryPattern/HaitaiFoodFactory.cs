using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Review_2017_3.FactoryPattern
{
    abstract class HaitaiFoodFactory
    {
        public abstract Snack CreateJagabee();
        public abstract Snack CreateHoneyButterChip();
        public abstract Biscuit CreateFrenchPie();
    }
}
