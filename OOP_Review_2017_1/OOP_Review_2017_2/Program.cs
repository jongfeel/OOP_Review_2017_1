using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OOP_Review_2017_2
{
    #region Object oriented
    // Store class의 개체가 Customer class의 개체를 꼭 참조해야 하는가?    
    class Store
    {
        public delegate void PayEvent(int price);
        public PayEvent PayEvent1;
        
        public void Calculate()
        {
            PayEvent1?.Invoke(300);
        }
    }

    class Customer
    {
        private int Cash = 10000;
        public void Pay(int price)
        {
            Cash -= price;
        }
    }
    #endregion

    class Test
    {
        public delegate void DelegateAction();
        // 우리가 delegate를 type으로 인지하는 순간부터 만들어 볼 수 있는 코드
        // parameter로 전달 가능
        public void SetDelegate(DelegateAction action)
        {

        }
    }

    class Program
    {
        // Declare delegate 
        public delegate void DelegateAction();
        public delegate int DelegateAction3(int value, string name);

        public void DelegateAction2() { }
        // Difference DelegateAction and DelegateActionMethod
        public static void DelegateActionMethod()
        {
            Console.WriteLine("Called DelegateActionMethod!");
        }

        public static int DelegateActionMethod10(int value, string name)
        {
            Console.WriteLine("Called DelegateActionMethod10!" + value);
            return value;
        }

        public static void SetDelegate(DelegateAction action)
        {
            action?.Invoke();
        }

        public static DelegateAction GetDelegate()
        {
            return new DelegateAction(DelegateActionMethod);
        }

        public delegate void LambdaTest();
        public delegate void LambdaTest2(int value);

        static void Main(string[] args)
        {
            /*
             * Review delegate
                Lambda
                yield
             */
            // Create delegate object
            // DelegateAction parameter: intellisense "void () target", what is mean?

            // 교과서적인 문법
            DelegateAction da = new DelegateAction(DelegateActionMethod);
            da.Invoke();

            DelegateAction da2 = DelegateActionMethod;
            da2();

            DelegateAction3 da10 = new DelegateAction3(DelegateActionMethod10);
            int returnValue = da10(10, "apple");
            
            DelegateActionMethod();

            Test test = new Test();
            Test.DelegateAction delegateAction = new Test.DelegateAction(DelegateActionMethod);
            test.SetDelegate(delegateAction);

            Store s = new Store();
            Customer c = new Customer();
            s.PayEvent1 = c.Pay;

            // event의 정체: delegate type으로 동작하는 특수한 기능
            //Button button = new Button();
            //button.Click += Button_Click;

            // Lambda
            DelegateAction da3 = () => Console.WriteLine("Called da2 delegate variable.");
            // delegate를 표현하는 문법
            LambdaTest lambda = () => { };
            // parameter 하나를 받는 표현은 () 생략이 가능, 구현부분도 1줄이면 {} 생략 가능
            LambdaTest2 lambda2 = value => value = 1;

            // 평소에 봤던 lambda들...
            List<int> list = new List<int>();
            int findItem = list.Find(obj => obj == 10);
            var result = list.Where(obj => obj > 10);

            foreach (var item in list)
            {

            }

            // yield
            foreach (var item in GetNames)
            {
                if (item != null)
                {
                    Console.WriteLine("AOA member: " + item);
                }
            }

            #region 요청 리뷰
            // 1. LINQ
            // 2. Design pattern: Factory, Starategy
            #endregion
        }

        private static void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // 뭔가 코딩
        }

        public static IEnumerable GetNames
        {
            get
            {
                yield return "Seolhyun";
                // 뭔가 아무거나 있어도 상관 없음
                Console.WriteLine("Seolhyun 가져감");
                yield return null;
                yield return "Cho-a";
                yield break;
                // yield return "Chou Tzu-yu"; // no meaning
            }
        }
        
        public static string GetNames2
        {
            get
            {
                return "Seolhyun";
                //return "Cho-a";
            }
        }

        // 보통 사람들이 만드는 방법, 나쁘지는 않지만 양이 많아지면???
        public static List<string> GetNames3()
        {
            List<string> names = new List<string>
            {
                "Seolhyun",
                "Cho-a"
            };
            return names;
        }
    }
}
