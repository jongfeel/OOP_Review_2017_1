using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Review_2017_3.StrategyPattern
{
    class Character
    {
        public Character(string name)
        {
            Name = name;
        }

        public string Name { private set; get; }

        private Armor armor = new Default();
        public Armor Armor
        {
            set
            {
                armor = value;
                armor?.Wear();
            }
            get
            {
                return armor;
            }
        }
    }
}
