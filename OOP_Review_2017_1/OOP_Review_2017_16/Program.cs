using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_Review_2017_16
{
    class Program
    {
        static void Main(string[] args)
        {
            // Threads in c# (Task)

            #region basic thread
            // 1. 기본 thread
            // 2. paramerter 전달 가능
            Thread t = new Thread((obj) =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("thread, " + i);
                }
            });
            t.Start();

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("main, " + i);
            }
            #endregion

            #region ThreadPool
            // 1. 이미 만들어진 thread를 가져와서 돌려줌
            // 2. parameter 전달
            ThreadPool.QueueUserWorkItem((obj) => Console.WriteLine("Threadpool"));
            #endregion

            #region BackgroundWorker thread
            // 1. c#의 event based handler가 추가된 thread 지원 class
            // 2. parameter 전달
            // 3. thread의 끝을 알 수 있다. 그리고 진행 상황도 알 수 있다.
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (sender, e) => Console.WriteLine("BackgroundWorker");
            worker.RunWorkerCompleted += (sender, e) => Console.WriteLine("RunWorkerCompleted");
            worker.RunWorkerAsync();
            #endregion

            #region Task
            Task task = new Task(() => Console.WriteLine("Task"));
            task.Start();

            // asynchronous task
            DoTask();
            #endregion

            #region Task, threadpool
            // 이 한줄의 의미
            // 1. Thread
            // 2. Threadpool
            // 3. Asynchronous
            // 4. Generic
            // 5. Lambda
            // string result = Task.Factory.StartNew<string>(() => "Task.Factory.StartNew").Result;

            Task<string> task2 = Task.Factory.StartNew<string>(() => "Task.Factory.StartNew");
            string result2 = task2.Result;
            
            // asynchronous task
            DoTask2();
            #endregion

            #region 번외편 - Parallel
            // 잠깐! 
            //for (int i = 0; i < 10; i++)
            //{
            //    new Thread(() => Console.WriteLine(i)).Start();
            //}
            // 이런 느낌인데, 실제로는 CPU processor를 활용함.

            List<int> list = new List<int>();
            list.Add(10);
            list.Add(20);
            list.Add(1240);
            list.Add(13230);
            list.Add(13440);
            Parallel.ForEach<int>(list, (item) =>
            {
                Console.WriteLine("Parallel: " + item);
            });
            #endregion

            Thread.Sleep(3000);

            // 다음 주제
            // 랜덤한 주제로 정해서 공지...
        }

        static async void DoTask()
        {
            //Task<int> task = new Task<int>(() =>
            //{
            //    int sum = 0;
            //    for (int i = 0; i < 100; i++)
            //    {
            //        sum += i;
            //    }
            //    return sum;
            //});
            //task.Start();

            //int sum2 = task.Result; // await
            //Console.WriteLine("Sum2: " + sum2);

            Task<int> task = new Task<int>(() =>
            {
                int sum = 0;
                for (int i = 0; i < 100; i++)
                {
                    sum += i;
                }
                return sum;
            });
            task.Start();

            // Do something...

            int sum2 = await task;

            Console.WriteLine("Sum2: " + sum2);
        }

        static async void DoTask2()
        {
            string result = await Task.Factory.StartNew<string>(() => "Task.Factory.StartNew");
        }
    }
}