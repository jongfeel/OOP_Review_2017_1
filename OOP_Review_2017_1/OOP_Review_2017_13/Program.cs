using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_Review_2017_13
{
    class MyClass
    {
        public string Name { set; get; }
        public int Age { set; get; }

        public int Sum(int a, int b)
        {
            return a + b;
        }
    }

    class Program
    {
        public static void MyAsyncCallback(IAsyncResult ar)
        {
            // operation!
            Func<int, int, int> func = ar.AsyncState as Func<int, int, int>;

            //int result = func.EndInvoke(ar);
            // Completed.
        }

        static void Main(string[] args)
        {
            // asynchronous programming model
            MyClass m = new MyClass();
            
            // synchronous
            int result = m.Sum(5, 6);
            Console.WriteLine("Sum, method call: " + result);

            Func<int, int, int> funcSum = m.Sum;
            Console.WriteLine("Sum, delegate method call: " + funcSum(1, 3));

            IAsyncResult asyncResult = funcSum.BeginInvoke(10, 20, MyAsyncCallback, funcSum);

            Console.WriteLine("Sum, BeginInvoke call, IsCompleted? " + asyncResult.IsCompleted);
            
            result = funcSum.EndInvoke(asyncResult);
            Console.WriteLine("Sum, EndInvoke call, " + result);

            // Reference: Asynchronous Programming Model (APM)
            // https://msdn.microsoft.com/ko-kr/library/ms228963(v=vs.110).aspx

            // 1. 주영인님의 프로젝트 코드 리뷰
            // event나 linq에서의 lambda
        }
    }
}
