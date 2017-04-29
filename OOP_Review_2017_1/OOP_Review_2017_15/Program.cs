using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_Review_2017_15
{
    class Program
    {
        static void Main(string[] args)
        {
            // CoRoutine, IEnumerator
            // IEnumerator
            
            // Unity의 MonoBehaviour 상상력으로 구현해봄
            //Example mb = new Example();
            //mb.Start();

            // IEnumerator 동작 원리
            // MoveNext()를 호출하기 전 까지는 최초의 IEnumerator 개체의 Current는 null이다.
            IEnumerator i = GetValues();
            while (i.MoveNext() == true)
            {
                Console.WriteLine(i?.Current);
            }

            Console.ReadLine();

            // 다음 주제
            // 1. Thread, classic version, task version
        }

        static public IEnumerator GetValues()
        {
            // yield keyword
            // 1. IEnumerator interface의 구현체를 만들어준다.
            // 2. IEnumerator.MoveNext()를 만나면 마지막 yield return을 만난 다음 라인부터 실행한다.
            yield return "aaa";
            // ...
            yield return null;
            // ...
            yield return new Example();
            // ...
            yield return 10;
            Console.WriteLine("return back!!");
        }
    }
}
