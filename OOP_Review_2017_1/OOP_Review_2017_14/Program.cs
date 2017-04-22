using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Review_2017_14
{
    class Program
    {
        static void Main(string[] args)
        {
            // lambda
            int[] numbers = new int[] { 3, 5, 1, 75, 432, 86, 1032, 1783278, -4738 };
            
            // 가장 큰 숫자를 찾아내서 출력해보기
            // 링알못인 분들이 짜는 흔한 로직
            int max = -1000000;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }
            Console.WriteLine("Max(for) number is " + max);

            // 링잘알인 분들이 짜면???
            int linqMax = numbers.Max();
            Console.WriteLine("Max(Max method) number is " + linqMax);

            // 100보다 큰 수의 array를 가져와보기
            int index = 0;
            int [] numbers100 = new int[10];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > 100)
                {
                    numbers100[index] = numbers[i];
                    index++;
                }
            }

            Console.WriteLine("100보다 큰(for) number are ");
            for (int i = 0; i < numbers100.Length; i++)
            {
                Console.Write(numbers100[i] + ", ");
            }
            Console.WriteLine();

            // 링잘알이 짜면??? (링잘알, 람알못)
            Console.WriteLine("100보다 큰(linq where, not lambda) number are ");
            var result = numbers.Where(CheckGreaterThan100);
            foreach (var item in result)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

            // 링잘알, 람잘알이 짜면??
            Console.WriteLine("100보다 큰(linq where, lambda) number are ");
            var result2 = numbers.Where(n => n > 100);
            result2.ToList().ForEach(n => Console.Write(n + ", "));
            Console.WriteLine();

            // lambda의 문법 쓰기
            // parameter의 갯수에 따른 차이
            // parameter 한 개를 쓸 때에는 () 생략 가능
            Action<int> a1 = (n) => { };
            Action<int> a2 = n => Console.Write(n);
            a2 = Method1;

            // method body 구현의 차이
            // method body에 한 줄로 구현할 때에는 {} 생략 가능
            Action<int> a3 = n => { Console.Write(n); };
            Action<int> a4 = n => Console.Write(n);

            // method body가 return value를 가질 경우 불가피하게 method body {} 를 써야 하는데...
            Func<int, int, int> plus = (a, b) =>
            {
                int plus1 = a + b;
                return plus1;
            };

            int value = plus(3, 4);

            // method가 return value를 가진다 하더라도 1줄로 연산이 가능하다면 생략 가능
            // return keyword 마저 생략 가능
            Func<int, int, int> minus = (a, b) => a - b;
        }

        public static void Method1(int n)
        {

        }

        public static bool CheckGreaterThan100(int number)
        {
            if (number > 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}