using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Review_2017_10
{
    // explicit interface 방법
    // https://msdn.microsoft.com/ko-kr/library/aa288461(v=vs.71).aspx
    // 서로 다른 interface들이 같은 멤버(method, property)를 가지고 있을 때
    // 어느 interface에 있는 멤버인지를 명시적으로 호출할 때
    class Test : IEnumerable
    {
        class Test2
        {

        }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    interface ISqueeze
    {
        string Squeeze();
    }

    class Apple : ISqueeze
    {
        public string Squeeze()
        {
            return "apple juice";
        }
    }

    class Peach : ISqueeze
    {
        public string Squeeze()
        {
            return "Peach juice";
        }
    }

    class Strawberry : ISqueeze
    {
        public string Squeeze()
        {
            return "Strawberry juice";
        }
    }

    class Program
    {
        //public string delegateMethod()
        //{
        //    return "";
        //}

        // delegate에서 필요한 3가지 요소, delegate signature
        // 1. return type: string -> 현재
        // 2. parameter count: 0 -> 현재
        // 3. parameter type: none -> 현재
        public delegate string DelegateMethod();

        static void Main(string[] args)
        {
            // interface and delegate
            // interface는 어렵다??? 왜?
            // 안써봐서 어렵다.

            //int [] array = new int[10];
            //array.GetEnumerator();

            // type?
            int number = 0;
            IEnumerable intEnumerable = new int[10] { 3, 6, 2, 1021, 321, 4213, 21, 421, 2, 9 };
            

            // interface가 type으로 인지가 되는 순간... 그 다음부터는 쉬워질 거에요.

            // interface 왜 쓰는 거에요?
            // object들의 공통된 행동(method)을 정해주는 type인데, 그런 행동을 강제하기 위해서
            IEnumerator intEnumerator = intEnumerable.GetEnumerator();
            object current = null;
            bool next = intEnumerator.MoveNext();
            if (next == true)
            {
                current = intEnumerator.Current;
            }
            
            next = intEnumerator.MoveNext();
            if (next == true)
            {
                current = intEnumerator.Current;
            }

            // foreach가 도는 조건 -> IEnumerable interface를 구현한 모든 객체는 foreach를 사용할 수 있다.
            foreach (var item in intEnumerable)
            {

            }

            // 그러면 list는???
            IEnumerable<int> list = new List<int>();
            // 당연히 IEnumerable interface를 구현했으니까
            foreach (var item2 in list)
            {

            }

            // 또 그러면 우리가 만든 class는?
            //IEnumerable test = new Test();
            //foreach (var item3 in test)
            //{

            //}

            // 이 시점에서 도달할 수 있는 결론
            // object들의 공통된 행동(method)을 정해주는 type인데, 그런 행동을 강제하기 위해서
            // 우리가 예제로 본 IEnumerable interface는 array나 collection을 반복하게 만드는 코드

            // 실전 예제
            ISqueeze s1 = new Strawberry();
            string juice = s1.Squeeze();
            Console.WriteLine(juice);

            ISqueeze a1 = new Apple();
            string juice2 = a1.Squeeze();
            Console.WriteLine(juice2);

            // 문제1. boxing, unboxing
            // 문제2. 너무 옛날 코드 -> 2001년
            List<ISqueeze> list2 = new List<ISqueeze>();
            list2.Add(s1);
            list2.Add(a1);

            list2.ForEach(s => Console.WriteLine(s.Squeeze()));

            // delegate
            // 어떤 객체에 method를 호출할 수 있는 지점을 변수로 담아내는데 이 변수로 담아내는 type -> delegate
            

            Action<ISqueeze> addDelegate = list2.Add;
            addDelegate(new Peach());
            Console.WriteLine("\n added peach!\n");
            list2.ForEach(s => Console.WriteLine(s.Squeeze()));

            DelegateMethod method = new DelegateMethod(s1.Squeeze);
            string juice3 = method();

            // 델알못인 분들의 주장
            // s1.Squeeze() 이렇게 직접 호출할 수 있는 걸
            // 굳이, 왜 왜 왜 왜 이런 문법을 만들어서 왜 대신 부르게 만들지????

            // 변수로 담아냈다는 것의 의미
            // 1. type에 강력한 제한이 걸렸다는 의미
            // 2. method의 파라미터로 전달 가능
            // 3. return type으로 전달 가능

            ConsoleWrite(method);
            DelegateMethod juice4 = GetJuice();
            string juice5 = juice4();

            // 다음 시간
            // 1. Kyung Wong Gil님의 event vs delegate, // Synchronous, Asynchronous, thread and callback, APM(Asynchronous Programming Model)
            // 2. Iccen님의 opencv를 이용해서 어떤 특정 포인트 찾아내기 리뷰 (선 내용 공유)
        }

        public static void ConsoleWrite(DelegateMethod dm)
        {
            if (dm != null)
            {
                Console.WriteLine(dm());
            }
        }

        public static DelegateMethod GetJuice()
        {
            return new Apple().Squeeze;
        }
    }
}
