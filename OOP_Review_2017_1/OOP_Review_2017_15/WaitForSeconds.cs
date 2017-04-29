using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Review_2017_15
{
    public class WaitForSeconds
    {
        private float time;
        public float Time
        {
            get
            {
                return time;
            }
        }
        public WaitForSeconds(float time)
        {
            this.time = time;
        }
    }
}
