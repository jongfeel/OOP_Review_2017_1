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

            // Diffenrent "value" and "object"
            // Let's check out!
        }
    }
}
