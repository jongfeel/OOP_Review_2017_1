using OOP_Review_2017_3.FactoryPattern;
using OOP_Review_2017_3.StrategyPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Review_2017_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Closure
            // 잠깐! closure가 특정 프로그래밍 언어에만 있다고 생각하시는 분들을 위해!
            // 여러 program language에서 사용되는 개념
            // functional programming (함수형 프로그래밍)을 지원하는 언어는 반드시 이 개념이 들어 있다.
            // Closure란?
            // 실행 시간이 다른 function/method를 통해 "상태 값이 보존"되고 그 값을 활용할 수 있게 만드는 기법.
            
            #region closure1
            int x = 10;
            Action action = () => Console.WriteLine("X=" + x);
            x = 20;
            action();   // x value is... 20, why?
            #endregion

            #region closue2
            List<Action> list = new List<Action>();
            for (int i = 0; i < 5; i++)
            {
                list.Add(() => Console.WriteLine(i));
            }
            list.ForEach(forEachAction => forEachAction()); // value 5 write five times. why?
            #endregion

            #region Design pattern: abstract factory and factory method
            HaitaiFoodFactory hff = new CheonAnHaitaiFoodFactory();
            OrderManager om = new OrderManager(hff);
            Snack jagabeeSample = om.Jagabee;
            var jagabees = om.OrderJagabee(100);
            #endregion

            #region Design pattern: strategy
            Character warrior = new Character("Garrosh Hellscream");
            warrior.Armor = new Leather();
            Console.WriteLine("Armor point: " + warrior.Armor.ArmorPoint);
            warrior.Armor = new Plate();
            Console.WriteLine("Armor point: " + warrior.Armor.ArmorPoint);
            #endregion
        }
    }
}
