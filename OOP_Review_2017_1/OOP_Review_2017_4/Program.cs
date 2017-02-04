using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOP_Review_2017_4
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    class MyDefaultValueAttribute : Attribute
    {
        public int Value { get; set; }

        public MyDefaultValueAttribute()
        {

        }

        public MyDefaultValueAttribute(int value)
        {
            Value = value;
        }
    }

    class Test
    {
        public T CreateInstance<T>() where T : new()
        {
            T instance1 = new T();
            //T instance = Activator.CreateInstance<T>();
            return instance1;
        }

        [MyDefaultValue(10)]
        public int Count { get; set; }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Reflection
             * Attribute
             */

            #region Reflection - Property
            // Reflection을 가장 잘 쓰는 방법은 어떤 type의 개체를 동적으로 추적하여 분석하고
            // 동적인 논리 코드 추가 혹은 set value, call method 등의 행위를 하는 것

            // 이미 정해진 type의 class 생성 및 set value, call method 라면
            LuckyMan luckyman = new LuckyMan()
            {
                Name = "Murphy",
                Age = 20
            };

            bool isWin = luckyman.DoLuckyDraw(3);
            string result = isWin == true ? "Win!" : "Fail!";
            Console.WriteLine(result);

            // Reflection을 통해 분석
            Type luckyManType = luckyman.GetType();

            // Type
            Console.WriteLine("LuckyMan type is " + luckyManType);

            // Property
            luckyManType.GetProperties().ToList().ForEach(pi =>
            {
                Console.WriteLine("Property name: " + pi.Name);
                Console.WriteLine("Property type: " + pi.PropertyType);
                Console.WriteLine("Property can read: " + pi.CanRead);
                Console.WriteLine("Property can write: " + pi.CanWrite);
                Console.WriteLine("Property can write: " + pi.GetAccessors(true));

                Console.WriteLine();
            });

            // Method
            luckyManType.GetMethods().ToList().ForEach(mi =>
            {
                Console.WriteLine("Method name: " + mi.Name);
                Console.WriteLine("Method is public: " + mi.IsPublic);
                Console.WriteLine("Method return type: " + mi.ReturnType);
                Console.WriteLine("Method parameter count: " + mi.GetParameters().Count());

                mi.GetParameters().ToList().ForEach(pi =>
                {
                    Console.WriteLine("Parameter position: " + pi.Position);
                    Console.WriteLine("Parameter name: " + pi.Name);
                    Console.WriteLine("Parameter type: " + pi.ParameterType);
                });

                Console.WriteLine();
            });

            // 동적으로 LuckyMan 개체 생성 및 set value, call method 해보기

            // Get type
            // 주의할 점: Namespace가 포함된 full name을 입력해야 함.
            // reflection을 통해 type name을 찍어봤을 때의 name을 확인해 보기 
            Type luckyMan = Type.GetType("LuckyMan");   // null
            luckyMan = Type.GetType("OOP_Review_2017_4.LuckyMan");

            // 얻어온 type을 가지고 dynamic 개체 생성
            dynamic luckyManInstance = Activator.CreateInstance(luckyMan);

            // "Name"이름을 가진 property를 가져옴
            PropertyInfo nameProperty = luckyMan.GetProperty("Name");

            // 그리고 set value
            nameProperty.SetValue(luckyManInstance, "Zul'jin");

            // 마찬가지로 "Age" 속성을 가져와 set value 한줄에 해보기
            luckyMan.GetProperty("Age").SetValue(luckyManInstance, 44u);    //uint

            // 그리고 출력해봄
            Console.WriteLine("Name: " + luckyManInstance.Name);
            Console.WriteLine("Name: " + luckyManInstance.Age);

            // method도 해봅시다.
            MethodInfo doLuckyDrawMethod =  luckyMan.GetMethod("DoLuckyDraw");

            // method는 invoke로
            dynamic returnValue = doLuckyDrawMethod.Invoke(luckyManInstance, new object[] { 2u });

            // 과연 lucky draw는???
            result = returnValue == true ? "Win!" : "Fail!";
            Console.WriteLine(result);
            #endregion

            #region Attribute
            // Attribute(애트리뷰트)는 Attribute abstract class를 상속받아 구현하는 클래스들로
            // 특정 조건에 한해서 동작하도록 특성, 상태를 부여한다.
            Console.WriteLine();
            Console.WriteLine("Attribute phase");

            // #if DEBUG라고 정의해준 것과 동일
            CallDebugMode("debugging!");

            // DllImport
            // dll 안에 static method에 진입하도록 특성 부여하고 실제 호출 가능하게 만든다.
            // options
            // IconInformation = 0x000040
            // YesNo              = 0x000004
            // OkCancel          = 0x000001
            //MessageBox(IntPtr.Zero, "message box called", "Info", 0x000040 | 0x000001);

            // Visual studio에 특별히 warning setting을 건들지 않았다면 경고로 표시해줌.
            //Delete(0);

            // Attribute는 왜 쓰는 것일까???
            // 동적인 로직 처리가 아닌 정적인 특성, 상태 자체를 표현해 주고 싶은데 (전문 용어로 metadata)
            // text base인 comment로는 충분하지 않기 때문이다.

            // 그럼 동작 원리는???
            // 눈치 빠른 분은 아셨겠지만 reflection을 통해 동작하게 만드는 거죠.
            #endregion

            // 퀄리티 있는 질문에 대한 답변
            // 질문: T i = new T(); 이거 되나요?
            Test test = new Test();
            MyDefaultValueAttribute instance = test.CreateInstance<MyDefaultValueAttribute>();
            // 답변: 됩니다!!! yeah!

            // custom attribute 만들어서 reflection을 통해 알아보기
            Type testType = test.GetType();
            PropertyInfo testPI = testType.GetProperty("Count");
            MyDefaultValueAttribute myAttribute = testPI.GetCustomAttribute<MyDefaultValueAttribute>();
            testPI.SetValue(test, myAttribute.Value);

            // 요청 사항
            // 1. LINQ 자체를 모른다 - basic concept - Ashley R
            // 2. c# 7.0 review - SiYoon Song
            // 3. self 요청 - 동적 method or proeprty 추가 - developerfeel
            // 4. self code reivew 진행 - 누군가 짜 놓은 winform 용 계산기 프로그램 -> refactoring
        }

        [Conditional("DEBUG")]
        public static void CallDebugMode(string message)
        {
            Console.WriteLine(message);
        }

        [DllImport("user32.dll")]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, int options);

        [Obsolete("This method is deprecated. 그러니까 쓰지 말라고!!!")]
        // 이거 없앨꺼니까 쓰면 안됨
        public static void Delete(int value)
        {
            // Unity에서 많이 봤던 그 attribute
        }
    }
}
