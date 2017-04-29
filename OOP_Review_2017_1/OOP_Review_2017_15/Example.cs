using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Review_2017_15
{
    public class Example : MonoBehaviour
    {
        // This is not MonoBehaviour start method
        public void Start()
        {
            StartCoroutine(WaitAndPrint(1.0f));
        }

        public IEnumerator WaitAndPrint(float waitTime)
        {
            while (true)
            {
                yield return new WaitForSeconds(waitTime);
                Console.WriteLine("WaitAndPrint " + Timespan);
            }
        }
    }
}
