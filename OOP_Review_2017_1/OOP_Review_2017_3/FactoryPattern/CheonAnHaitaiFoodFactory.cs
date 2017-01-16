using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Review_2017_3.FactoryPattern
{
    class CheonAnHaitaiFoodFactory : HaitaiFoodFactory
    {
        public override Biscuit CreateFrenchPie()
        {
            return new FrenchPie();
        }

        public override Snack CreateHoneyButterChip()
        {
            return new HoneyButterChip();
        }

        public override Snack CreateJagabee()
        {
            return new Jagabee();
        }
    }
}
