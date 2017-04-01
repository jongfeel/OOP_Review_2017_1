using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Review_2017_11
{
    interface ITest
    {
        // int age; // cannot
        // GetNameDelegate namedelegate;    // cannot
        GetNameDelegate namedelegate { set; get; }  // property
        event GetNameDelegate nameevent;    // event가 field의 형태인데 어째서???
        int Age { set; get; }   // 되는 이유??? method의 형태라서
        void Method();
    }

    public delegate string GetNameDelegate();

    class Test
    {
        // 내부에서 쓸 때에는 delegate와 event 큰 차이가 없다.
        private GetNameDelegate nameDelegateField;
        public GetNameDelegate NameDelegateField
        {
            set
            {
                if (value != null)
                {
                    nameDelegateField = value;
                }
            }
            get
            {
                return nameDelegateField;
            }
        }

        private event GetNameDelegate nameEvent = null;
        public event GetNameDelegate NameEvent
        {
            add
            {
                // condition???
                if (value != null)
                {
                    if (nameEvent == null)
                    {
                        Console.WriteLine("First add!!!");
                    }
                    nameEvent += value;
                }                
            }
            remove
            {
                nameEvent -= value;
            }
        }

        public void NameChanged()
        {
            nameEvent?.Invoke();
        }

        public void NameChangedDelegate()
        {
            NameDelegateField?.Invoke();
        }
    }

    class Program
    {
        public static string GetName()
        {
            return "James";
        }

        public static event GetNameDelegate NameEvent;

        static void Main(string[] args)
        {
            // event와 delegate
            // 개념에 대한 이해 그리고 차이점
            // 실제 온라인 코딩을 통한 질문/ 답변
            GetNameDelegate del = new GetNameDelegate(GetName);
            string name = del();

            Test t = new Test();
            t.NameDelegateField = () => { return "Robert"; };
            string name2 = t.NameDelegateField();

            Test p = new Test();
            // event is not field
            p.NameEvent += () => { return "Kim"; };
            p.NameEvent += () => { return "Lee"; };
            p.NameEvent += () => { return "Choi"; };

            // static event의 경우에는 event의 특성을 잃어버리는 듯?
            NameEvent = () => { return "Park"; };
            string name3 = NameEvent();

            // delegate vs event 다른 점
            // 1. filed가 아니라는 걸 정확하게 인지하고 있으면 됨
            // 2. 접근성의 차이
            // 2-1. raise하는 주체가 누구냐??? event를 가지고 있는 class가 주인
            // 2-2. class외부에서는 add, remove 외에는 할 수 있는게 없다.

            // 다음 시간
            // 1. 김한별
            // 학교 연구과제중 WPF, MVVM을 쓰면 좋지 않을까에 대한 리뷰
            // 2. Kyung Wong Gil님의
            // Synchronous, Asynchronous, thread and callback, APM(Asynchronous Programming Model)
            // 3. Iccen님의 opencv를 이용해서 어떤 특정 포인트 찾아내기 리뷰 (선 내용 공유)
        }
    }
}
