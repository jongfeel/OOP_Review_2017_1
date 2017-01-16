using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Review_2017_3.FactoryPattern
{
    class OrderManager
    {
        private HaitaiFoodFactory haitaiFoodFactory { set; get; }

        public OrderManager(HaitaiFoodFactory factory)
        {
            haitaiFoodFactory = factory;
        }

        public Snack Jagabee
        {
            get
            {
                return haitaiFoodFactory.CreateJagabee();
            }
        }

        public IEnumerable<Snack> OrderJagabee(uint count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return haitaiFoodFactory.CreateJagabee();
            }
        }
    }
}
