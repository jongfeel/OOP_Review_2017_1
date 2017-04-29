using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace OOP_Review_2017_15
{
    public class MonoBehaviour
    {
        private System.Timers.Timer timer = null;

        private TimeSpan timespan;
        public TimeSpan Timespan
        {
            private set
            {
                timespan = value;
            }
            get
            {
                return timespan;
            }
        }

        public MonoBehaviour()
        {
            // 사실은 SendMessage를 통해 "Update" method가 있는지 체크하고
            // 있으면 호출하는 로직을 짜야 하는데
            // 시뮬레이션 class니까 timer로 대체
            timer = new System.Timers.Timer(10);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timespan = timespan.Add(new TimeSpan(0, 0, 0, 0, 10));
            //Console.WriteLine(timespan.ToString());
        }

        public void StartCoroutine(IEnumerator routine)
        {
            if (routine == null)
            {
                return;
            }
            
            while (routine.MoveNext() == true)
            {
                // unity time management...
                if (routine.Current is WaitForSeconds wfs)
                {
                    TimeSpan current = timespan;
                    while (current.Add(new TimeSpan(0, 0, (int)wfs.Time)) >= timespan)
                    {

                    }
                }
                //else if (...)
            }
        }
    }
}
