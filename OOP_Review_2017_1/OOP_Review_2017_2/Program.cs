﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Review_2017_2
{
    class Program
    {
        // Declare delegate 
        public delegate void DelegateAction();
        // Difference DelegateAction and DelegateActionMethod
        public static void DelegateActionMethod()
        {
            Console.WriteLine("Called DelegateActionMethod!");
        }

        static void Main(string[] args)
        {
            // Create delegate object
            // DelegateAction parameter: intellisense "void () target", what is mean?
            DelegateAction da = new DelegateAction(DelegateActionMethod);
            da.Invoke();

            // Lambda
            DelegateAction da2 = () => Console.WriteLine("Called da2 delegate variable.");

            // yield
            foreach (var item in GetNames)
            {
                if (item != null)
                {
                    Console.WriteLine("AOA member: " + item);
                }
            }
        }

        public static IEnumerable GetNames
        {
            get
            {
                yield return "Seolhyun";
                yield return null;
                yield return "Cho-a";
                yield break;
                // yield return "Chou Tzu-yu"; // no meaning
            }
        }
    }
}
