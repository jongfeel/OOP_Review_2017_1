using OOP_Review_2017_3.FactoryPattern;
using OOP_Review_2017_3.StrategyPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_Review_2017_3
{
    class Program
    {
        static void ForEachMethod(Action action)
        {
            action();
        }
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
            Action action = () =>
            {
                Console.WriteLine("X=" + x);
            };
            x = 20;
            action();   // x value is... 20, why?
            #endregion

            #region closure2
            List<Action> list = new List<Action>();

            int value = 0;
            for (int i = 0; i < 5; i++)
            {
                value = i;    
                list.Add(() => Console.WriteLine(value));
            }
            list.ForEach(forEachAction => forEachAction()); // value 4 write five times. why?
            //list.ForEach(ForEachMethod);
            #endregion

            #region closure3
            /*
             * var add = (function () {
                var counter = 0;
                return function () {return counter += 1;}
            })();
             */

            Func<Action> add = () =>
            {
                int counter = 0;
                return () => counter += 1;
            };
            //add()();

            //Action add1 = add();
            //add1();

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

            #region Question1 - reactive programming
            // http://rxwiki.wikidot.com/101samples
            Console.WriteLine("Shows use of Start to start on a background thread:");
            var o = Observable.Start(() =>
            {
                //This starts on a background thread.
                Console.WriteLine("From background thread. Does not block main thread.");
                Console.WriteLine("Calculating...");
                Thread.Sleep(3000);
                Console.WriteLine("Background work completed.");
            }).Finally(() => Console.WriteLine("Main thread completed."));
            Console.WriteLine("\r\n\t In Main Thread...\r\n");
            o.Wait();   // Wait for completion of background operation.
            #endregion

            // 요청 주제
            // 1. LINQ - Ashley R님이 원하는 주제를 선정해 주세요.
            // 2. Reflection - 두 번 정도 나눠서 준비 - vnenise
            // 3. Attribute - 준비 - vnenise

            // 저도 요청 드리는건
            // 여러분들이 짠 소스코드의 리뷰
        }
    }
}
