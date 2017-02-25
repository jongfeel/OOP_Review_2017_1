using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_Review_2017_7
{
    class Sum
    {
        public ulong SumLongTime()
        {
            Console.WriteLine("SumLongTime method called");

            ulong sum = 0;
            for (ulong i = 0; i < 900000000; i++)
            {
                sum += i;
            }
            return sum;
        }

        public async Task<ulong> SumLongTimeAsync()
        {
            Console.WriteLine("SumLongTimeAsync method called");

            //Task<ulong> sumTask = new Task<ulong>(() =>
            //{
            //    ulong sum = 0;
            //    for (ulong i = 0; i < 900000000; i++)
            //    {
            //        sum += i;
            //    }
            //    return sum;
            //});
            //sumTask.Start();
            //return await sumTask;

            return await Task.Factory.StartNew<ulong>(() =>
            {
                ulong sum = 0;
                for (ulong i = 0; i < 900000000; i++)
                {
                    sum += i;
                }
                return sum;
            });
        }
    }
    class Program
    {
        public static void AsyncResult(IAsyncResult result)
        {
            Console.WriteLine("IAsyncResult callback: " + result.IsCompleted);
                        
            Func<ulong> func = result.AsyncState as Func<ulong>;
            // AsyncState를 가져와서 EndInvoke 호출
            ulong sum = func.EndInvoke(result);
            Console.WriteLine("Sum: " + sum);
        }

        static void Main(string[] args)
        {
            #region Sync/Async 기법에 대한 이해
            // sync/async에 대한 이해
            Sum s = new Sum();
            // 뭔가 엄청난 연산을 하는 method 호출
            // 제 노트북 성능으로는 대략 4초 걸립니다.
            //ulong sum1 = s.SumLongTime();  // 이 부분이 synchronous, SumLongTime method가 호출이 끝날 때 까지 기다려야 한다.
            
            // async 하게 뭔가를 하려면
            // SumLongTime method의 delegate 생성
            Func<ulong> sumLongTimeDelegate = new Func<ulong>(s.SumLongTime);
            // 그런데 이렇게 실행해 봤자 sync 형태의 호출이겠죠.
            //ulong sumFromDelegate = sumLongTimeDelegate();

            // callback을 사용해서 결과를 따로 받고 async call 시작 -> BeginInvoke
            Console.WriteLine("BeginInvoke");
            IAsyncResult result = sumLongTimeDelegate.BeginInvoke(new AsyncCallback(Program.AsyncResult), sumLongTimeDelegate);
            // async call 이므로 result.IsCompleted는 false, 끝나는 시점은 AsyncCallBack에서 처리
            Console.WriteLine("IAsyncResult: " + result.IsCompleted);
            // EndInvoke를 하면 프로그램이 바로 종료되므로 AsyncCallBack을 기다리기 위해 sleep을 건다.
            // async call에서 걸리는 시간인 4초 보다 큰 시간을 기다려야 함.
            Thread.Sleep(5000);

            // 각 method 들의 호출 시점 체크해 보면 async에 대한 이해를 하실 수 있겠죠.
            // 제가 작년에도 언급 했지만 비동기 프로그래밍 != 네트워크 프로그래밍 입니다.
            // 그럴려면 동기/비동기에 대한 이해가 필요하죠. 이런 기법을 이용한 것 중에 하나가 네트워크 프로그래밍일 뿐입니다.

            // 비동기라는 말을 어디서 들었다. => thread, callback
            #endregion

            #region C# async/await
            // 이 키워드를 써서 프로그래밍이 가능하려면 아래 기법에 대한 정확한 이해가 동반되어야 함
            // 1. thread
            // 2. callback
            // 3. sync/async

            // 같은 method를 async/await로 작성해 봄
            Console.WriteLine("CallAsync method called!");
            Task<ulong> sumTask = CallAsync();

            //  나는 내 할일을 한다.
            Console.WriteLine("asynchronous woking...");

            ulong sum = sumTask.Result;

            Console.WriteLine("Sum by async/await: " + sum);
            #endregion

            // 요청사항, 우선순위 변동 - 2.25
            // 1. 연습용 프로그램 리뷰 - Iccen Kim
            // https://github.com/icydusk1/Memodic_170224
            // 2. xamarin 라이브러리? 중요 문법: 잘 하는지 못하는지 정도, 응용 방법? - DaeHee Kim
            // 3. c# 7.0 review 2 - SiYoon Song
            // 4. Code reivew (Unity3d) - SiYoon Song 
            // 5. self code reivew 진행 - 누군가 짜 놓은 winform 용 계산기 프로그램 -> refactoring
            // 6. self 요청 - 동적 method or proeprty 추가 - developerfeel
        }

        public async static Task<ulong> CallAsync()
        {
            Sum s = new Sum();

            return await s.SumLongTimeAsync();
        }
    }
}
