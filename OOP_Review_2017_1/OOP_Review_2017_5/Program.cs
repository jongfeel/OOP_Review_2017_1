using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_Review_2017_5
{
    class Letter
    {
        public string Alpha { get; set; }
        public string Beta { get; set; }
        public string Omega { get; set; }

        public Letter()
        {
            Alpha = "Alpha";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
             * LINQ baic
             * C# 7.0 new features
             */

            #region LINQ
            // LINQ는 Language-Integrated Query의 약자로 열거된 (IEnumerable) 데이터에서 질의 (query)를 통해 
            // 원하는 데이터를 가져오는 방법을 얘기함.
            // SQL을 기반으로 문법이 정의되어 있기 떄문에 SQL을 알고 있다면, LINQ를 쉽게 알 수 있다.
            // https://msdn.microsoft.com/ko-kr/library/bb397676.aspx

            // LINQ는 사실... 예제 소스 보면서 이해하면 됩니다.

            #region Not LINQ example 1
            // LINQ 보기 전에 LINQ를 사용하지 않고 한다면 어떤 코드가 나오는지 리뷰
            int[] scores = new int[] { 97, 92, 81, 60 };

            // scores array 중 value가 80 이상인 것을 찾아보기
            // 그러면 아마 이렇게 하실 겁니다...
            int[] scoresGreaterThan80 = new int[scores.Length]; // 몇 개가 나올지는 모르지만 scores 최대 갯수 만큼은 나오겠지 하며 선언...
            int indexGreaterThan80 = 0; // 어쨌든 array니까 index 필요
            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] > 80)
                {
                    scoresGreaterThan80[indexGreaterThan80] = scores[i];
                    indexGreaterThan80++;
                }
            }
            // 그리고 출력
            for (int i = 0; i < indexGreaterThan80; i++)
            {
                Console.Write(scoresGreaterThan80[i] + " ");
            }
            Console.WriteLine();

            // 뿌듯하신가요???
            // 그러면 당신은 이제 C 문법 정도를 알고 있으며 LINQ를 모르는 사람입니다!
            #endregion

            #region LINQ example 1 - basic
            // 거창한건 아니고 위 링크에 있는 예제입니다.
            // Specify the data source.
            scores = new int[] { 97, 92, 81, 60 };

            // Define the query expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            // Execute the query.
            foreach (int i in scoreQuery)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            // 요걸 SQL로 짜보면 어떨까요?
            // SELECT score FROM scores WHERE score > 80

            // 다른점은???
            // DB는 Table base인데 실제 linq 문의 select에 해당하는 부분은 column name인데 해당하는 부분이 존재하지 않음
            // -> SQL을 알고 있는 사람에게는 혼돈의 카오스

            // 그래서 from - in 문법으로 column name에 해당하는 걸 변수명으로 대체, 그리고 그걸 마치 SQL 문에서 Table의 column name 처럼 사용
            // 이 부분만 조금 다르고 나머지 문법은 대동소이함
            // query를 하고자 하는 본질은 동일하므로 DB를 안다뤄보신 분은 SQL을 배우는 것도 좋은 방법
            #endregion

            #region LINQ example 2 - method
            // 다시 같은 예제입니다.
            // Specify the data source.
            scores = new int[] { 97, 92, 81, 60, 3, 5, 2, 43, 1004 };

            // Define the query expression.
            // SQL을 아는 사람이면 이게 편한데...
            // object의 method call을 이용해 뭔가 변화를 주는데에 익숙한 개체지향 프로그래머에게는
            // method call이 더 편할 수 있습니다.

            // 이것은 extension method로 example1의 linq를 Where method 호출로 바꾼겁니다. 결과는 똑같죠.
            IEnumerable<int> scoreQueryCallByWhereMethod = scores.Where(score => score > 80);

            // Execute the query.
            foreach (int i in scoreQueryCallByWhereMethod)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            #endregion

            #endregion

            #region C# 7.0 new features
            // C# 7.0은 Visual Studio 2017 RC 버전에서 complie 가능한걸 확인할 수 있습니다.
            // https://msdn.microsoft.com/en-us/magazine/mt790184.aspx
            // 하지만 하다 보니 NuGet package가 필요한게 있더군요.
            // 그런 것들은 comment 해 놨습니다.

            // 위 링크에도 있지만 microsoft의 문서에 자세히 설명되어 있는 링크입니다.
            // https://docs.microsoft.com/ko-kr/dotnet/articles/csharp/csharp-7

            // 사실 돌려보기만 하면 되는데, 제 모임에서만 들어볼 수 있겠죠. 코드 리뷰니까요.

            #region out variables
            if (int.TryParse("123", out int result))
                Console.WriteLine(result);
            else
                Console.WriteLine("Could not parse input");
            #endregion

            #region Tuple
            // NuGet package "System.ValueTuple"

            dynamic lettersDynamic = "dynamic value";
            var letters = ("a", "b", "c");
            Console.WriteLine("letters tuple item1: " + letters.Item1);
            Console.WriteLine("letters tuple item2: " + letters.Item2);

            var alphabetStart = (Alpha: "a", Beta: "b");
            Console.WriteLine("alphabetStart tuple item1: " + alphabetStart.Item1);
            Console.WriteLine("alphabetStart tuple item2: " + alphabetStart.Item2);
            Console.WriteLine("alphabetStart tuple Alpha: " + alphabetStart.Alpha);
            Console.WriteLine("alphabetStart tuple Beta: " + alphabetStart.Beta);

            (string First, string Second) firstLetters = ("a", "b");   // warning
            Console.WriteLine("firstLetters tuple item1: " + firstLetters.Item1);
            Console.WriteLine("firstLetters tuple item2: " + firstLetters.Item2);
            Console.WriteLine("firstLetters tuple Alpha: " + firstLetters.First);
            Console.WriteLine("firstLetters tuple Beta: " + firstLetters.Second);

            GetLettersTuple(out (string letter, int value, double value2) outThreeTuple);
            Console.WriteLine("outThreeTuple letter " + outThreeTuple.letter);
            Console.WriteLine("outThreeTuple value " + outThreeTuple.value);
            Console.WriteLine("outThreeTuple value2 " + outThreeTuple.value2);
            #endregion

            // 나머지는 실시간 코딩으로...
            // 그게 재밌으니까요.
            #region is keyword

            Letter letter = GetLetters();
            if (letter is Letter letter2)
            {
                // letter의 값을 letter2로 복사
            }
            else
            {
                // Letter type이 아니면...
            }

            // DiceSum2 test
            int sum = DiceSum2(new object[] { 1, 2, 3 });
            #endregion

            #region ref return

            
            Letter letter3 = new Letter();

            int value = 0;
            GetRefValue(ref value);
            Console.WriteLine(value);   // 10

            // ref return
            int [] array = new int[10];
            array[0] = 20;
            ref int returnValue = ref GetRefValue2(array);
            returnValue = 30;   // array[0] is 30

            #endregion
            #endregion

            // 요청사항, 우선순위 변동
            // 1. c# 7.0 review 2 - SiYoon Song
            // 2. Code reivew (Unity3d) - SiYoon Song 
            // 3. self code reivew 진행 - 누군가 짜 놓은 winform 용 계산기 프로그램 -> refactoring
            // 4. LINQ 자체를 모른다 - basic concept - Ashley R
            // 5. self 요청 - 동적 method or proeprty 추가 - developerfeel
        }

        // Tuple이 없던 시절
        public static Letter GetLetters()
        {
            return new Letter() { Alpha = "a", Beta = "b", Omega = "o" };
        }
        
        // Tuple을 쓸 수 있는 시대는?
        public (string, int, double) GetLettersTuple()
        {
            return ("a", 1, 10.05);
        }

        public static bool GetLettersTuple(out (string, int, double) threeTuple)
        {
            threeTuple.Item1 = "a";
            threeTuple.Item2 = 1;
            threeTuple.Item3 = 10.05;

            return true;
        }

        public static int DiceSum2(IEnumerable<object> values)
        {
            var sum = 0;
            foreach (var item in values)
            {
                if (item is int val)
                    sum += val;
                else if (item is IEnumerable<object> subList)
                    sum += DiceSum2(subList);
            }
            return sum;
        }

        public static void GetRefValue(ref int value)
        {
            value = 10;
        }

        public static ref int GetRefValue2(int [] array)
        {
            return ref array[0];
        }
    }
}
