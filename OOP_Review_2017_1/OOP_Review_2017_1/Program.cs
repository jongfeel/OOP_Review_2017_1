using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Review_2017_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Understanding class and object
             * Different value and object
            Review System.Object
            Review Equals method
            */
            Test t1 = new Test();
            Test t2 = new Test();

            // why?
            bool resultEquals = object.Equals(t1, t2);  // false
            bool resultReferenceEquals = object.ReferenceEquals(t1, t2); // false

            string writeformat = "{0}, {1}";
            Console.WriteLine(writeformat, "object.Equals(t1, t2)", resultEquals);
            Console.WriteLine(writeformat, "object.ReferenceEquals(t1, t2)", resultReferenceEquals);

            t1.Id = 1;
            t2.Id = 1;

            resultEquals = object.Equals(t1.Id, t2.Id);  // true
            resultReferenceEquals = object.ReferenceEquals(t1.Id, t2.Id); // false, why???

            Console.WriteLine(writeformat, "object.Equals(t1.Id, t2.Id)", resultEquals);
            Console.WriteLine(writeformat, "object.ReferenceEquals(t1.Id, t2.Id)", resultReferenceEquals);

            t1.Name = "Test";
            t2.Name = "Test";

            resultEquals = object.Equals(t1.Name, t2.Name);  // true
            resultReferenceEquals = object.ReferenceEquals(t1.Name, t2.Name); // true, why???

            Console.WriteLine(writeformat, "object.Equals(t1.Name, t2.Name)", resultEquals);
            Console.WriteLine(writeformat, "object.ReferenceEquals(t1.Name, t2.Name)", resultReferenceEquals);

            // Diffenrent "value" and "object"
            // Let's check out!

            // value - struct - stack
            // object - class - heap
            // string type - class

            #region Equals
            Test2 test2_1 = new Test2() { Id = 1 };
            Type t = test2_1.GetType();   // Name: "Test2", Namesapce: "OOP_Review_2017_1"
            Test2 test2_2 = new Test2() { Id = 1 };
            Test2 test2_3 = test2_1;

            bool result = test2_1.Equals(test2_2);  // true, why? override Equals method.
            bool result2 = test2_1.Equals(test2_3);  // true

            test2_2.Id = 2;
            bool result3 = test2_1.Equals(test2_2);

            // 비교는 이렇게 하는게 더 쉽지 않나요?
            // 반박: 그런데 이건 int 비교니까 하나 마나인듯...
            if (test2_1.Id == test2_2.Id)
            {

            }
            // Test2 type의 object가 같은가?
            // 이걸 왜 비교하죠? class type도 built-in type과 동일하게 인지하고 싶으니까
            if (test2_1 == test2_2)
            {

            }
            else
            {

            }

            #endregion

            #region 원하는 주제
            // 0. Delegate
            // 1. Lambda
            Action action = () => { };
            // 2. Closure
            // 3. yield???
            #endregion
        }
    }
}
